using System.IO.Ports;

namespace SPM_Test_Board
{
    public partial class Form1 : Form
    {
        private enum DataFormats
        {
            ModbusBytes = 0,
            ModbusWords = 0,
            CANBytes = 1,
            CANWords = 2,
            RS485FreeFormat = 3,
            SPIBytes = 4,
            SPIWords = 5,
        }
        SerialPort _serialPort = new SerialPort();

        public Form1()
        {
            InitializeComponent();

            //現在接続されているシリアルポートを取得して、コンボボックスに追加する
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                CMB_SerialPortName.Items.Add(port);
            }
            //一番最初のシリアルポートを選択する
            if (CMB_SerialPortName.Items.Count > 0)
            {
                CMB_SerialPortName.SelectedIndex = 0;
            }

            //データフォーマットのコンボボックスに、DataFormatsの値を追加する
            foreach (DataFormats format in Enum.GetValues(typeof(DataFormats)))
            {
                CMB_DataFormat.Items.Add(format.ToString());
            }
        }

        private void BtnSerialOpen_Click(object sender, EventArgs e)
        {
            //シリアルポートが開かれてないなら、開く。文字色を赤にする
            if (!_serialPort.IsOpen)
            {
                _serialPort.PortName = CMB_SerialPortName.SelectedItem.ToString();
                _serialPort.Open();
                BtnSerialOpen.ForeColor = Color.Red;
                //シリアルポートからデータを受信したときのイベントハンドラーを追加する
                _serialPort.DataReceived += SerialPort_DataReceived;
            }
            else
            {
                _serialPort.Close();
                BtnSerialOpen.ForeColor = Color.Black;
                //シリアルポートからデータを受信したときのイベントハンドラーを削除する
                _serialPort.DataReceived -= SerialPort_DataReceived;
            }
        }

        //シリアルポートからデータを受信したときのイベントハンドラー
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //少し待ってから、受信したデータを読み取る
            System.Threading.Thread.Sleep(10);
            int bytesRead = _serialPort.BytesToRead;

            //受信したデータをTB_RawDataに表示する
            //データはスペース区切りの16進数で表示する
            if (bytesRead > 0)
            {
                //表示用の日付を作成する
                string datetime = DateTime.Now.ToString("HH:mm:ss.fff: ");
                //データ受信
                byte[] data = new byte[256];
                int len = _serialPort.Read(data, 0, bytesRead);
                //末尾2byteをCRCとするため、データの長さから2を引く
                int length = len - 2;
                //CRCを計算する
                UInt16 crc = Calc_crc(data, length);
                //計算したCRCを確認するため、受信データの末尾2バイトと比較する
                UInt16 receivedCrc = (UInt16)(data[length] | (data[length + 1] << 8));
                if (crc == receivedCrc)
                {
                    //データの先頭2バイトをコマンドIDとするため、データの先頭2バイトを取得する
                    byte[] commandIdBytes = new byte[] { data[0], data[1] };
                    UInt16 commandId = (UInt16)((commandIdBytes[0] << 8) | commandIdBytes[1]);
                    //表示用のデータを作成する…dataから先頭2バイトと末尾2バイトを除いたデータを取得する
                    string showData = BitConverter.ToString(data, 2, length - 2).Replace("-", " ");
                    //コマンドIDによって、書き込み先のテキストボックスを変更する
                    switch (commandId)
                    {
                        case 0x5223:
                            this.Invoke(new Action(() =>
                            {
                                TB_SerialData.AppendText(datetime + showData + Environment.NewLine);
                            }));
                            break;
                        case 0x4323:
                            this.Invoke(new Action(() =>
                            {
                                TB_CanData.AppendText(datetime + showData + Environment.NewLine);
                            }));
                            break;
                        case 0x5323:
                            this.Invoke(new Action(() =>
                            {
                                TB_SpiData.AppendText(datetime + showData + Environment.NewLine);
                            }));
                            break;
                        default:
                            break;
                    }
                }

                this.Invoke(new Action(() =>
                {
                    //改行してからデータを表示する
                    //dataをスペース区切りの16進数に変換する
                    string hexData = BitConverter.ToString(data, 0, len).Replace("-", " ");
                    //hexDataの後ろにCRCの判定を追加する
                    hexData += " [CRC: " + (crc == receivedCrc ? "OK" : "NG") + "]";
                    TB_RawData.AppendText(datetime + hexData + Environment.NewLine);
                }));
            }
        }

        //CRCチェック
        // buf		受信データ
        // length	受信データ長(CRCを除く)
        private UInt16 Calc_crc(byte[] buf, int length)
        {
            UInt16 crc = 0xFFFF;
            int i, j;
            byte carrayFlag;
            for (i = 0; i < length; i++)
            {
                crc ^= buf[i];
                for (j = 0; j < 8; j++)
                {
                    carrayFlag = (byte)(crc & 1);
                    crc = (UInt16)(crc >> 1);
                    if (carrayFlag > 0)
                    {
                        crc ^= 0xA001;
                    }
                }
            }
            return crc;
        }

        private void Btn_SerialTestWrite_Click(object sender, EventArgs e)
        {
            //シリアルポートが開かれているなら、テストデータを書き込む
            if (_serialPort.IsOpen)
            {
                //CMB_DataFormatによって、書き込むデータを変更する
                byte[] data;
                byte[] commandId;
                switch (CMB_DataFormat.SelectedIndex)
                {
                    case 0: //ModbusBytes
                        commandId = new byte[] { 0x52, 0x23 };
                        data = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
                        break;
                    case 1: //ModbusWords
                        commandId = new byte[] { 0x52, 0x23 };
                        data = new byte[] { 0x01, 0x03, 0x00, 0x00, 0x00, 0x02, 0xC4, 0x0B };
                        break;
                    case 2: //CANBytes
                        commandId = new byte[] { 0x43, 0x23 };
                        data = new byte[] { 0x14, 0x68, 0x65, 0x6C, 0x6C, 0x6f, 0x20, 0x21, 0x21 };
                        break;
                    case 3: //CANWords
                        commandId = new byte[] { 0x43, 0x23 };
                        data = new byte[] { 0x14, 0x68, 0x65, 0x6C, 0x6C, 0x6f, 0x20, 0x21, 0x21 };
                        break;
                    case 4: //RS485FreeFormat
                        commandId = new byte[] { 0x52, 0x23 };
                        data = System.Text.Encoding.ASCII.GetBytes("Hello0!");
                        break;
                    case 5: //SPIBytes
                        commandId = new byte[] { 0x53, 0x23 };
                        data = new byte[] { 0x01, 0x03, 0x00, 0x00, 0x00, 0x02, 0xC4, 0x0B };
                        break;
                    case 6: //SPIWords
                        commandId = new byte[] { 0x53, 0x23 };
                        data = new byte[] { 0x01, 0x03, 0x00, 0x00, 0x00, 0x02, 0xC4, 0x0B };
                        break;
                    default:
                        return;
                        break;
                }
                //commandId+dataの配列を作成する
                byte[] buf = new byte[commandId.Length + data.Length];
                //CRCの計算のため、commandIdとdataを結合した配列を作成する
                Array.Copy(commandId, 0, buf, 0, commandId.Length);
                Array.Copy(data, 0, buf, commandId.Length, data.Length);
                //CRCを計算する
                UInt16 crc = Calc_crc(buf, buf.Length);
                //commandId+data+CRCの配列を作成する
                byte[] sendBuf = new byte[buf.Length + 2];
                Array.Copy(buf, 0, sendBuf, 0, buf.Length);
                Array.Copy(BitConverter.GetBytes(crc), 0, sendBuf, buf.Length, 2);
                //シリアルポートに書き込む
                _serialPort.Write(sendBuf, 0, sendBuf.Length);
                return;
            }
        }
    }
}
