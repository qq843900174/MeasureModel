using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HalconDotNet;

namespace magnet_inspection
{
    public partial class Threshold_From : Form
    {
        public Threshold_From(HTuple imagePath, HTuple threshold)
        {
            InitializeComponent();

            HTuple ImageWidth , ImageHeight = new HTuple();
            HObject ReadImage, GrayImage, ThresholdRegion, BinImage = new HObject();

            Form1 form1 = new Form1();

            //imagePath = form1.ImagePath;
            //threshold = form1.Threshold;
            HOperatorSet.ReadImage(out ReadImage, imagePath);
            HOperatorSet.GetImageSize(ReadImage, out ImageWidth, out ImageHeight);
            HOperatorSet.Rgb1ToGray(ReadImage, out GrayImage);
            HOperatorSet.Threshold(GrayImage, out ThresholdRegion, threshold, 255);
            HOperatorSet.RegionToBin(ThresholdRegion, out BinImage, 255, 0, ImageWidth, ImageHeight);
            HOperatorSet.DispObj(BinImage, hWindowControl1.HalconWindow);
        }
    }
}
