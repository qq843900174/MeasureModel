using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HalconDotNet;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

//using mojelib.camera;

namespace magnet_inspection
{
    public class AlgorithmLib
    {
        //输入结构参数
        public class InputLocateParam
        {
            public /*IntPtr*/byte[] ImagePtr;//图像指针
            public int ThresholdMin;//分割阈值下限
            public int ThresholdMax;//分割阈值上限
            public int ImageW;//图像宽度
            public int ImageH;//图像高度
            public int LeftPt;//图像ROI左上角点横坐标
            public int TopPt;//图像ROI左上角点纵坐标
            public int RightPt;//图像ROI右下角点横坐标
            public int BottomPt;//图像ROI右下角点纵坐标
            public double MaterialW;//物料宽度尺寸
            public double MaterialH;//物料高度尺寸
        }

        //输出参数结构
        public class OutputLocateparam
        {
            public int ErrorCode;//错误代码
            public string ExceptionString;//Halcon异常错误信息
            public double RotateAngle;//物料角度
            public double OffsetX;//物料X方向偏移
            public double OffsetY;//物料Y方向偏移
            public double CenterX;//物料中心横坐标
            public double CenterY;//物料中心纵坐标
            public int SpanTime;//耗时

            public double RectX;//物料外接矩形中心点横坐标
            public double RectY;//物料外接矩形中心点纵坐标
            public double RectWidth;//物料外接矩形宽度
            public double RectHeight;//物料外接矩形高度
            public double RectAngle;//物料外接矩形角度
        }

        //internal类：只对相同程序集开放。
        //传入输入图像数据给图像指针
        static internal IntPtr ArrayToIntptr(byte[] source)
        {
            //判断图像源是否为空
            if (source == null)
                return IntPtr.Zero;

            //传入指针
            byte[] da = source;
            IntPtr ptr = Marshal.AllocHGlobal(da.Length);
            Marshal.Copy(da, 0, ptr, da.Length);
            return ptr;
        }

        //释放指针内存
        static internal void FreeIntptr(IntPtr freePtr)
        {
            if (freePtr == IntPtr.Zero)
            {
                return;
            }

            Marshal.FreeHGlobal(freePtr);
            freePtr = IntPtr.Zero;

            return;
        }

        //保存错误图像
        static internal void SaveErrorImage(string strPath, HObject orgObj, HObject writeRgn, bool isXld, HTuple tmpW, HTuple tmpH,
            int minHold, int maxHold, int errCode)
        {
            //移除strPath的前导和尾部的空白字符
            strPath.Trim();
            if (strPath == "")
            {
                return;
            }

            //             if (tmpW < 4 || tmpH < 4)
            //             {
            //                 return;
            //             }

            string date;
            DateTime tnow = DateTime.Now;
            date = tnow.ToString("yyyy-MM-dd");
            strPath = strPath + date + "\\";

            //确定给定路径是否引用磁盘目录，没有则创建
            if (!Directory.Exists(strPath))
            {
                Directory.CreateDirectory(strPath);
            }

            try
            {
                //原图文件名，二值图像文件名，名称，日期
                string strfileorg, strfilebin, name, dt;
                DateTime now = DateTime.Now;
                dt = now.ToString("yyyy-MM-dd_HH-mm-ss-fff");

                if (orgObj.CountObj() > 0)
                {
                    name = dt + "_" + "orgImage" + "_" + minHold.ToString() + "_" + maxHold.ToString() + "_" + "Err" + errCode.ToString() + ".jpeg";
                    strfileorg = strPath + name;

                    HOperatorSet.WriteImage(orgObj, "jpeg", 0, strfileorg);
                }

                if (false)//writeRgn.CountObj() > 0)
                {
                    name = dt + "_" + "errRegion" + "_" + minHold.ToString() + "_" + maxHold.ToString() + "_" + "Err" + errCode.ToString() + ".jpeg";
                    strfilebin = strPath + name;

                    if (isXld)
                    {
                        HOperatorSet.GenRegionContourXld(writeRgn, out writeRgn, "margin");
                    }

                    HObject binObj;
                    HOperatorSet.RegionToBin(writeRgn, out binObj, 255, 0, tmpW, tmpH);
                    HOperatorSet.WriteImage(binObj, "jpeg", 0, strfilebin);
                }

            }
            catch (HOperatorException e)
            {
                string str, expMsg;
                HTuple expTpl;
                e.ToHTuple(out expTpl);
                expMsg = expTpl[1].S;
                str = "SaveErrorImage#Halcon Exception:\r\n";
                str += expMsg;
                MessageBox.Show(str);

                return;
            }

            return;
        }

        static internal void WriteLog(string strPath, string msg, bool isWrite = true)
        {
            try
            {
                if (!isWrite)
                {
                    return;
                }

                strPath.Trim();
                msg.Trim();
                if (strPath == "" || msg == "")
                {
                    return;
                }

                string strfile, dt, date, strWrite, strTn = "\r\n";
                DateTime now = DateTime.Now;
                dt = now.ToString("yyyy.MM.dd_HH:mm:ss:fff");
                date = now.ToString("yyyy-MM-dd");
                strfile = strPath + date + ".txt";
                strWrite = msg + "      " + dt;

                if (!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                }

                if (!File.Exists(strfile))
                {
                    FileStream fsWrite = new FileStream(strfile, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fsWrite);

                    sw.Write(strWrite);
                    sw.Write(strTn);

                    sw.Flush();
                    sw.Close();

                    fsWrite.Close();
                }
                else
                {
                    FileStream fsWrite = new FileStream(strfile, FileMode.Open, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fsWrite);

                    fsWrite.Position = fsWrite.Length;

                    sw.Write(strWrite);
                    sw.Write(strTn);

                    sw.Flush();
                    sw.Close();

                    fsWrite.Close();
                }
            }
            catch (Exception e)
            {
                return;
            }

            return;
        }
    }
}

