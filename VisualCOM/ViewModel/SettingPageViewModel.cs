using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VisualCOM.Model;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Messaging;
using VisualCOM.ContentHelp;
using System.Timers;
using System.Linq;
using System.Collections.ObjectModel;

namespace VisualCOM.ViewModel
{
    public class SettingPageViewModel : ObservableObject
    {
        private System.Timers.Timer _timer;
        private int storagePortCount;

        private ObservableCollection<ChartArgs> chartSouce;

        public ObservableCollection<ChartArgs> ChartSource
        {
            get { return chartSouce; }
            set { chartSouce = value; OnPropertyChanged(); }
        }
       
        private List<ChartArgs> _chartSource = new List<ChartArgs>();
        public SettingPageViewModel()
        {

            //添加直线类型
            foreach (var t in ChartHelpArgs.chartTypes)
            {
                chartTypes.Add(t);
            }
            //添加颜色
            foreach (var c in ChartHelpArgs.colors)
            {
                chartColors.Add(c);
            }
            //添加形状
            foreach (var s in ChartHelpArgs.lineShapes)
            {
                lineShapes.Add(s);
            }
            //添加外观
            foreach (var s in ChartHelpArgs.pointShapes)
            {
                pointShapes.Add(s);
            }
            //添加主题
            foreach (var s in ChartHelpArgs.chartStyle)
            {
                chartStyles.Add(s);
            }

            chartType = chartTypes[0];
            LineSize = 1;
            PointSize = 10;
            lineShape = lineShapes[0];
            chartColor = chartColors[0];
            pointShape = pointShapes[0];
            chartStyle = chartStyles[0];

            //列表数据初始化
            BaudRates = new List<int>() { 110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 56000, 57600, 115200, 1152000 };
            DataBits = new List<int>() { 5, 6, 7, 8 };
            StopBits = new List<string>() { "1", "2", "1.5" };
            Paritys = new List<string>() { "None", "Even", "Mark", "Odd", "Space" };
            ChannelNames = new List<string>() { "通道1" };
            ChannelName = channelNames[0];

            //扫描端口
            _timer = new System.Timers.Timer();
            _timer.Interval = 200;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();

            //Command
            SaveArgCommand = new RelayCommand(() => SaveArg());
            SaveChartArgsCommand = new RelayCommand(() => SaveChartArgs());
            AddChartArgsCommand = new RelayCommand(() => AddChartsArgs());

            //订阅通道数使
            WeakReferenceMessenger.Default.Register<List<string>>(this, (r, m) =>
            {
                ChannelNames = m;
                ChannelName= ChannelNames[0];
            });
        }

       

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (ComPortHelp.isRun == false)
            {
                _timer.Stop();
                return;
            }
            try
            {
                string[] ports = SerialPort.GetPortNames();
                int currentPortCount = ports.Length;
                if (currentPortCount != storagePortCount)
                {
                    if (currentPortCount > storagePortCount)
                    {
                        PortNames = null;
                        PortNames = new List<string>();
                        PortNames.AddRange(ports);
                        PortName = PortNames[0];
                        storagePortCount = currentPortCount;
                    }
                    else if (currentPortCount < storagePortCount)
                    {
                        IEnumerable<string> removePortName = PortNames.Except(ports);

                        if (removePortName.Single().Equals(ComPortHelp.serialPortModel.PortName))
                        {
                            WeakReferenceMessenger.Default.Send<InfoMessage>(new InfoMessage() { MessageTitle = MessageHead.SerialHotPlugMessage });
                        }

                        PortNames = null;
                        PortNames = new List<string>();
                        PortNames.AddRange(ports);
                        PortName = PortNames[0];
                        storagePortCount = currentPortCount;
                    }
                }
            }
            catch (Exception mes)
            {
                Console.WriteLine(mes.Message);
            }
        }


        #region method

        private void AddChartsArgs()
        {
            
            foreach (var item in _chartSource)
            {
                if(item.ChannelName== ChannelName)
                {
                    item.ChartType = chartType;
                    item.SetColor(chartColor);
                    item.PointSize = System.Convert.ToSingle(pointSize);
                    item.SetPointShape(pointShape);
                    item.LineSize = System.Convert.ToSingle(lineSize);
                    item.SetLineShape(lineShape);
                    item.SetStyle(chartStyle);

                    //DataGrid刷新
                    ChartSource = new ObservableCollection<ChartArgs>(_chartSource);
                    return;
                }
            }

            //chart参数设置
            ChartArgs chartArgs = new ChartArgs();
            chartArgs.ChannelName = ChannelName;
            chartArgs.ChartType = chartType;
            chartArgs.SetColor(chartColor);
            chartArgs.PointSize = System.Convert.ToSingle(pointSize);
            chartArgs.SetPointShape(pointShape);
            chartArgs.LineSize = System.Convert.ToSingle(lineSize);
            chartArgs.SetLineShape(lineShape);
            chartArgs.SetStyle(chartStyle);

            _chartSource.Add(chartArgs);

            //DataGrid显示内容
            ChartSource = new ObservableCollection<ChartArgs>(_chartSource);
            

        }
        private void SaveChartArgs()
        {
            WeakReferenceMessenger.Default.Send(_chartSource);

            //!传递信息
            WeakReferenceMessenger.Default.Send<InfoMessage>(new InfoMessage() { MessageTitle=MessageHead.ChartArgSetting});

        }
        private void SaveArg()
        {
            if (PortName == null)
            {
                WeakReferenceMessenger.Default.Send(new InfoMessage() { MessageTitle = MessageHead.SettingVMToCom, MessageCommand = false });
                return;
            }

            //串口参数设置
            CommonSerialPortArgs commonSerialPortArgs = new CommonSerialPortArgs();
            commonSerialPortArgs.SetBaudRate(BaudRate);
            commonSerialPortArgs.SetDataBit(DataBit);
            commonSerialPortArgs.SetParity(Parity);
            commonSerialPortArgs.SetStopBits(StopBit);
            commonSerialPortArgs.SetPortName(PortName);
            ComPortHelp.SetSerialArg(commonSerialPortArgs);
            
            WeakReferenceMessenger.Default.Send(new InfoMessage() { MessageTitle = MessageHead.SettingVMToMain, MessageCommand = true });
        }


        #endregion 方法结束

        #region propertys
        private List<string> chartStyles = new List<string>();

        public List<string> ChartStyles
        {
            get { return chartStyles; }
            set { chartStyles = value; SetProperty(ref chartStyles, value); }
        }


        private List<string> chartTypes = new List<string>();
        public List<string> ChartTypes
        {
            get { return chartTypes; }
            set
            {
                chartTypes = value;
                SetProperty(ref chartTypes, value);
            }
        }
        private string chartType;

        public string ChartType
        {
            get { return chartType; }
            set { chartType = value; SetProperty(ref chartType, value); }
        }

        private List<string> pointShapes = new List<string>();
        public List<string> PointShapes
        {
            get { return pointShapes; }
            set
            {
                pointShapes = value;
                SetProperty(ref pointShapes, value);
            }
        }

        private List<string> lineShapes = new List<string>();
        public List<string> LineShapes
        {
            get { return lineShapes; }
            set
            {
                lineShapes = value;
                SetProperty(ref lineShapes, value);
            }
        }

        private List<string> chartColors = new List<string>();

        public List<string> ChartColors
        {
            get { return chartColors; }
            set { chartColors = value; SetProperty(ref chartColors, value); }
        }


        private List<int> baudRates;
        public List<int> BaudRates
        {
            get { return baudRates; }
            set { baudRates = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// UI绑定数据位设置
        /// </summary>
        private List<int> dataBits;
        public List<int> DataBits
        {
            get { return dataBits; }
            set { dataBits = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// UI绑定校验位
        /// </summary>
        private List<string> paritys;
        public List<string> Paritys
        {
            get { return paritys; }
            set { paritys = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// UI绑定停止位
        /// </summary>
        private List<string> stopBits;
        public List<string> StopBits
        {
            get { return stopBits; }
            set { stopBits = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// UI绑定串口名
        /// </summary>
        private List<string> portNames = new List<string>();

        public List<string> PortNames
        {
            get { return portNames; }
            set { portNames = value; OnPropertyChanged(); }
        }

        #endregion 结束

        #region property


        private string channelName;

        public string ChannelName
        {
            get { return channelName; }
            set { channelName = value; OnPropertyChanged(); }
        }

        private List<string> channelNames;

        public List<string> ChannelNames
        {
            get { return channelNames; }
            set { channelNames = value; OnPropertyChanged(); }
        }


        private bool isCustom = true;

        public bool IsCustom
        {
            get { return isCustom; }
            set 
            { 
                isCustom = value; 
                if (isCustom)
                {
                    PointSize = 10;
                    PointShape = "实心圆";
                    LineSize = 1;
                    LineShape = "实线";
                    ChartColor = "红色";
                    ChartStyle = "默认";
                }
                OnPropertyChanged(); 
            }
        }

        private string chartStyle;

        public string ChartStyle
        {
            get { return chartStyle; }
            set { SetProperty(ref chartStyle, value); }
        }

        private string chartColor;

        public string ChartColor
        {
            get { return chartColor; }
            set { SetProperty(ref chartColor, value); }
        }


        private double pointSize;

        public double PointSize
        {
            get { return pointSize; }
            set
            {
                SetProperty(ref pointSize, value);
            }
        }

        private double lineSize;

        public double LineSize
        {
            get { return lineSize; }
            set
            {
                
                SetProperty(ref lineSize, value);

            }
        }
        private string lineType;
        public string LineType
        {
            get { return lineType; }
            set { SetProperty(ref lineType, value); }
        }

        private string pointShape;

        public string PointShape
        {
            get { return pointShape; }
            set { SetProperty(ref pointShape, value); }
        }


        private string lineShape;

        public string LineShape
        {
            get { return lineShape; }
            set { SetProperty(ref lineShape, value); }
        }


        private bool isTheme;
        public bool IsTheme
        {
            get { return isTheme; }
            set { isTheme = value; OnPropertyChanged(); }
        }

        private string portName;

        public string PortName
        {
            get { return portName; }
            set { portName = value; OnPropertyChanged(); }
        }


        /// <summary>
        /// 波特率
        /// </summary>
        private int baudRate = 115200;
        public int BaudRate
        {
            get { return baudRate; }
            set { baudRate = value; OnPropertyChanged(); }
        }


        /// <summary>
        /// 数据位
        /// </summary>
        private int dataBit = 8;
        public int DataBit
        {
            get { return dataBit; }
            set { dataBit = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 校验位
        /// </summary>
        private string parity = "None";
        public string Parity
        {
            get { return parity; }
            set
            {
                parity = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 停止位
        /// </summary>
        private string stopBit = "1";
        public string StopBit
        {
            get { return stopBit; }
            set { stopBit = value; OnPropertyChanged(); }
        }




        #endregion 结束

        #region command
        public ICommand SaveArgCommand { get; private set; }

        public ICommand SaveChartArgsCommand { get; private set; }

        public ICommand AddChartArgsCommand { get;private set; }

        #endregion
    }
}
