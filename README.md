# LOL挂机助手 🎮

[中文](README.md) | [English](README_EN.md)

![GitHub](https://img.shields.io/badge/language-C%23-blue)
![Platform](https://img.shields.io/badge/platform-Windows-lightgrey)
![License](https://img.shields.io/badge/license-MIT-green)
[![Star History Chart](https://api.star-history.com/svg?repos=LOL-FUZHU/LOL-FUZHU&type=Year)](https://star-history.com/#LOL-FUZHU/LOL-FUZHU&Year)

一个基于图像识别技术的英雄联盟(LOL)挂机助手，专门用于人机对战的自动化操作。通过大漠插件实现屏幕找图和模拟操作，安全无内存修改。

## ✨ 核心功能

- 🎯 自动接受对局并进行英雄选择
- 🤖 智能人机对战，自动攻击和移动
- 🔄 断线自动重连，对局结束自动重新开始
- 🎨 图形化操作界面，一键启停
- 💬 支持自定义聊天文本
- 🖥️ 自动调整游戏窗口位置
- 🎮 支持锁定/解锁视角

## 💡 工作原理

- 基于图像识别进行界面操作
- 通过查找特定图片位置实现自动操作
- 支持固定坐标和动态找图两种模式
- 模拟真实玩家操作，添加随机延迟
- 自动处理各类游戏弹窗和确认框

## 🚀 环境要求

### 系统要求
- Windows操作系统
- .NET Framework运行环境
- 1920*1080分辨率
- 游戏窗口化运行

### 依赖组件
- 大漠插件(dm.dll)
- LOL客户端
- 配套图片资源

## 📦 项目结构

```
项目目录
├── 核心类
│   ├── Form1.cs          # 主窗体和控制逻辑
│   ├── CDmSoft.cs        # 大漠插件封装类
│   ├── My.cs             # 工具类
│   └── 截图.cs           # 截图处理类
├── 资源文件
│   ├── 用于查找图片/     # 图像识别模板
│   │   ├── Play按钮.bmp
│   │   ├── 人机对战.bmp
│   │   ├── 接受.bmp
│   │   ├── 锁定英雄.bmp
│   │   └── 更多图片...
│   └── 文本.txt         # 自定义聊天文本
└── 运行文件
    └── bin/Debug/       # 程序运行目录
```

## 🎯 主要功能实现

### 图像识别模块
```csharp
public bool 查找图片(string 图片名称, out int X, out int Y)
{
    dm.FindPic(0, 0, 2000, 1000, ".\\用于查找图片\\" + 图片名称, 
               "000000", 0.8, 0, out object intX, out object intY);
    X = (int)intX;
    Y = (int)intY;
    return (X >= 0 && Y >= 0);
}
```

### 操作模拟
```csharp
public void 鼠标移动左键单击(int X, int Y)
{
    // 添加随机偏移实现真实点击
    My.Computer.MouseMoveToPixel(
        X + 随机数.Next(0, 5) - 随机数.Next(0, 5), 
        Y + 随机数.Next(0, 5) - 随机数.Next(0, 5)
    );
    My.Computer.MouseLeftClick();
}
```

## 📝 使用说明

1. 安装步骤
   - 确保已安装大漠插件(dm.dll)
   - 将程序解压到任意目录
   - 确保"用于查找图片"文件夹中图片完整

2. 运行程序
   - 启动英雄联盟客户端
   - 运行本程序
   - 点击"开始"按钮即可自动运行

3. 注意事项
   - 游戏需要以窗口模式运行
   - 确保游戏分辨率为1920*1080
   - 可通过修改文本.txt自定义聊天内容
   - 建议仅在人机对战中使用

## ⚠️ 免责声明

- 本程序仅供学习研究使用
- 使用本程序可能违反游戏用户协议
- 请勿在正常对局中使用
- 对于使用本程序造成的任何后果，开发者不承担责任

## 📋 支持功能列表

- [x] 自动接受对局
- [x] 自动英雄选择
- [x] 自动攻击移动
- [x] 自动重连
- [x] 对局结束自动重开
- [x] 自动调整窗口
- [x] 自定义聊天文本
- [x] 随机延迟模拟
- [x] 一键启停控制

## 👨‍💻 开发说明

本项目使用C# WinForms开发，主要依赖：
- .NET Framework
- System.Drawing
- System.Windows.Forms
- 大漠插件API

## 📄 许可证

本项目基于MIT许可证开源 - 查看 [LICENSE](LICENSE) 文件了解详情
