using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace VisualCOM.ValueConvert
{
    public class ComSwitchConvert : IValueConverter
    {
        //数据源传输数据给目标源调用Convert方法
        //ConvertBack为俩者相反
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //默认数据不为空,数据源不会出错
            if(value!=null)
            {
                //如果value转换为string类型为true,则返回真
                if(bool.Parse(value.ToString()))
                {
                    return "关闭串口";
                }
            }
            return "打开串口";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
