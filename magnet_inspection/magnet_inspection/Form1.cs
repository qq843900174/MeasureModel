using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

using HalconDotNet;



namespace magnet_inspection
{
    public partial class Form1 : Form
    {
        private static HWindow hwindow; //全局窗口变量
        private AlgorithmLib my_algorithmLib;
        private magnet_inspect_algorithm my_Algorithm;
        AlgorithmLib.InputLocateParam InputParam;
        AlgorithmLib.OutputLocateParam OutputParam;

        #region 限制鼠标在图像窗口内进行缩放图像操作
        /// 限制鼠标在图像窗口内进行缩放图像操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void my_MouseWheel(object sender, MouseEventArgs e)
        {
            System.Drawing.Point pt = this.Location;
            int leftBorder = hWindowControl1.Location.X;
            int rightBorder = hWindowControl1.Location.X + hWindowControl1.Size.Width;
            int topBorder = hWindowControl1.Location.Y;
            int bottomBorder = hWindowControl1.Location.Y + hWindowControl1.Size.Height;
            if (e.X > leftBorder && e.X < rightBorder && e.Y > topBorder && e.Y < bottomBorder)
            {
                MouseEventArgs newe = new MouseEventArgs(e.Button, e.Clicks,
                                                     e.X - pt.X, e.Y - pt.Y, e.Delta);
                //hWindowControl1.HMouseWheel(sender);
            }
        }
        #endregion
        public Form1()
        {
            InitializeComponent();
            my_Algorithm = new magnet_inspect_algorithm();
            my_algorithmLib = new AlgorithmLib();

            hwindow = hWindowControl1.HalconWindow;//初始化窗口变量
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.my_MouseWheel);//鼠标滑轮实现缩放

            button_Roi.Enabled = false;
            trackBar_Threshold.Enabled = false;
            button_Threshold.Enabled = false;
            button_Input_Set.Enabled = false;
            button_Do.Enabled = false;
            textBox_Threshold.Enabled = false;

            FileInfo fileInfo = new FileInfo("InputLocateParam.txt");
            if(fileInfo.Exists == false)//如果当前文件不存在则创建文件。
            {
                fileInfo.Create();
            }
        }

        

        #region 检测按钮

        public const double hv_pi = 3.1415926535;
        private void button_Do_Click(object sender, EventArgs e)
        {
            
            bool ok = false;
            ok = my_Algorithm.GetMaterialAngleAndOffset_Magnet();
            return;
        }

        #endregion
        
        //public class Form1_OutParam
        
            public HTuple ImagePath = new HTuple();
        
        
        //打开图片
        public void button_Open_Picture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "BMP文件|*.bmp*|PNG文件|*.png*|JPEG文件|*.jpg*";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ImagePath = openFileDialog1.FileName;
                HObject Image;
                HTuple ImageHeight = null, ImageWidth = null;
                HOperatorSet.GenEmptyObj(out Image);
                hwindow = hWindowControl1.HalconWindow;
                hwindow.ClearWindow();
                HOperatorSet.ReadImage(out Image, ImagePath);
                //ImagePath_state = 1;
                HOperatorSet.GetImageSize(Image, out ImageWidth, out ImageHeight);
                HOperatorSet.SetPart(hwindow, 0, 0, ImageHeight - 1, ImageWidth - 1);
                HOperatorSet.DispObj(Image, hwindow);

                button_Roi.Enabled = true;
                trackBar_Threshold.Enabled = true;
                button_Threshold.Enabled = true;
                button_Input_Set.Enabled = true;
                button_Do.Enabled = true;
                textBox_Threshold.Enabled = true;
            }
        }

        //ROI区域设置
        public void button_Roi_Click(object sender, EventArgs e)
        {
            HObject Image;
            HOperatorSet.ReadImage(out Image, ImagePath);
            HOperatorSet.DispObj(Image, hwindow);

            HTuple ROI_row1, ROI_column1, ROI_row2, ROI_column2 = new HTuple();
            hWindowControl1.Focus();
            HOperatorSet.DrawRectangle1(hWindowControl1.HalconWindow, out  ROI_row1, out  ROI_column1, 
                                                                           out  ROI_row2, out  ROI_column2);
            HRegion ROI = new HRegion();
            ROI.GenRectangle1(ROI_row1, ROI_column1, ROI_row2, ROI_column2);

            hWindowControl1.HalconWindow.SetColor("red");
            HOperatorSet.SetDraw(hWindowControl1.HalconWindow, "margin");
            hWindowControl1.HalconWindow.DispObj(ROI);

            //更新xml文件ROI区域坐标。
            double roi_row1_d, roi_column1_d, roi_row2_d, roi_column2_d;
            int roi_row1, roi_column1, roi_row2, roi_column2;

            roi_row1_d = ROI_row1;
            roi_column1_d = ROI_column1;
            roi_row2_d = ROI_row2;
            roi_column2_d = ROI_column2;

            roi_row1 = (int)roi_row1_d;
            roi_column1 = (int)roi_column1_d;
            roi_row2 = (int)roi_row2_d;
            roi_column2 = (int)roi_column2_d;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("InputLocateParam.txt");
            XmlNode rootNode = xmlDoc.FirstChild;
            XmlNodeList InputParamNodeList = rootNode.ChildNodes;
            foreach (XmlNode InputParamNode in InputParamNodeList)
            {
                if (InputParamNode.Name == "TopPt")
                {
                    InputParamNode.InnerText = roi_row1.ToString();
                    //InputParamNode.InnerText = ROI_row1.ToString();
                }

                else if (InputParamNode.Name == "LeftPt")
                {
                    InputParamNode.InnerText = roi_column1.ToString();
                    //InputParamNode.InnerText = ROI_column1.ToString();
                }

                else if (InputParamNode.Name == "BottomPt")
                {
                    InputParamNode.InnerText = roi_row2.ToString();
                    //InputParamNode.InnerText = ROI_row2.ToString();
                }

                else if (InputParamNode.Name == "RightPt")
                {
                    InputParamNode.InnerText = roi_column2.ToString();
                    //InputParamNode.InnerText = ROI_column2.ToString();
                }
            }
            xmlDoc.Save("InputLocateParam.txt");
        }

        //二值化阈值设置
        public int Threshold = new int();
        private void trackBar_Threshold_Scroll(object sender, EventArgs e)
        {
            textBox_Threshold.Text = trackBar_Threshold.Value.ToString();
            Threshold = trackBar_Threshold.Value;
        }

        private void button_Threshold_Click(object sender, EventArgs e)
        {
            //更新xml文件阈值下限。
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("InputLocateParam.txt");
            XmlNode rootNode = xmlDoc.FirstChild;
            XmlNodeList InputParamNodeList = rootNode.ChildNodes;
            foreach (XmlNode InputParamNode in InputParamNodeList)
            {
                if (InputParamNode.Name == "ThresholdMin")
                {
                    InputParamNode.InnerText = textBox_Threshold.Text;
                }
            }
            xmlDoc.Save("InputLocateParam.txt");

            Threshold_From t_From = new Threshold_From(ImagePath, Threshold);
            t_From.Text = "二值化图像";
            t_From.ShowDialog();


        }

        private void button_Input_Set_Click(object sender, EventArgs e)
        {
            Form_InputParam Ipt_From = new Form_InputParam();
            Ipt_From.ShowDialog();
        }
    }
}
