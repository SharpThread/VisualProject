using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using VisualCOM.Model;
using System;
using System.IO.Ports;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using Timer = System.Timers.Timer;
using VisualCOM.ContentHelp;
using System.Threading.Tasks;

namespace VisualCOM.ViewModel
{
    public class UartPageViewModel : ObservableObject
    {
        /// <summary>
        /// 操作的串口
        /// </summary>
        private static SerialPortModel _serialPort = null;
        /// <summary>
        /// /利用StringBuilder代替string
        /// 大量赋值操作会产生较多内存
        /// </summary>
        private StringBuilder builder = new StringBuilder();
        /// <summary>
        /// 定时器
        /// </summary>
        private Timer _timer;

        public UartPageViewModel()
        {
            //定时器初始化
            _timer = new Timer();
            _timer.Elapsed += _timer_Elapsed;
            
            WeakReferenceMessenger.Default.Register<InfoMessage>(this, (r, m) =>
            {
               if(m.MessageTitle==MessageHead.SerialHotPlugMessage)
                {
                    IsOpen = false;
                    _serialPort = null;
                }
                if (m.MessageTitle == MessageHead.MainVMToClose)
                {
                    if(m.MessageCommand)
                    {
                        Close();
                        _timer.Stop();
                        _timer.Close();
                    }
                }
            });

            //命令初始化
            ClearReceiveCommand = new RelayCommand(() => ClearReceive());
            ClearSendCommand = new RelayCommand(() => ClearSend());
            SendCommand = new RelayCommand(() => Send());
            OpenComCommand = new RelayCommand(() => Open());
        }

        /// <summary>
        /// 定时发送回调事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                //如果在打开串口之前选择定时发送
                if (_serialPort != null)
                {
                    if (_serialPort.IsOpen)
                    {
                        Send();
                    }
                }
            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }
        }

        #region 方法区

        /// <summary>
        /// 串口关闭方法
        /// </summary>
        private void Close()
        {
            try
            {
                if (_serialPort != null)
                {
                    //判断串口是否关闭
                    if (_serialPort.IsOpen)
                    {
                        _serialPort.Close();
                        IsOpen = _serialPort.IsOpen;
                        _serialPort = null;
                        _timer.Stop();
                        return;
                    }
                    else
                    {
                        IsOpen = _serialPort.IsOpen;
                        return;
                    }
                }
            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
                IsOpen = false;
            }
        }
        /// <summary>
        /// 串口打开方法
        /// </summary>
        private void Open()
        {
            //已经获得串口实例且为打开
            if (_serialPort != null && _serialPort.IsOpen)
            {
                Close();
                return;
            }
            try
            {
                //是否设置参数
                if (ComPortHelp.serialPortModel.isGetParameter)
                {
                    //超时时间可以优化根据数据位和波特率计算
                    _serialPort = ComPortHelp.serialPortModel;

                    /*待优化*/
                    _serialPort.WriteTimeout = 500;
                    _serialPort.ReadTimeout = 500;

                    _serialPort.ReadBufferSize = 4096;

                    _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
                   

                    ///双使能后每次开关触发复位信息
                    _serialPort.DtrEnable = true;
                    _serialPort.RtsEnable = true;

                    //接收到有一个字节就触发
                    //收到多少字节才触发事件
                    _serialPort.ReceivedBytesThreshold = 1;

                    _serialPort.OpenPort();

                    if (_serialPort.IsOpen)
                    {
                        IsOpen = true;
                        return;
                    }
                    else
                    {
                        IsOpen = false;
                        return;
                    }
                }
                else
                {
                    WeakReferenceMessenger.Default.Send(new InfoMessage() { MessageTitle = MessageHead.UartVMToCom, MessageCommand = false });
                }
            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }
            IsOpen = false;
        }


        /// <summary>
        /// 清除接收区方法
        /// </summary>
        private void ClearReceive()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.DiscardInBuffer();
            }
            ReceiveContent = String.Empty;
            ReceiveCount = 0;
        }

        /// <summary>
        /// 清除发送区方法
        /// </summary>
        private void ClearSend()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.DiscardOutBuffer();
            }
            SendContent = String.Empty;
            SendCount = 0;
        }

        /// <summary>
        /// 接收数据回调事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //如果没有勾选停止接收
            if (StopReceive != true)
            {
                if (_serialPort.BytesToRead > 0)
                {
                    //获得字节流
                    int count = _serialPort.BytesToRead;
                    byte[] readBuffer = new byte[count];
                    int count2 = _serialPort.Read(readBuffer, 0, readBuffer.Length);

                    builder.Clear();
                    if (ReceiveEncoding == true)
                    {
                        //转换为ASCII类型的值
                        builder.Append(Encoding.ASCII.GetString(readBuffer));

                    }
                    else if (ReceiveEncoding == false)
                    {
                        //转换为HEX类型的值
                        builder.Append(ConvertData.BytesToHex(readBuffer));
                    }

                    //调用主线程刷新UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        if (AppendTime == true)
                        {
                            ReceiveContent += DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:") + "收: " + builder.ToString();
                        }
                        else
                        {
                            ReceiveContent += builder.ToString();
                        }
                        ReceiveCount += count;
                    }));
                   
                }
                //勾选则不进行数据处理,清除接收缓存区
            }
        }

        /// <summary>
        /// 发送数据方法
        /// </summary>
        private void SendData(string sendMessage)
        {
            string message = sendMessage;
            if (_serialPort != null && _serialPort.IsOpen)
            {
                try
                {
                    int count = 0;
                    if (SendEncoding == true)
                    {
                        //ASCII形式发送
                        byte[] SendAscii = System.Text.Encoding.ASCII.GetBytes(message);
                        count = SendAscii.Length;
                        _serialPort.Write(SendAscii, 0, SendAscii.Length);

                    }
                    else if (SendEncoding == false)
                    {
                        //Hex形式发送
                        byte[] SendHex = ConvertData.HexToBytes
                            (message);
                        count = SendHex.Length;
                        _serialPort.Write(SendHex, 0, SendHex.Length);
                    }
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        SendCount += count;
                    }));

                }
                catch (Exception m)
                {
                    Console.WriteLine(m.Message);
                }
            }
            else
            {
                WeakReferenceMessenger.Default.Send(new InfoMessage() { MessageTitle = MessageHead.UartVMToComOperation, MessageCommand = false });
            }
        }

        /// <summary>
        /// 发送方法
        /// </summary>
        private void Send()
        {
            string sendMessage = null;
            //如果选择了自动换行就打印回车
            if (AddLine == true)
            {
                sendMessage = SendContent + Environment.NewLine;
            }
            else
            {
                sendMessage = SendContent;
            }
            SendData(sendMessage);

        }


        #endregion 方法区结束

        #region 绑定数据区

        private bool sendEncoding=true;

        public bool SendEncoding
        {
            get { return sendEncoding; }
            set { SetProperty(ref sendEncoding, value); }
        }

        private bool receiveEncoding=true;

        public bool ReceiveEncoding
        {
            get { return receiveEncoding; }
            set { SetProperty(ref receiveEncoding, value); }
        }


        #endregion RadioButton结束

        /// <summary>
        /// 是否打开
        /// </summary>
        private bool isOpen;

        public bool IsOpen
        {
            get { return isOpen; }
            set { isOpen = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 发送个数
        /// </summary>
        private int sendCount = 0;

        public int SendCount
        {
            get { return sendCount; }
            set { sendCount = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 接收个数
        /// </summary>
        private int receiveCount = 0;

        public int ReceiveCount
        {
            get { return receiveCount; }
            set { receiveCount = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 接收内容
        /// </summary>
        private string receiveContent;

        public string ReceiveContent
        {
            get { return receiveContent; }
            set { receiveContent = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 发送内容
        /// </summary>
        private string sendContent;
        public string SendContent
        {
            get { return sendContent; }
            set { sendContent = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 发送时间
        /// </summary>
        private string time = "1000";

        public string Time
        {
            get { return time; }
            set { time = value; OnPropertyChanged(); }
        }

        #region checkbox

        /// <summary>
        /// 停止接收
        /// </summary>
        private bool stopReceive;

        public bool StopReceive
        {
            get { return stopReceive; }
            set { stopReceive = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 日志模式
        /// </summary>
        private bool appendTime;

        public bool AppendTime
        {
            get { return appendTime; }
            set { appendTime = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 自动换行
        /// </summary>
        private bool addLine;
        public bool AddLine
        {
            get { return addLine; }
            set { addLine = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 是否自动发送
        /// </summary>
        private bool autoSend;
        public bool AutoSend
        {
            get { return autoSend; }
            set
            {
                autoSend = value;
                if (autoSend == true)
                {
                    _timer.Interval = System.Convert.ToDouble(Time);
                    _timer.Start();

                }
                else
                {
                    _timer.Stop();
                }
                OnPropertyChanged();
            }
        }

        #endregion checkbox结束

        

        #region Command
        public ICommand ClearReceiveCommand { get; private set; }
        public ICommand OpenComCommand { get; private set; }
        public ICommand SendCommand { get; private set; }
        public ICommand ClearSendCommand { get; private set; }
        public ICommand StopReceiveCommand { get; private set; }
        #endregion Command结束
    }
}
