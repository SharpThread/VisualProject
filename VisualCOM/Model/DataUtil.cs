using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using VisualCOM.ViewModel;

namespace VisualCOM.Model
{
    public class DataUtil
    {
        public enum UtilFormat
        {
            String,
            Hex
        }
        public UtilFormat utilFormatValue;

        //不定长
        public byte[] head;//帧头
        public byte[] tail;//帧尾
        public byte[] separator;//分隔符

        int headCount, tailCount, separatorCount;
        public int channelCount;//通道数
        private int byteCount = 0;//字节个数

        /// <summary>
        /// 通道数据类型
        /// </summary>
        List<Type> types;
        /// <summary>
        /// 通道存储个数
        /// </summary>
        private int[] typeCount;
        /// <summary>
        /// 通道存储个数游标
        /// </summary>
        private int setIndex;
        /// <summary>
        /// Hex入口
        /// </summary>
        /// <param name="count"></param>
        public DataUtil(int count)
        {
            channelCount = count;
            types = new List<Type>(channelCount);
            typeCount = new int[channelCount];
        }
        /// <summary>
        /// String入口
        /// </summary>
        /// <param name="head"></param>
        /// <param name="tail"></param>
        /// <param name="separator"></param>
        /// <param name="count"></param>
        public DataUtil(string head, string tail, string separator, int count)
        {
            try
            {
                this.head = System.Text.Encoding.UTF8.GetBytes(head);
                this.tail = System.Text.Encoding.UTF8.GetBytes(tail);
                this.separator = System.Text.Encoding.UTF8.GetBytes(separator);

                headCount = head.Length; tailCount = tail.Length; separatorCount = separator.Length;
                byteCount += headCount;
                byteCount += tailCount;

                byteCount += separatorCount * (count - 1);

                channelCount = count;
                types = new List<Type>(channelCount);
                typeCount = new int[channelCount];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void SetType(Type t)
        {
            try
            {
                types.Add(t);
                if (t == typeof(byte))
                {
                    typeCount[setIndex] = 1;
                    byteCount += 1;
                }
                else if (t == typeof(int))
                {
                    typeCount[setIndex] = 4;
                    byteCount += 4;
                }
                else if (t == typeof(long))
                {
                    typeCount[setIndex] = 8;
                    byteCount += 8;
                }
                else if (t == typeof(float))
                {
                    typeCount[setIndex] = 4;
                    byteCount += 4;
                }
                else if (t == typeof(double))
                {
                    typeCount[setIndex] = 8;
                    byteCount += 8;
                }
                else
                {
                    return;
                }
                setIndex++;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// 纯Hex数据格式
        /// </summary>
        /// <param name="receiveData"></param>
        /// <returns></returns>
        public double[] GetHexData(byte[] receiveData)
        {
            try
            {
                //接收数据长度错误
                if (byteCount != receiveData.Length)
                    return null;

                double[] retData = new double[channelCount];//返回的数据
                int readIndex = 0;//游标

                //读取固定字节长度转换数据
                for (int i = 0; i < channelCount; i++)
                {
                    if (typeCount[i] == 1)
                    {
                        retData[i] = receiveData[readIndex];
                        readIndex += 1;
                        continue;
                    }
                    else if (typeCount[i] == 4)
                    {
                        if (types[i] == typeof(int))
                        {
                            retData[i] = BitConverter.ToInt32(receiveData, readIndex);
                            readIndex += 4;
                        }
                        else if (types[i] == typeof(float))
                        {
                            retData[i] = BitConverter.ToSingle(receiveData, readIndex);
                            readIndex += 4;
                        }
                        continue;
                    }
                    else if (typeCount[i] == 8)
                    {
                        if (types[i] == typeof(double))
                        {
                            retData[i] = BitConverter.ToDouble(receiveData, readIndex);
                            readIndex += 8;
                        }
                        else if (types[i] == typeof(long))
                        {
                            retData[i] = BitConverter.ToInt64(receiveData, readIndex);
                            readIndex += 8;
                        }
                        continue;
                    }
                }
                return retData;
            }
            catch (Exception mes)
            {
                //日志
                Console.WriteLine(mes);
                return null;
            }
        }

        /// <summary>
        /// 字符串数据格式
        /// </summary>
        /// <param name="receiveData"></param>
        /// <returns></returns>
        public double[] GetStringData(byte[] receiveData)
        {
            try
            {
                //比较数据长度
                if (receiveData.Length != byteCount)
                    return null;
                //比较帧头
                for (int i = 0; i < headCount; i++)
                {
                    if (head[i] != receiveData[i])
                        return null;
                }
                //比较帧尾
                for (int i = 0; i < tailCount; i++)
                {
                    if (tail[i] != receiveData[byteCount - 1 - i])
                        return null;
                }

                //data1是去帧头帧尾
                byte[] data1 = new byte[byteCount - headCount - tailCount];

                //数据拷贝
                for (int i = 0; i < data1.Length; i++)
                {
                    data1[i] = receiveData[tailCount + i];
                }
                //windows平台
                double[] retData = new double[channelCount];
                //游标
                int readIndex = 0;

                ///数据解析
                for (int i = 0; i < channelCount; i++)
                {
                    if (i >= 1)
                    {
                        //检测分隔符
                        for (int r = 0; r < separatorCount; r++)
                        {
                            if (data1[readIndex] != separator[r])
                                return null;
                        }
                        readIndex += separatorCount;
                    }

                    if (typeCount[i] == 1)
                    {
                        retData[i] = data1[readIndex];
                        readIndex += 1;

                        continue;
                    }
                    else if (typeCount[i] == 4)
                    {
                        if (types[i] == typeof(int))
                        {
                            retData[i] = BitConverter.ToInt32(data1, readIndex);
                            readIndex += 4;
                        }
                        else if (types[i] == typeof(float))
                        {
                            retData[i] = BitConverter.ToSingle(data1, readIndex);
                            readIndex += 4;
                        }

                        continue;
                    }
                    else if (typeCount[i] == 8)
                    {
                        if (types[i] == typeof(double))
                        {
                            retData[i] = BitConverter.ToDouble(data1, readIndex);
                            readIndex += 8;
                        }
                        else if (types[i] == typeof(long))
                        {
                            retData[i] = BitConverter.ToInt64(data1, readIndex);
                            readIndex += 8;
                        }

                        continue;
                    }
                }
                return retData;


            }
            catch (Exception e)
            {
                //Nlog补充异常日志
                Console.WriteLine(e.Message);
                return null;
            }

        }

    }
}
