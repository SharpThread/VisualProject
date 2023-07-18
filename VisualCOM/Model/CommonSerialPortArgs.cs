using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace VisualCOM.Model
{
    public class CommonSerialPortArgs
    {
		
        /// <summary>
        /// 停止位
        /// </summary>
        private StopBits _stopBits;
        /// <summary>
        /// 校验位
        /// </summary>
        private Parity _parity;
        /// <summary>
        /// 数据位
        /// </summary>
        private int _dataBit;
        /// <summary>
        /// 波特率
        /// </summary>
        private int _baudRate;
        /// <summary>
        /// 串口名
        /// </summary>
        private string _portName;
        public void SetStopBits(string emp)
        {
            _stopBits = StopBits.None;
            switch (emp)
            {
                case "1": _stopBits = StopBits.One; break;
                case "2": _stopBits = StopBits.Two; break;
                case "1.5": _stopBits = StopBits.OnePointFive; break;
            }
        }
        public void SetParity(string emp)
        {
            _parity = Parity.None;
            switch (emp)
            {
                case "None": _parity = Parity.None; break;
                case "Even": _parity = Parity.Even; break;
                case "Mark": _parity = Parity.Mark; break;
                case "Odd": _parity = Parity.Odd; break;
                case "Space": _parity = Parity.Space; break;
            }
        }
        public void SetDataBit(int bit)
        {
            _dataBit=bit;
        }
        public void SetBaudRate(int baud)
        {
            _baudRate=baud;
        }
        public void SetPortName(string emp)
        {
            _portName = emp;
        }
        public StopBits GetStopBits()
        {
            return _stopBits;
        }
        public int GetDataBit()
        {
            return _dataBit;
        }
        public int GetBaudRate()
        {
            return _baudRate;
        }
        public string GetPortName()
        {
            return _portName;
        }
        public Parity GetParity()
        {
            return _parity;
        }
    }
}
