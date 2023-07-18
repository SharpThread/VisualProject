using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using VisualCOM.ContentHelp;
using VisualCOM.Model;


namespace View.VisualCOM
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            //订阅消息事件
            WeakReferenceMessenger.Default.Register<InfoMessage>(this, (r, m) =>
            {
                MessageHead title = m.MessageTitle;
                bool cmd = m.MessageCommand;
                if (title == MessageHead.MainVMToClose)
                {
                    if (cmd) { this.Close(); }
                }
                else if (title == MessageHead.MainVMToMin)
                {
                    if (cmd) { this.WindowState = WindowState.Minimized; }
                }
                else if (title == MessageHead.SettingVMToMain)
                {
                    if (cmd) { MessageBox.Show("参数设置完毕"); }
                }
                else if (title == MessageHead.SettingVMToCom)
                {
                    if (!cmd) { MessageBox.Show("未选择串口"); }
                }
                else if (title == MessageHead.UartVMToCom)
                {
                    if (!cmd) { MessageBox.Show("未设置串口"); }
                }
                else if (title == MessageHead.UartVMToComOperation)
                {
                    if (!cmd) { MessageBox.Show("未打开串口"); }
                }
                else if (title == MessageHead.SettingVMToChart)
                {
                    if (cmd)
                    {
                        MessageBox.Show("chart参数设置完成");
                    }
                    else
                    {
                        MessageBox.Show("chart参数未设置");
                    }
                }
                else if(title==MessageHead.NoAddChart)
                {
                    MessageBox.Show("未添加通道");
                }
                else if(title==MessageHead.RepeatAddChart)
                {
                    MessageBox.Show("多次添加通道");
                }
                else if(title == MessageHead.RepeatRemoveChart)
                {
                    MessageBox.Show("该通道不存在");
                }
                else if(title==MessageHead.DataUtilError)
                {
                    MessageBox.Show("帧格式错误");
                }
                else if(title==MessageHead.DataUtilArgSetting)
                {
                    MessageBox.Show("帧设置完毕");
                }
                else if(title==MessageHead.ChartArgSetting)
                {
                    MessageBox.Show("绘图参数设置完毕");
                }
            });
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            ComPortHelp.isRun = false;

            base.OnClosing(e);

        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }


    }
}
