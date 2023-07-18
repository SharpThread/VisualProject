using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualCOM.Model;

namespace VisualCOM.ContentHelp
{
    public static class ComPortHelp
    {
        public static bool isRun = false;
        public static readonly SerialPortModel serialPortModel=new SerialPortModel();
        public static void SetSerialArg(CommonSerialPortArgs args)
        {
            serialPortModel.isGetParameter = true;
            serialPortModel.PortName = args.GetPortName();
            serialPortModel.BaudRate=args.GetBaudRate();
            serialPortModel.DataBits = args.GetDataBit();
            serialPortModel.StopBits=args.GetStopBits();
            serialPortModel.Parity = args.GetParity();
        }
    }
}
