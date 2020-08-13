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

        //图像参数
        HTuple ImageHeight = null, ImageWidth = null;


        //图像变量
        private HObject getImage            = new HObject(); //灰度图像
        private HImage backgroundImage      = null;


        //模板参数
        HObject RectModel = new HObject();
        HTuple ModelID = null;
        HTuple Row_0, Column_0, Angle_0, Score_0 = null;


        //测量工具参数
        //画直线1
        HTuple L1StartRowDraw = null, L1StartColumnDraw = null, L1EndRowDraw = null, L1EndColumnDraw = null;
        //画直线2
        HTuple L2StartRowDraw = null, L2StartColumnDraw = null, L2EndRowDraw = null, L2EndColumnDraw = null;
        //画圆1
        HTuple Circle1RowDraw = null, Circle1ColumnDraw = null, Circle1RadiusDraw = null;
        //画圆2
        HTuple Circle2RowDraw = null, Circle2ColumnDraw = null, Circle2RadiusDraw = null;
        //句柄模型
        HTuple MetrologyHandle = null;

        private AlgorithmLib my_algorithmLib;
        private magnet_inspect_algorithm my_Algorithm;
        AlgorithmLib.InputLocateParam InputParam;
        AlgorithmLib.OutputLocateParam OutputParam;

        #region 窗体中图像的操作：缩放、平移、适应窗口
        /// 窗体中图像的操作：缩放、平移、适应窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool m_IsMagnify = false;
        private double m_Factor = 1.0;
        private int m_MouseX0 = 0;
        private int m_MouseY0 = 0;
        private int m_MouseX1 = 0;
        private int m_MouseY1 = 0;
        private void Image_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!hWindowControl1.ClientRectangle.Contains(e.Location))
            {
                return;
            }

            if (getImage.CountObj() <= 0)
            {
                return;
            }

            //Min--0.1 Max--2.0
            if (e.Delta > 0)//Up
            {
                m_Factor += 0.1;
            }
            else//Down
            {
                m_Factor -= 0.1;
            }

            if (m_Factor < 0.1)
            {
                m_Factor = 0.1;
            }
            if (m_Factor > 2.0)
            {
                m_Factor = 2.0;
            }

            HTuple ImgW = 0, ImgH = 0, ScaledW = 0, ScaledH = 0;
            HOperatorSet.GetImageSize(getImage, out ImgW, out ImgH);
            ScaledW = ImgW * m_Factor;
            ScaledH = ImgH * m_Factor;
            if (ScaledW > hWindowControl1.Size.Width || ScaledH > hWindowControl1.Size.Height)
            {
                m_IsMagnify = true;
            }
            else
            {
                m_IsMagnify = false;
            }

            hWindowControl1.HalconWindow.ClearWindow();
            if (!m_IsMagnify)
            {
                SetPart();
            }

            DispZoomImage(m_Factor, getImage);

            return;
        }
        //适应窗口
        private void SetPart()
        {
            int row, col;

            int w = hWindowControl1.Size.Width;
            int h = hWindowControl1.Size.Height;

            col = int.Parse(w.ToString()) ;
            row = int.Parse(h.ToString()) ;
            hWindowControl1.HalconWindow.SetPart(0, 0, row-1, col-1);
            hWindowControl1.HalconWindow.SetLineWidth(1.0);

            return;
        }
        //缩放图像
        private void DispZoomImage(double Factor, HObject SrcObj)
        {
            HObject DrawObj;

            if (Factor <= 0.0 || Factor >= 4.0)
            {
                return;
            }

            if (SrcObj.CountObj() <= 0)
            {
                return;
            }

            HOperatorSet.ZoomImageFactor(SrcObj, out DrawObj, Factor, Factor, "bicubic");

            hWindowControl1.HalconWindow.DispObj(DrawObj);

            return;
        }
        //鼠标中键点下
        private void Image_MouseDown(object sender, MouseEventArgs e)
        {
            if (!hWindowControl1.ClientRectangle.Contains(e.Location))
            {
                return;
            }
            if (e.Button == MouseButtons.Middle)
            {
                m_MouseX0 = e.Location.Y;
                m_MouseY0 = e.Location.X;
            }

            return;
        }

        private void Image_MouseUp(object sender, MouseEventArgs e)
        {
            if (!hWindowControl1.ClientRectangle.Contains(e.Location))
            {
                return;
            }
            if (e.Button == MouseButtons.Middle)
            {
                int row1 = 0, col1 = 0, row2 = 0, col2 = 0;
                double dbRowMove = 0.0, dbColMove = 0.0;

                if (m_MouseX0 == 0 || m_MouseY0 == 0)
                {
                    return;
                }

                m_MouseX1 = e.Location.Y;
                m_MouseY1 = e.Location.X;
                dbRowMove = m_MouseX0 - m_MouseX1;//计算光标在X轴拖动的距离
                dbColMove = m_MouseY0 - m_MouseY1;//计算光标在Y轴拖动的距离

                hWindowControl1.HalconWindow.GetPart(out row1, out col1, out row2, out col2);//计算HWindow控件在当前状态下显示图像的位置
                hWindowControl1.HalconWindow.SetPart((int)(row1 + dbRowMove), (int)(col1 + dbColMove),
                    (int)(row2 + dbRowMove), (int)(col2 + dbColMove));//根据拖动距离调整HWindows控件显示图像的位置

                hWindowControl1.HalconWindow.ClearWindow();
                DispZoomImage(m_Factor, getImage);
            }

            return;
        }

        private void buttonAdapt_Click(object sender, EventArgs e)
        {
            if (getImage.CountObj() <= 0)
            {
                return;
            }
            hWindowControl1.HalconWindow.ClearWindow();
            HOperatorSet.GetImageSize(getImage, out ImageWidth, out ImageHeight);
            HOperatorSet.SetPart(hwindow, 0, 0, ImageHeight - 1, ImageWidth - 1);
            HOperatorSet.DispObj(getImage, hwindow);
            return;
        }
        #endregion
        public Form1()
        {
            InitializeComponent();
            my_Algorithm = new magnet_inspect_algorithm();
            my_algorithmLib = new AlgorithmLib();

            HOperatorSet.GenEmptyObj(out getImage);
            RectModel = null;
            hwindow = hWindowControl1.HalconWindow;//初始化窗口变量


            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Image_MouseWheel);//鼠标滑轮实现缩放
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Image_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Image_MouseUp);

            button_Roi.Enabled = false;
            button_Threshold.Enabled = false;
            button_Input_Set.Enabled = false;
            button_Do.Enabled = false;
            buttonStopAcqGrab.Enabled = false;

            buttonAcqGrab.Enabled = true;

            trackBar_Threshold.Enabled = false;

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
            //ok = my_Algorithm.GetMaterialAngleAndOffset_Magnet();
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
                HOperatorSet.GenEmptyObj(out Image);
                hwindow = hWindowControl1.HalconWindow;
                hwindow.ClearWindow();
                HOperatorSet.ReadImage(out Image, ImagePath);
                HOperatorSet.Rgb1ToGray(Image, out getImage);
                //ImagePath_state = 1;
                HOperatorSet.GetImageSize(getImage, out ImageWidth, out ImageHeight);
                HOperatorSet.SetPart(hwindow, 0, 0, ImageHeight - 1, ImageWidth - 1);
                HOperatorSet.DispObj(getImage, hwindow);

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
            HOperatorSet.DispObj(getImage, hwindow);

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

        //显示二值化图
        private void button_Threshold_Click(object sender, EventArgs e)
        {
            Threshold = int.Parse(textBox_Threshold.Text);
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

        //打开输入设置参数界面
        private void button_Input_Set_Click(object sender, EventArgs e)
        {
            Form_InputParam Ipt_From = new Form_InputParam();
            Ipt_From.ShowDialog();
        }

        //模板选取
        private void buttonSetModel_Click(object sender, EventArgs e)
        {
            HTuple RectModelRow, RectModelColumn, RectModelPhi, RectModelL1, RectModelRowL2 = null;

            this.tabControl1.SelectedIndex = 0;
            hWindowControl1.HalconWindow.ClearWindow();
            HOperatorSet.DispObj(getImage, hwindow);
            hWindowControl1.Focus();

            hWindowControl1.HalconWindow.SetColor("yellow");
            HOperatorSet.DrawRectangle2Mod(hwindow, 240, 320, 0, 90, 90, out RectModelRow, out RectModelColumn, 
                                                                         out RectModelPhi, out RectModelL1, out RectModelRowL2);
            HOperatorSet.GenRectangle2(out RectModel, RectModelRow, RectModelColumn, RectModelPhi, RectModelL1, RectModelRowL2);

            hWindowControl1.HalconWindow.SetColor("green");
            HOperatorSet.SetDraw(hWindowControl1.HalconWindow, "margin");
            hWindowControl1.HalconWindow.DispObj(RectModel);

        }

        //创建模板
        private void buttonCreateModel_Click(object sender, EventArgs e)
        {
            HObject ModelImage, ModelImages, ModelRegion, ModelRegions, BlackImage;
            HOperatorSet.GenEmptyObj(out ModelImage);

            if (RectModel != null)
            {
                this.tabControl1.SelectedIndex = 0;
                hWindowControl1.HalconWindow.ClearWindow();
                HOperatorSet.DispObj(getImage, hwindow);

                Threshold = int.Parse(textBox_Threshold.Text);
                HOperatorSet.ReduceDomain(getImage, RectModel, out ModelImage);
                HOperatorSet.Threshold(ModelImage, out ModelRegion, Threshold, 255);
                HOperatorSet.ReduceDomain(ModelImage, ModelRegion, out ModelImage);
                HOperatorSet.GenImageConst(out BlackImage, "byte", ImageWidth, ImageHeight);
                HOperatorSet.AddImage(BlackImage, ModelImage,out ModelImage, 1, 0);
                HOperatorSet.ReduceDomain(ModelImage, RectModel, out ModelImage);

                HOperatorSet.InspectShapeModel(ModelImage, out ModelImages, out ModelRegions, 4, 20);
                HOperatorSet.DispObj(ModelRegions, hwindow);
                HOperatorSet.CreateShapeModel(ModelImage, "auto", 0, (new HTuple(360)).TupleRad(), "auto", "auto", "use_polarity", "auto", "auto", out ModelID);

                GC.Collect();
            }
            else
            {
                MessageBox.Show("请选取模板区域！");
                return;
            }

        }

        //模板模拟定位
        private void buttonTestModel_Click(object sender, EventArgs e)
        {
            int TopPt = 0, LeftPt = 0, BottomPt = 0, RightPt = 0;
            HObject ROI = null, SearchImage = null;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load("InputLocateParam.txt");
                XmlNode rootNode = xmlDoc.FirstChild;
                XmlNodeList InputParamNodeList = rootNode.ChildNodes;
                foreach (XmlNode InputParamNode in InputParamNodeList)
                {
                    if (InputParamNode.Name == "TopPt")
                    {
                         TopPt = Int32.Parse(InputParamNode.InnerText);
                    }
                    else if (InputParamNode.Name == "LeftPt")
                    {
                         LeftPt = Int32.Parse(InputParamNode.InnerText);
                    }
                    else if (InputParamNode.Name == "BottomPt")
                    {
                         BottomPt = Int32.Parse(InputParamNode.InnerText);
                    }
                    else if (InputParamNode.Name == "RightPt")
                    {
                         RightPt = Int32.Parse(InputParamNode.InnerText);
                    }
                }
                if (ModelID != null)
                {
                    this.tabControl1.SelectedIndex = 0;
                    hWindowControl1.HalconWindow.ClearWindow();
                    HOperatorSet.DispObj(getImage, hwindow);
                    HOperatorSet.GenRectangle1(out ROI, (HTuple)TopPt, (HTuple)LeftPt, (HTuple)BottomPt, (HTuple)RightPt);
                    HOperatorSet.ReduceDomain(getImage, ROI, out SearchImage);
                    HOperatorSet.FindShapeModel(SearchImage, ModelID, 0, (new HTuple(360)), 0.5, 1, 0.9, "least_squares", 0, 0.9, 
                                                out Row_0, out Column_0, out Angle_0, out Score_0);

                    ModelRow_textBox.Text = Row_0.TupleString("3.2f");
                    ModelColumn_textBox.Text = Column_0.TupleString("3.2f");
                    Angle_0 = Angle_0.TupleDeg();
                    ModelAngle_textBox.Text = Angle_0.TupleString("3.2f") + "°";

                    GC.Collect();
                }
                else
                {
                    MessageBox.Show("请先创建模板！");
                    return;
                }
            }
            catch (HalconException ex)
            {
                string str, expMsg;
                HTuple expTpl;
                ex.ToHTuple(out expTpl);
                expMsg = expTpl[1].S;
                str = "Halcon Exception:";
                str += expMsg;
                MessageBox.Show(str);
                return;
            }
        }

        //保存模板到本地
        private void buttonSaveModel_Click(object sender, EventArgs e)
        {
            if (ModelID != null)
            { 
                if (File.Exists(Directory.GetCurrentDirectory() + @"/MagnetModel.shm"))
                {
                    File.Delete(Directory.GetCurrentDirectory() + @"/MagnetModel.shm");
                    HOperatorSet.WriteShapeModel(ModelID, Directory.GetCurrentDirectory() + @"/MagnetModel.shm");
                    MessageBox.Show("保存模板成功！");
                }
                else
                {
                    HOperatorSet.WriteShapeModel(ModelID, Directory.GetCurrentDirectory() + @"/MagnetModel.shm");
                    MessageBox.Show("保存模板成功！");
                }
            }
            else
            {
                MessageBox.Show("请先创建模板！");
                return;
            }
        }

        //测量直线1
        private void buttonDrawLine1_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
            hWindowControl1.HalconWindow.ClearWindow();
            HOperatorSet.DispObj(getImage, hwindow);
            hWindowControl1.Focus();
            HOperatorSet.SetLineWidth(hwindow, 2);
            HOperatorSet.SetDraw(hwindow, "margin");

            HObject Line1;
            HOperatorSet.GenEmptyObj(out Line1);
            Line1.Dispose();

            HOperatorSet.SetColor(hwindow, "yellow");
            HOperatorSet.DrawLineMod(hwindow, ImageHeight/2 , ImageWidth/2 - 50, ImageHeight / 2 , ImageWidth / 2 + 50, 
                                            out L1StartRowDraw, out L1StartColumnDraw, out L1EndRowDraw, out L1EndColumnDraw);
            HOperatorSet.SetColor(hwindow, "green");
            HOperatorSet.GenRegionLine(out Line1, L1StartRowDraw, L1StartColumnDraw, L1EndRowDraw, L1EndColumnDraw);
            HOperatorSet.DispObj(Line1, hwindow);
        }

        //测量直线2
        private void buttonDrawLine2_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
            //hWindowControl1.HalconWindow.ClearWindow();
            //HOperatorSet.DispObj(getImage, hwindow);
            hWindowControl1.Focus();
            HOperatorSet.SetLineWidth(hwindow, 2);
            HOperatorSet.SetDraw(hwindow, "margin");

            HObject Line2;
            HOperatorSet.GenEmptyObj(out Line2);
            Line2.Dispose();

            HOperatorSet.SetColor(hwindow, "yellow");
            HOperatorSet.DrawLineMod(hwindow, ImageHeight / 2 - 50, ImageWidth / 2 , ImageHeight / 2 + 50, ImageWidth / 2,
                                            out L2StartRowDraw, out L2StartColumnDraw, out L2EndRowDraw, out L2EndColumnDraw);
            HOperatorSet.SetColor(hwindow, "green");
            HOperatorSet.GenRegionLine(out Line2, L2StartRowDraw, L2StartColumnDraw, L2EndRowDraw, L2EndColumnDraw);
            HOperatorSet.DispObj(Line2, hwindow);
        }

        //测量圆或圆弧1
        private void buttonDrawCircle1_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
            //hWindowControl1.HalconWindow.ClearWindow();
            //HOperatorSet.DispObj(getImage, hwindow);
            hWindowControl1.Focus();
            HOperatorSet.SetLineWidth(hwindow, 2);
            HOperatorSet.SetDraw(hwindow, "margin");

            HObject Circle1;
            HOperatorSet.GenEmptyObj(out Circle1);
            Circle1.Dispose();

            HOperatorSet.SetColor(hwindow, "yellow");
            HOperatorSet.DrawCircleMod(hwindow, ImageHeight / 2 , ImageWidth / 2, 200,
                                            out Circle1RowDraw, out Circle1ColumnDraw, out Circle1RadiusDraw);
            HOperatorSet.SetColor(hwindow, "green");
            HOperatorSet.GenCircle(out Circle1, Circle1RowDraw, Circle1ColumnDraw, Circle1RadiusDraw);
            HOperatorSet.DispObj(Circle1, hwindow);
        }

        //测量圆或圆弧2
        private void buttonDrawCircle2_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
            //hWindowControl1.HalconWindow.ClearWindow();
            //HOperatorSet.DispObj(getImage, hwindow);
            hWindowControl1.Focus();
            HOperatorSet.SetLineWidth(hwindow, 2);
            HOperatorSet.SetDraw(hwindow, "margin");

            HObject Circle2;
            HOperatorSet.GenEmptyObj(out Circle2);
            Circle2.Dispose();

            HOperatorSet.SetColor(hwindow, "yellow");
            HOperatorSet.DrawCircleMod(hwindow, ImageHeight / 2, ImageWidth / 2, 200,
                                            out Circle2RowDraw, out Circle2ColumnDraw, out Circle2RadiusDraw);
            HOperatorSet.SetColor(hwindow, "green");
            HOperatorSet.GenCircle(out Circle2, Circle2RowDraw, Circle2ColumnDraw, Circle2RadiusDraw);
            HOperatorSet.DispObj(Circle2, hwindow);
        }

        //创建测量工具
        private void buttonCreateMetrology_Click(object sender, EventArgs e)
        {
            try
            {
                if (L1StartRowDraw == null || L1StartColumnDraw == null || L1EndRowDraw == null || L1EndColumnDraw == null )
                {
                    MessageBox.Show("请先画直线1");
                    return;
                }
                else if (L2StartRowDraw == null || L2StartColumnDraw == null || L2EndRowDraw == null || L2EndColumnDraw == null )
                {
                    MessageBox.Show("请先画直线2");
                    return;
                }
                else if (Circle1RowDraw == null || Circle1ColumnDraw == null || Circle1RadiusDraw == null )
                {
                    MessageBox.Show("请先画圆1");
                    return;
                }
                else if (Circle2RowDraw == null || Circle2ColumnDraw == null || Circle2RadiusDraw == null )
                {
                    MessageBox.Show("请先画圆2");
                    return;
                }

                //创建测量模型
                HOperatorSet.CreateMetrologyModel(out MetrologyHandle);

                //设置测量对象的图像大小
                HOperatorSet.SetMetrologyModelImageSize(MetrologyHandle, ImageWidth, ImageHeight);

                //添加测量直线对象到测量模型中
                HTuple Circle1Index = null, Circle2Index = null, Line1Index = null, Line2Index = null;
                HTuple Circle1Param = null, Circle2Param = null, Line1Param = null, Line2Param = null;

                Line1Param = new HTuple();
                Line1Param = Line1Param.TupleConcat(L1StartRowDraw);
                Line1Param = Line1Param.TupleConcat(L1StartColumnDraw);
                Line1Param = Line1Param.TupleConcat(L1EndRowDraw);
                Line1Param = Line1Param.TupleConcat(L1EndColumnDraw);
                Line2Param = new HTuple();
                Line2Param = Line2Param.TupleConcat(L2StartRowDraw);
                Line2Param = Line2Param.TupleConcat(L2StartColumnDraw);
                Line2Param = Line2Param.TupleConcat(L2EndRowDraw);
                Line2Param = Line2Param.TupleConcat(L2EndColumnDraw);
                Circle1Param = new HTuple();
                Circle1Param = Circle1Param.TupleConcat(Circle1RowDraw);
                Circle1Param = Circle1Param.TupleConcat(Circle1ColumnDraw);
                Circle1Param = Circle1Param.TupleConcat(Circle1RadiusDraw);
                Circle2Param = new HTuple();
                Circle2Param = Circle2Param.TupleConcat(Circle2RowDraw);
                Circle2Param = Circle2Param.TupleConcat(Circle2ColumnDraw);
                Circle2Param = Circle2Param.TupleConcat(Circle2RadiusDraw);

                HOperatorSet.AddMetrologyObjectGeneric(MetrologyHandle, "circle", Circle1Param, 20, 5, 1, 30, new HTuple(), new HTuple(), out Circle1Index);
                HOperatorSet.AddMetrologyObjectGeneric(MetrologyHandle, "circle", Circle2Param, 20, 5, 1, 30, new HTuple(), new HTuple(), out Circle2Index);
                HOperatorSet.AddMetrologyObjectGeneric(MetrologyHandle, "line", Line1Param, 20, 5, 1, 30, new HTuple(), new HTuple(), out Line1Index);
                HOperatorSet.AddMetrologyObjectGeneric(MetrologyHandle, "line", Line2Param, 20, 5, 1, 30, new HTuple(), new HTuple(), out Line2Index);



                //获取测量模型里的模型轮廓
                HObject ModelContour;
                HOperatorSet.GenEmptyObj(out ModelContour);
                ModelContour.Dispose();
                HOperatorSet.GetMetrologyObjectModelContour(out ModelContour, MetrologyHandle, "all", 1.5);

                //获取测量模型里的测量区域
                HObject MeasureContour;
                HOperatorSet.GenEmptyObj(out MeasureContour);
                MeasureContour.Dispose();

                HTuple Row = null, Column = null;
                HOperatorSet.GetMetrologyObjectMeasures(out MeasureContour, MetrologyHandle,
                                                       ((((Circle1Index.TupleConcat(Circle2Index))).TupleConcat(Line1Index))).TupleConcat(Line2Index) ,
                                                       "all", out Row, out Column);


                //显示图像及轮廓
                this.tabControl1.SelectedIndex = 0;
                hWindowControl1.HalconWindow.ClearWindow();
                HOperatorSet.DispObj(getImage, hwindow);
                HOperatorSet.DispObj(ModelContour, hwindow);
                HOperatorSet.DispObj(MeasureContour, hwindow);

                //* 设置测量对象的参考坐标系原点在模板坐标位置
                /*
                HTuple TempleteRow = null, TempleteColumn = null, TempleteAngle = null;
                TempleteRow = double.Parse(this.ModelRow_textBox.Text);
                TempleteColumn = double.Parse(this.ModelColumn_textBox.Text);
                TempleteAngle = double.Parse(this.ModelAngle_textBox.Text);

                HOperatorSet.SetMetrologyModelParam(MetrologyHandle, "reference_system", 
                                                   ((TempleteRow.TupleConcat(TempleteColumn))).TupleConcat(TempleteAngle));
                */
                //HOperatorSet.WriteMetrologyModel(MetrologyHandle, Directory.GetCurrentDirectory() + @"/MetrologyHandle.mtr");

            }
            catch (HalconException hex)
            {
                MessageBox.Show(hex.GetErrorMessage(), "HALCON Exception:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Windows Exception:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //清空测量工具
        private void buttonClearMetrology_Click(object sender, EventArgs e)
        {
            hWindowControl1.HalconWindow.ClearWindow();
            HOperatorSet.DispObj(getImage, hwindow);

            L1StartRowDraw = null; L1StartColumnDraw = null; L1EndRowDraw = null; L1EndColumnDraw = null;
            L2StartRowDraw = null; L2StartColumnDraw = null; L2EndRowDraw = null; L2EndColumnDraw = null;
            Circle1RowDraw = null; Circle1ColumnDraw = null; Circle1RadiusDraw = null;
            Circle2RowDraw = null; Circle2ColumnDraw = null; Circle2RadiusDraw = null;
        }

        //测量工具模拟测量
        private void buttonTestMetrology_Click(object sender, EventArgs e)
        {
            int TopPt = 0, LeftPt = 0, BottomPt = 0, RightPt = 0;
            HObject ROI = null, SearchImage = null, ResultContour = null;
            HTuple Parameter = new HTuple();
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load("InputLocateParam.txt");
                XmlNode rootNode = xmlDoc.FirstChild;
                XmlNodeList InputParamNodeList = rootNode.ChildNodes;
                foreach (XmlNode InputParamNode in InputParamNodeList)
                {
                    if (InputParamNode.Name == "TopPt")
                    {
                        TopPt = Int32.Parse(InputParamNode.InnerText);
                    }
                    else if (InputParamNode.Name == "LeftPt")
                    {
                        LeftPt = Int32.Parse(InputParamNode.InnerText);
                    }
                    else if (InputParamNode.Name == "BottomPt")
                    {
                        BottomPt = Int32.Parse(InputParamNode.InnerText);
                    }
                    else if (InputParamNode.Name == "RightPt")
                    {
                        RightPt = Int32.Parse(InputParamNode.InnerText);
                    }
                }
                if (MetrologyHandle != null)
                {
                    this.tabControl1.SelectedIndex = 0;
                    hWindowControl1.HalconWindow.ClearWindow();
                    HOperatorSet.DispObj(getImage, hwindow);
                    HOperatorSet.GenRectangle1(out ROI, (HTuple)TopPt, (HTuple)LeftPt, (HTuple)BottomPt, (HTuple)RightPt);
                    HOperatorSet.ReduceDomain(getImage, ROI, out SearchImage);
                    HOperatorSet.ApplyMetrologyModel(SearchImage, MetrologyHandle);

                    HOperatorSet.GetMetrologyObjectResult(MetrologyHandle, "all", "all", "result_type", "all_param", out Parameter);

                    HOperatorSet.GenEmptyObj(out ResultContour);
                    ResultContour.Dispose();
                    HOperatorSet.GetMetrologyObjectResultContour(out ResultContour, MetrologyHandle, "all", "all", 1);

                    HOperatorSet.SetColor(hwindow, "green");
                    HOperatorSet.DispObj(ResultContour, hwindow);

                    GC.Collect();
                }
                else
                {
                    MessageBox.Show("请先创建测量工具！");
                    return;
                }
            }
            catch (HalconException ex)
            {
                string str, expMsg;
                HTuple expTpl;
                ex.ToHTuple(out expTpl);
                expMsg = expTpl[1].S;
                str = "Halcon Exception:";
                str += expMsg;
                MessageBox.Show(str);
                return;
            }
        }

        //保存测量工具到本地
        private void buttonSaveMetrology_Click(object sender, EventArgs e)
        {
            if (MetrologyHandle != null)
            {
                if (File.Exists(Directory.GetCurrentDirectory() + @"/MetrologyHandle.mtr"))
                {
                    File.Delete(Directory.GetCurrentDirectory() + @"/MetrologyHandle.mtr");
                    HOperatorSet.WriteShapeModel(ModelID, Directory.GetCurrentDirectory() + @"/MetrologyHandle.mtr");
                    MessageBox.Show("保存测量工具成功！");
                }
                else
                {
                    HOperatorSet.WriteShapeModel(ModelID, Directory.GetCurrentDirectory() + @"/MetrologyHandle.mtr");
                    MessageBox.Show("保存测量工具成功！");
                }
            }
            else
            {
                MessageBox.Show("请先创建模板！");
                return;
            }
        }
    }
}
