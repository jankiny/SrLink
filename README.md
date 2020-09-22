# 说明

简化树人大学网络连接流程，自动进行校园网认证，连接`L2TP`网络，发送本机`IP`到指定邮箱。

~~使用本程序可使计算机在无人控制的情况下自动连接网络（设置程序在早上8点后开始尝试连接网络），使用接收的`IP`可在学校机房远程控制寝室中的计算机（`win10`需要专业版）。~~

**最近网络连接的时间被提早到了早上8点以前，同时寝室的计算机不能在机房被`ping`通。本程序目前仍可可作为随e行的代替。**

## 当前功能

**由于在`v2.2.1`版本进行了重构，部分按钮不可使用，如“自动连接”下的`立即连接`功能，“发送IP地址”下的`测试邮箱`功能（邮件功能可用，只是不能发送测试邮件）**

使用以下功能需要首先勾选“自动连接”的`启用`选项。

### 校园网认证

需要在配置中输入“学号”和“密码”。若勾选了“校园网认证”的`启用`选项，程序执行`连接网络`时会先进行认证，认证成功后再进行后续操作。

### 网络连接

需要在配置中输入“服务器地址”、“账号”和“密码”，服务器地址两校区不同，`默认`服务器与随e行提供的默认服务器相同。若勾选了“网络连接”的`启用`选项，程序会创建L2TP连接，并维护该连接。

### 发送IP地址

如有需要，填写用于接收`IP地址`的邮箱，网络连接成功后会自动发送邮件到“填写的邮箱”（可能会在垃圾邮件中）。

## 安装使用

进入[Release](https://github.com/jankiny/SrLink/releases)页面，下载最新版本。解压后，运行`SRLink.exe`即可（程序默认打开到状态栏，不在桌面显示）。

