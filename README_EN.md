# LOL AFK Assistant 🎮

[中文](README.md) | [English](README_EN.md)

![GitHub](https://img.shields.io/badge/language-C%23-blue)
![Platform](https://img.shields.io/badge/platform-Windows-lightgrey)
![License](https://img.shields.io/badge/license-MIT-green)

An automated League of Legends (LOL) assistant based on image recognition technology, specifically designed for Co-op vs. AI matches. Utilizes DM plugin for screen detection and operation simulation, safe with no memory modifications.

## ✨ Core Features

- 🎯 Auto accept matches and select champions
- 🤖 Smart AI battle automation with attack and movement
- 🔄 Auto reconnect and auto restart after matches
- 🎨 Graphical interface with one-click control
- 💬 Customizable chat messages
- 🖥️ Automatic game window positioning
- 🎮 Camera lock/unlock support

## 💡 Working Principle

- Interface operation based on image recognition
- Automated actions through specific image detection
- Supports both fixed coordinates and dynamic image finding
- Simulates real player actions with random delays
- Automatically handles game popups and confirmations

## 🚀 Requirements

### System Requirements
- Windows Operating System
- .NET Framework Runtime
- 1920*1080 Resolution
- Game in windowed mode

### Dependencies
- DM Plugin (dm.dll)
- LOL Client
- Required image resources

## 📦 Project Structure

```
Project Directory
├── Core Classes
│   ├── Form1.cs          # Main form and control logic
│   ├── CDmSoft.cs        # DM plugin wrapper class
│   ├── My.cs             # Utility class
│   └── 截图.cs           # Screenshot handler class
├── Resources
│   ├── 用于查找图片/     # Image recognition templates
│   │   ├── Play按钮.bmp
│   │   ├── 人机对战.bmp
│   │   ├── 接受.bmp
│   │   ├── 锁定英雄.bmp
│   │   └── More images...
│   └── 文本.txt         # Custom chat text
└── Runtime
    └── bin/Debug/       # Program runtime directory
```

## 🎯 Core Implementation

### Image Recognition Module
```csharp
public bool FindImage(string imageName, out int X, out int Y)
{
    dm.FindPic(0, 0, 2000, 1000, ".\\用于查找图片\\" + imageName, 
               "000000", 0.8, 0, out object intX, out object intY);
    X = (int)intX;
    Y = (int)intY;
    return (X >= 0 && Y >= 0);
}
```

### Operation Simulation
```csharp
public void MouseMoveAndClick(int X, int Y)
{
    // Add random offset for realistic clicking
    My.Computer.MouseMoveToPixel(
        X + Random.Next(0, 5) - Random.Next(0, 5), 
        Y + Random.Next(0, 5) - Random.Next(0, 5)
    );
    My.Computer.MouseLeftClick();
}
```

## 📝 Usage Guide

1. Installation Steps
   - Ensure DM plugin (dm.dll) is installed
   - Extract program to any directory
   - Verify all images in "用于查找图片" folder are complete

2. Running the Program
   - Launch LOL client
   - Run this program
   - Click "Start" button to begin automation

3. Important Notes
   - Game must run in windowed mode
   - Ensure game resolution is 1920*1080
   - Customize chat content through 文本.txt
   - Recommended for Co-op vs. AI only

## ⚠️ Disclaimer

- This program is for learning and research purposes only
- Usage may violate game terms of service
- Do not use in normal matches
- Developer assumes no responsibility for consequences of usage

## 📋 Feature List

- [x] Auto match acceptance
- [x] Auto champion selection
- [x] Auto attack and movement
- [x] Auto reconnection
- [x] Auto restart after match
- [x] Auto window adjustment
- [x] Custom chat text
- [x] Random delay simulation
- [x] One-click control

## 👨‍💻 Development Notes

Developed using C# WinForms with main dependencies:
- .NET Framework
- System.Drawing
- System.Windows.Forms
- DM Plugin API

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details