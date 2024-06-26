# 原神启动器

这是一个基于C#的Windows Forms应用程序，用于启动原神游戏。

## 安装和运行

首先，确保您已经安装了C# 8.0或更高版本。

1. 下载项目并解压到空白文件夹。
2. 运行应用程序，输入游戏路径，即可启动原神。

## 功能

该应用程序包含以下功能：
- 启动游戏
- 保存游戏和配置文件目录
- 切换服务器

### 主要类

- `MainWindow`：应用程序的主要窗口，用于显示游戏和提供用户交互。
- `Program`：应用程序的主类，用于处理游戏启动、保存、TKD服务器切换和B服切换等操作。

### 主要方法

- `Main`：启动应用程序的事件方法，用于创建窗口和启动游戏。

### 代码片段

下面是`Program`类的一个示例方法，用于启动游戏：

```csharp
public void StartGame()
{
    string Game_Path = @"C:\path\to\Games\YuanShen.exe";
    string mu = files.INIRead("General", "Music", ".ini");
    string path = ".\\Re\\ding.wav";
    string ding = ".\\Re\\Robin Schulz,David Guetta,Cheat Codes - Shed a Light.wav";

    if (string.IsNullOrEmpty(Game_Path))
    {
        Stop();
        Process.Start("explor.exe", "https://ys.mihoyo.com/cloud/#/");
    }
    else
    {
        if (mu == "false")
        {
            // 停止播放器
            SoundPlayer player1 = new SoundPlayer(path);
            player1.Stop();

            // 启动游戏
            Process process = Process.Start(Game_Path + "\\YuanShen.exe");
            process.WaitForExit();
        }
        else
        {
            // 播放音乐
            player.Play();
            // 等待游戏加载
            await Task.Delay(49500);

            // 启动游戏
            Process process = Process.Start(Game_Path + "\\YuanShen.exe");
            process.WaitForExit();
        }
    }
}
````
#### 特别感谢：

MedicineKing: 感谢您为这个项目做出贡献。
shed-a-light: 特别感谢您为我们提供了有用的信息，帮助我们修改了部分bug。
如果您有任何其他问题或需要更多帮助，请随时在GitHub上联系我。

如果您有任何建议或问题，请随时在[GitHub](https://github.com/MedicineKing/MK-GIL)上联系项目维护者。

[GitHub](https://github.com/MedicineKing/MK-GIL): 这是一个开源的项目，您可以通过GitHub上发布的源代码来查看，修改和分发该项目。

[作者](https://github.com/MedicineKing): 感谢您抽出宝贵的时间阅读此项目。如果您有任何建议或问题，请随时在GitHub上联系我。
