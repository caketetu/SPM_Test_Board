# SPM-Test-Board

![MIT](https://img.shields.io/badge/license-MIT-blue.svg)
![Version](https://img.shields.io/badge/version-1.0.0-brightgreen.svg)

## 概要

SPM-ESPSMボードを利用した通信テストプログラム。\
https://github.com/caketetu/SPM-ESPSM-V1\
主にハードウェアのチェックに使用。

## 機能

* RS485のパロットバック
* CAN通信の確認
* SPI通信の確認

<!--
## ピンアサイン
| Function       | Pin  | 備考 |
| -------------- | ---- | ---- |
| TIM2_CH1       | PA0  |   ENC-A   |
| TIM2_CH2       | PA1  |   ENC-B   |
| USART2_TX      | PA2  |   SYS-RS485   |
| GPIO_Input     | PA3  |   H_LIMIT   |
| GPIO_Input     | PA4  |   L_LIMIT   |
| SPI1_SCK       | PA5  |   SYS-SPI   |
| SPI1_MISO      | PA6  |   SYS-SPI   |
| SPI1_MOSI      | PA7  |   SYS-SPI   |
| TIM1_CH1       | PA8  |  CK    |
| USART1_TX      | PA9  |  SYS-UART    |
| USART1_RX      | PA10 |  SYS-UART    |
| FDCAN1_RX      | PA11 |  SYS-CANFD    |
| FDCAN1_TX      | PA12 |  SYS-CANFD    |
| DEBUG_SWDIO    | PA13 |  SYS-DEBUG    |
| DEBUG_SWCLK    | PA14 |  SYS-DEBUG    |
| USART2_RX      | PA15 |  SYS-RS485    |
| SPI1_NSS       | PB0  |  SYS-SPI    |
| GPIO_Output    | PB1  |  STBY    |
| GPIO_Output    | PB2  |  CW/CCW    |
| GPIO_Output    | PB3  |  M1    |
| GPIO_Output    | PB4  |  SYS-LED1    |
| GPIO_Input     | PB5  |  SYS-EN    |
| GPIO_Output    | PB6  |  M2    |
| GPIO_Output    | PB7  |  ENABLE    |
| GPIO_Output    | PB8  |  TQ    |
| GPIO_Input     | PB9  |   HOME   |
| GPIO_Output    | PC6  |   SYS-LED0    |
| RCC_OSCIN      | PC14 |   SYS-CLOCK   |
| RCC_OSCOUT     | PC15 |   SYS-CLOCK   |
| RCC_MCO        | PF2  |   SYS-DEBUG   |

※SYS-はSPM共通インターフェース
-->

## 開発環境

| 項目       | 内容                   |
| -------- | ----------------------- |
| IDE      | Visual Studio2022 |


## インストール

## 実装予定機能

* [ ] SPI通信の確認
