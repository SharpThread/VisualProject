using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCOM.ContentHelp
{
    public static class MessageTagHelp
    {
        //通信消息标签
        //具体命令体为InfoMessage，其中cmd为bool
        //true->成功
        //false->失败
        public static string MainVMToMin = "MainMin";
        public static string MainVMToClose = "MainClose";

        public static string SettingVMToCom = "SettingCom";
        public static string SettingVMToMain = "SettingMain";

        public static string UartVMToCom = "UartCom";
        public static string UartVMToComOperation = "UartComOperation";
    }
}
