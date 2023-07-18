using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCOM.Model
{
    public enum MessageHead
    {
        MainVMToMin,
        MainVMToClose,
        SettingVMToCom,
        SettingVMToMain,
        SettingVMToChart,
        UartVMToCom,
        UartVMToComOperation,
        SerialHotPlugMessage,
        RepeatAddChart,
        RepeatRemoveChart,
        NoAddChart,
        DataUtilError,
        DataUtilArgSetting,
        ChartArgSetting
    }
}
