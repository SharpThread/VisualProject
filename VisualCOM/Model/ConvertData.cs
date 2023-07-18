using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VisualCOM.Model
{
    public static class ConvertData
    {
        //备用方案
        //public static string BytesToHex(byte[] toBytes)
        //{
        //    var bytes = toBytes;
        //    StringBuilder sb = new StringBuilder(bytes.Length * 3);
        //    foreach (byte b in bytes)
        //    {
        //        sb.Append(Convert.ToString(b,16).PadLeft(2,'0').PadRight(3,' '));
        //    }
        //    return sb.ToString().ToUpper();
        //}

        /// <summary>
        /// 字节数组转Hex方法
        /// </summary>
        /// <param name="toHexBytes">
        /// 需要转换的字节数组(编码请在调用方法前处理)
        /// </param>
        /// <returns>
        /// 转换后十六进制的字符串
        /// </returns>
        public static string BytesToHex(byte[] toHexBytes)
        {
            var bytes = toHexBytes;
            //转换为字符串,将每个字节的符号间隔'-'转换为空格,显示形式为大写
            string hex = BitConverter.ToString(bytes, 0).Replace("-", " ").ToUpper();
            return hex;
        }

        /// <summary>
        /// Hex字符串转字节数组
        /// </summary>
        /// <param name="hex">
        /// 需要转换的十六进制字符串
        /// </param>
        /// <returns>
        /// 返回转换后的字节数组
        /// </returns>
        public static byte[] HexToBytes(string hex)
        {
            //删除空格
            hex=hex.Trim();
            //转换
            var inputByteArray = new byte[hex.Length / 2];
            for (int i = 0; i < inputByteArray.Length; i++)
            {
                //从0->1,2->3,转换为16进制
                var x = System.Convert.ToInt32(hex.Substring((i * 2), 2), 16);
                inputByteArray[i] = (byte)x;
            }
            return inputByteArray;
        }
    }
}
