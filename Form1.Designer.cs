namespace SPM_Test_Board
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TB_SerialData = new TextBox();
            TB_CanData = new TextBox();
            TB_SpiData = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            BtnSerialOpen = new Button();
            CMB_DataFormat = new ComboBox();
            TB_WriteData = new TextBox();
            Btn_SerialWrite = new Button();
            label4 = new Label();
            L_CRC = new Label();
            CMB_SerialPortName = new ComboBox();
            Btn_SerialTestWrite = new Button();
            TB_RawData = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // TB_SerialData
            // 
            TB_SerialData.Location = new Point(12, 27);
            TB_SerialData.Multiline = true;
            TB_SerialData.Name = "TB_SerialData";
            TB_SerialData.ScrollBars = ScrollBars.Vertical;
            TB_SerialData.Size = new Size(657, 157);
            TB_SerialData.TabIndex = 0;
            // 
            // TB_CanData
            // 
            TB_CanData.Location = new Point(12, 205);
            TB_CanData.Multiline = true;
            TB_CanData.Name = "TB_CanData";
            TB_CanData.ScrollBars = ScrollBars.Vertical;
            TB_CanData.Size = new Size(657, 157);
            TB_CanData.TabIndex = 1;
            // 
            // TB_SpiData
            // 
            TB_SpiData.Location = new Point(12, 383);
            TB_SpiData.Multiline = true;
            TB_SpiData.Name = "TB_SpiData";
            TB_SpiData.ScrollBars = ScrollBars.Vertical;
            TB_SpiData.Size = new Size(657, 157);
            TB_SpiData.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 3;
            label1.Text = "Serial Data";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 187);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 4;
            label2.Text = "CAN Data";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 365);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 5;
            label3.Text = "SPI Data";
            // 
            // BtnSerialOpen
            // 
            BtnSerialOpen.Location = new Point(678, 56);
            BtnSerialOpen.Name = "BtnSerialOpen";
            BtnSerialOpen.Size = new Size(118, 43);
            BtnSerialOpen.TabIndex = 7;
            BtnSerialOpen.Text = "Open";
            BtnSerialOpen.UseVisualStyleBackColor = true;
            BtnSerialOpen.Click += BtnSerialOpen_Click;
            // 
            // CMB_DataFormat
            // 
            CMB_DataFormat.FormattingEnabled = true;
            CMB_DataFormat.Location = new Point(675, 105);
            CMB_DataFormat.Name = "CMB_DataFormat";
            CMB_DataFormat.Size = new Size(121, 23);
            CMB_DataFormat.TabIndex = 8;
            // 
            // TB_WriteData
            // 
            TB_WriteData.Location = new Point(675, 184);
            TB_WriteData.Multiline = true;
            TB_WriteData.Name = "TB_WriteData";
            TB_WriteData.Size = new Size(121, 228);
            TB_WriteData.TabIndex = 9;
            // 
            // Btn_SerialWrite
            // 
            Btn_SerialWrite.Location = new Point(706, 442);
            Btn_SerialWrite.Name = "Btn_SerialWrite";
            Btn_SerialWrite.Size = new Size(90, 30);
            Btn_SerialWrite.TabIndex = 10;
            Btn_SerialWrite.Text = "Write";
            Btn_SerialWrite.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(678, 424);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 11;
            label4.Text = "CRC";
            // 
            // L_CRC
            // 
            L_CRC.AutoSize = true;
            L_CRC.Location = new Point(738, 424);
            L_CRC.Name = "L_CRC";
            L_CRC.Size = new Size(19, 15);
            L_CRC.TabIndex = 12;
            L_CRC.Text = "00";
            // 
            // CMB_SerialPortName
            // 
            CMB_SerialPortName.FormattingEnabled = true;
            CMB_SerialPortName.Location = new Point(675, 27);
            CMB_SerialPortName.Name = "CMB_SerialPortName";
            CMB_SerialPortName.Size = new Size(121, 23);
            CMB_SerialPortName.TabIndex = 13;
            // 
            // Btn_SerialTestWrite
            // 
            Btn_SerialTestWrite.Location = new Point(706, 134);
            Btn_SerialTestWrite.Name = "Btn_SerialTestWrite";
            Btn_SerialTestWrite.Size = new Size(90, 30);
            Btn_SerialTestWrite.TabIndex = 14;
            Btn_SerialTestWrite.Text = "Write";
            Btn_SerialTestWrite.UseVisualStyleBackColor = true;
            Btn_SerialTestWrite.Click += Btn_SerialTestWrite_Click;
            // 
            // TB_RawData
            // 
            TB_RawData.Location = new Point(12, 568);
            TB_RawData.Multiline = true;
            TB_RawData.Name = "TB_RawData";
            TB_RawData.ScrollBars = ScrollBars.Vertical;
            TB_RawData.Size = new Size(657, 61);
            TB_RawData.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 543);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 16;
            label5.Text = "Raw Data";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(816, 641);
            Controls.Add(label5);
            Controls.Add(TB_RawData);
            Controls.Add(Btn_SerialTestWrite);
            Controls.Add(CMB_SerialPortName);
            Controls.Add(L_CRC);
            Controls.Add(label4);
            Controls.Add(Btn_SerialWrite);
            Controls.Add(TB_WriteData);
            Controls.Add(CMB_DataFormat);
            Controls.Add(BtnSerialOpen);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TB_SpiData);
            Controls.Add(TB_CanData);
            Controls.Add(TB_SerialData);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TB_SerialData;
        private TextBox TB_CanData;
        private TextBox TB_SpiData;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button BtnSerialOpen;
        private ComboBox CMB_DataFormat;
        private TextBox TB_WriteData;
        private Button Btn_SerialWrite;
        private Label label4;
        private Label L_CRC;
        private ComboBox CMB_SerialPortName;
        private Button Btn_SerialTestWrite;
        private TextBox TB_RawData;
        private Label label5;
    }
}
