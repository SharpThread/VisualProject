using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCOM.Model
{
    public class SerialPortModel : SerialPort
    {
       public bool isGetParameter = false;
       
        public void SetComArgs(CommonSerialPortArgs serialArgs)
        {
            BaudRate = serialArgs.GetBaudRate();
            DataBits = serialArgs.GetDataBit();
            Parity = serialArgs.GetParity();
            StopBits = serialArgs.GetStopBits();
            PortName = serialArgs.GetPortName();
            Encoding = Encoding.ASCII;
            isGetParameter = true;
        }
        public void SetEncoding(Encoding encoding)
        {
            Encoding = encoding;
        }

        public void OpenPort()
        {
            if (isGetParameter)
            {
                try
                {
                    if(!IsOpen) 
                    Open();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                throw new Exception("串口参数未设置");
            }
        }

        public bool ClosePort()
        {
            if (IsOpen)
            {
                try
                {
                    //非托管资源释放
                    Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else { return false; }
        }

        public void ClearReadBuffer()
        {
            if(IsOpen)
            {
                DiscardInBuffer();
            }
            else
            {
                throw new Exception("串口无效");
            }
        }

        public void ClearWriteBuffer()
        {
            if (IsOpen)
            {
                DiscardOutBuffer();
            }
            else
            {
                throw new Exception("串口无效");
            }
        }
    }
}
