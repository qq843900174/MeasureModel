using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace magnet_inspection
{

    public partial class Form_InputParam : Form
    {
        public Form_InputParam()
        {
            InitializeComponent();

            //XmlDocument专门用来解析xml文档的
            XmlDocument xmlDoc = new XmlDocument();
            //选择要加载解析的xml文档的名字
            xmlDoc.Load("InputLocateParam.txt");
            //得到根结点
            XmlNode rootNode = xmlDoc.FirstChild;//获取第一个节点

            //得到根节点下面的子节点的集合
            XmlNodeList InputParamNodeList = rootNode.ChildNodes;//获取当前结点下面的所有子节点

            foreach(XmlNode InputParamNode in InputParamNodeList)
            {
                if(InputParamNode.Name == "ThresholdMin")//通过Name属性可以获取一个节点的名字
                {
                    int ThresholdMin = Int32.Parse(InputParamNode.InnerText);//获取节点内部的文本
                    textBox_Thresmin.Text = ThresholdMin.ToString();
                }

                else if (InputParamNode.Name == "ThresholdMax")
                {
                    int ThresholdMax = Int32.Parse(InputParamNode.InnerText);
                    textBox_Thresmax.Text = ThresholdMax.ToString();
                }

                else if (InputParamNode.Name == "TopPt")
                {
                    int TopPt = Int32.Parse(InputParamNode.InnerText);
                    textBox_TopPt.Text = TopPt.ToString();
                }

                else if (InputParamNode.Name == "LeftPt")
                {
                    int LeftPt = Int32.Parse(InputParamNode.InnerText);
                    textBox_LeftPt.Text = LeftPt.ToString();
                }

                else if (InputParamNode.Name == "BottomPt")
                {
                    int BottomPt = Int32.Parse(InputParamNode.InnerText);
                    textBox_BottomPt.Text = BottomPt.ToString();
                }

                else if (InputParamNode.Name == "RightPt")
                {
                    int RightPt = Int32.Parse(InputParamNode.InnerText);
                    textBox_RightPt.Text = RightPt.ToString();
                }

                else if (InputParamNode.Name == "MaterialW")
                {
                    double MaterialW = Double.Parse(InputParamNode.InnerText);
                    textBox_MaterialW.Text = MaterialW.ToString();
                }

                else if (InputParamNode.Name == "MaterialH")
                {
                    double MaterialH = Double.Parse(InputParamNode.InnerText);
                    textBox_MaterialH.Text = MaterialH.ToString();
                }
            }
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认修改输入参数？", "确认窗口", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //XmlDocument专门用来解析xml文档的
                XmlDocument xmlDoc = new XmlDocument();
                //选择要加载解析的xml文档的名字
                xmlDoc.Load("InputLocateParam.txt");
                //得到根结点
                XmlNode rootNode = xmlDoc.FirstChild;//获取第一个节点

                //得到根节点下面的子节点的集合
                XmlNodeList InputParamNodeList = rootNode.ChildNodes;//获取当前结点下面的所有子节点

                foreach (XmlNode InputParamNode in InputParamNodeList)
                {
                    if (InputParamNode.Name == "ThresholdMin")//通过Name属性可以获取一个节点的名字
                    {
                        InputParamNode.InnerText = textBox_Thresmin.Text;
                    }

                    else if (InputParamNode.Name == "ThresholdMax")
                    {
                        InputParamNode.InnerText = textBox_Thresmax.Text;
                    }

                    else if (InputParamNode.Name == "TopPt")
                    {
                        InputParamNode.InnerText = textBox_TopPt.Text;
                    }

                    else if (InputParamNode.Name == "LeftPt")
                    {
                        InputParamNode.InnerText = textBox_LeftPt.Text;
                    }

                    else if (InputParamNode.Name == "BottomPt")
                    {
                        InputParamNode.InnerText = textBox_BottomPt.Text;
                    }

                    else if (InputParamNode.Name == "RightPt")
                    {
                        InputParamNode.InnerText = textBox_RightPt.Text;
                    }

                    else if (InputParamNode.Name == "MaterialW")
                    {
                        InputParamNode.InnerText = textBox_MaterialW.Text;
                    }

                    else if (InputParamNode.Name == "MaterialH")
                    {
                        InputParamNode.InnerText = textBox_MaterialH.Text;
                    }
                }
                //保存更新内容
                xmlDoc.Save("InputLocateParam.txt");
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
