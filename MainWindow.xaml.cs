using System.Diagnostics;
using System.Windows;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Windows.Themes;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.NetworkInformation;

namespace 原神__启动_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// bool huiwen(int n, int d)
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        private void CBox_Checked(object sender, RoutedEventArgs e)
        {
            FilesINI files = new FilesINI();
            files.INIWrite("General", "Music", "false", ".//ini//config.ini");
        }
        private void CBox_Unchecked(object sender, RoutedEventArgs e)
        {
            FilesINI files = new FilesINI();
            files.INIWrite("General", "Music", "true", ".//ini//config.ini");
        }
        private void Button_Click_1(object sender, RoutedEventArgs e) //游戏路径
        {
            FilesINI files = new FilesINI();
            files.INIWrite("General", "Game", Game_Path.Text, ".//ini//config.ini");//原神.路径
            //files.INIWrite("General", "INI_P", INIPath.Text, ".//ini//config.ini"); //配置文件.路径

        }
        private async void Button_Click(object sender, RoutedEventArgs e)        //Game Starting
        {

            string Game_Path, mu;
            FilesINI files = new FilesINI();
            Game_Path = files.INIRead("General", "INI_P", ".//ini//config.ini");
            mu = files.INIRead("General", "Music", ".//ini//config.ini");
            string path = ".//Re//Robin Schulz,David Guetta,Cheat Codes - Shed a Light.wav";
            string ding = ".//Re//ding.wav"; System.Media.SoundPlayer player = new System.Media.SoundPlayer(path);

            if (string.IsNullOrEmpty(Game_Path))
            {
                player.Stop();
                System.Diagnostics.Process.Start("explor.exe", "https://ys.mihoyo.com/cloud/#/");
            }
            else
            {
                if (mu == "false")
                {
                    //await Task.Delay(20000);
                    player.Stop();
                    Process process = Process.Start(Game_Path + "\\YuanShen.exe");
                    process.WaitForExit();
                }
                else
                {
                    player.Play();
                    await Task.Delay(49500);
                    Process process = Process.Start(Game_Path + "\\YuanShen.exe");
                    process.WaitForExit();
                }
            }

        }

        private void tkd(object sender, RoutedEventArgs e)             //TKD服务器切换
        {
            {
                string Game_Path;
                string ding = ".//Re//ding.wav";
                FilesINI files = new FilesINI();
                Game_Path = files.INIRead("General", "INI_P", ".//ini//config.ini");
                if (string.IsNullOrEmpty(Game_Path))
                {
                    System.Media.SoundPlayer player1 = new System.Media.SoundPlayer(ding);
                    player1.Play();
                    System.Windows.MessageBox.Show("切换服务器时\n.ini路径不能为空,切换失败！", "Error");
                }
                else
                {
                    int textBox1 = 1;//官服 channel
                    string s1 = textBox1.ToString();
                    string s2 = Convert.ToString(s1);
                    FilesINI ConfigINI = new FilesINI();
                    ConfigINI.INIWrite("General", "channel", s2, Game_Path + "//config.ini");
                }


            }
        }

        private void B(object sender, RoutedEventArgs e)                //B服切换
        {
            string Game_Path;
            FilesINI files = new FilesINI();
            string ding = ".//Re//ding.wav";
            Game_Path = files.INIRead("General", "INI_P", ".//ini//config.ini");
            if (string.IsNullOrEmpty(Game_Path))
            {
                System.Media.SoundPlayer player1 = new System.Media.SoundPlayer(ding);
                player1.Play();
                System.Windows.MessageBox.Show("不懂就问，ini文件在哪里", "Error");

            }
            else
            {
                int textBox1 = 14;
                string s1 = textBox1.ToString();
                string s2 = Convert.ToString(s1);
                FilesINI ConfigINI = new FilesINI();
                ConfigINI.INIWrite("General", "channel", s2, Game_Path + "//config.ini");
                System.Windows.MessageBox.Show("切换成功！\n当前服务器：B服", "切换");
            }


        }

    }
}