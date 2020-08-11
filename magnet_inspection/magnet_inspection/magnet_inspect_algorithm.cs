using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HalconDotNet;
using System.IO;

namespace magnet_inspection
{
    public class magnet_inspect_algorithm : AlgorithmLib
    {
        
        public bool GetMaterialAngleAndOffset_Magnet(InputLocateParam IptParam, ref OutputLocateparam OptParam)
        {
            //计算时间，开始时间。
            DateTime timeStart = System.DateTime.Now;

            //输出参数
            //物料中心、角度输出参数
            OptParam.RotateAngle = 0.0;
            OptParam.OffsetX = 0.0;
            OptParam.OffsetY = 0.0;
            OptParam.CenterX = 0.0;
            OptParam.CenterY = 0.0;

            //物料最小外接矩形输出参数
            OptParam.RectX = 0.0;
            OptParam.RectY = 0.0;
            OptParam.RectAngle = 0.0;
            OptParam.RectWidth = 0.0;
            OptParam.RectHeight = 0.0;

            //程序运行输出参数
            OptParam.ErrorCode = 0;
            OptParam.ExceptionString = "";
            OptParam.SpanTime = 0;


            try
            {
                //错误1：判断输入图像是否传入。
                if (IptParam.ImagePtr == null || IptParam.ImagePtr.Length <= 0)
                {
                    OptParam.ErrorCode = 1;
                    return false;
                }

                //错误2：判断输入二值化阈值是否输入正确。
                if ((IptParam.ThresholdMin < 0 || IptParam.ThresholdMin > 254)
                    || (IptParam.ThresholdMax < 1 || IptParam.ThresholdMax > 255)
                    || (IptParam.ThresholdMin >= IptParam.ThresholdMax))
                {
                    OptParam.ErrorCode = 2;
                    return false;
                }

                //错误3：判断图像大小或ROI区域输入是否正确。
                if ((IptParam.ImageW < 4 || IptParam.ImageH < 4)
                    || (IptParam.LeftPt < 0 || IptParam.LeftPt >= IptParam.RightPt)
                    //多余|| (IptParam.RightPt <= IptParam.LeftPt 
                    || (IptParam.RightPt > IptParam.ImageW)
                    || (IptParam.TopPt < 0 || IptParam.TopPt >= IptParam.BottomPt)
                    //多余|| (IptParam.BottomPt <= IptParam.TopPt 
                    || (IptParam.BottomPt > IptParam.ImageH)
                    )
                {
                    OptParam.ErrorCode = 3;
                    return false;
                }

                ////////////////////////////////////////////////////////////////////////////////
                /******************************HALCON图像处理模块******************************/
                //定义与初始化图像、数据变量
                HTuple Windowhandle = new HTuple();

                HObject InputImageObj = new HObject();
                HObject TestImageObj = new HObject();
                HObject RectObj = new HObject();

                InputImageObj.GenEmptyObj();
                TestImageObj.GenEmptyObj();
                RectObj.GenEmptyObj();

                //将图像指针指向0地址。
                IntPtr ImagePtr = IntPtr.Zero;
                //传入图像指针
                ImagePtr = ArrayToIntptr(IptParam.ImagePtr);
                //错误4：判断图像指针是否还在0地址。
                if (ImagePtr == IntPtr.Zero)
                {
                    OptParam.ErrorCode = 4;
                    return false;
                }

                //生成图像变量
                HOperatorSet.GenImage1(out InputImageObj, "byte", IptParam.ImageW, IptParam.ImageH, ImagePtr);
                FreeIntptr(ImagePtr);

                //生成ROI
                HOperatorSet.GenRectangle1(out RectObj, IptParam.TopPt, IptParam.LeftPt, IptParam.BottomPt, IptParam.RightPt);
                HOperatorSet.ReduceDomain(InputImageObj, RectObj, out TestImageObj);
                HOperatorSet.CropDomain(TestImageObj, out TestImageObj);
                HTuple tmpW, tmpH;
                HOperatorSet.GetImageSize(TestImageObj, out tmpW, out tmpH);

                HObject GrayImage, ThesholdRegion, DealRegion, ReduceImage;
                HObject Edges, ContoursSplit, SelectedXLDC, ContCircle;

                HTuple Row = null, Column = null, Radius = null;
                HTuple StartPhi = null, EndPhi = null, PointOrder = null;
                //二值化和进一步ROI
                HOperatorSet.Rgb1ToGray(TestImageObj, out GrayImage);
                HOperatorSet.Threshold(GrayImage, out ThesholdRegion, IptParam.ThresholdMin, IptParam.ThresholdMax);
                HOperatorSet.DilationCircle(ThesholdRegion, out DealRegion, 3);
                HOperatorSet.ReduceDomain(GrayImage, DealRegion, out ReduceImage);

                //提取边缘
                HOperatorSet.EdgesSubPix(ReduceImage, out Edges, "canny", 1, 20, 40);
                HOperatorSet.SegmentContoursXld(Edges, out ContoursSplit, "lines_circles", 5, 4, 2);
                
                //选出圆弧边
                HOperatorSet.SelectShapeXld(ContoursSplit, out SelectedXLDC, "ratio", "and", 1, 5);
                HOperatorSet.FitCircleContourXld( SelectedXLDC, "algebraic", -1, 0, 0, 3,
                    2, out Row, out Column, out Radius, out StartPhi, out EndPhi, out PointOrder);
                HOperatorSet.GenCircleContourXld(out ContCircle, Row, Column, Radius, 0, 6.28318, "positive", 1);
                //stop ()

                //计算出中间圆环
                HTuple Radius_Mean = null, Row_Mean = null, Column_Mean = null;
                HObject Center_ContCircle;

                HOperatorSet.TupleMean(Radius, out Radius_Mean);
                HOperatorSet.TupleMean(Row, out Row_Mean);
                HOperatorSet.TupleMean(Column, out Column_Mean);
                HOperatorSet.GenCircleContourXld(out Center_ContCircle, Row_Mean, Column_Mean,
                    Radius_Mean, 0, 6.28318, "positive", 1);    //显示中心圆环

                //得出两直边的中间直边
                HObject ContourL_center, Cross1;

                HTuple RowBegin = null;
                HTuple ColBegin = null, RowEnd = null, ColEnd = null;
                HTuple Row_I = null;
                HTuple Column_I = null, IsOverlapping = null, PhiL = null;
                HTuple PhiL_Mean = null, Line_center = null, Row_Cross = null;
                HTuple Column_Cross = null, ANGLE = null;

                HOperatorSet.IntersectionLines(RowBegin.TupleSelect(0), ColBegin.TupleSelect(
                                0), RowEnd.TupleSelect(0), ColEnd.TupleSelect(0), RowBegin.TupleSelect(
                                1), ColBegin.TupleSelect(1), RowEnd.TupleSelect(1), ColEnd.TupleSelect(
                                1), out Row_I, out Column_I, out IsOverlapping);
                HOperatorSet.LineOrientation(RowBegin, ColBegin, RowEnd, ColEnd,
                    out PhiL);
                HOperatorSet.TupleMean(PhiL, out PhiL_Mean);
                Line_center = new HTuple();
                Line_center = Line_center.TupleConcat(Row_I);
                Line_center = Line_center.TupleConcat(Column_I);
                Line_center = Line_center.TupleConcat(Row_I + ((Radius.TupleSelect(
                    0)) * (PhiL_Mean.TupleSin())));
                Line_center = Line_center.TupleConcat(Column_I - ((Radius.TupleSelect(
                    0)) * (PhiL_Mean.TupleCos())));
                HOperatorSet.GenContourPolygonXld(out ContourL_center, ((Line_center.TupleSelect(
                    0))).TupleConcat(Line_center.TupleSelect(2)), ((Line_center.TupleSelect(
                    1))).TupleConcat(Line_center.TupleSelect(3))); //显示中间直线
                //中间直线角度
                ANGLE = PhiL_Mean.TupleDeg();

                //得到中间直线和中间圆环的中心交点。
                HOperatorSet.IntersectionLineCircle(Row_I, Column_I, Row_I + ((Radius.TupleSelect(0)) * (PhiL_Mean.TupleSin()))
                    , Column_I - ((Radius.TupleSelect(0)) * (PhiL_Mean.TupleCos()))
                    , Row_Mean, Column_Mean, Radius_Mean, StartPhi.TupleSelect(0)
                    , EndPhi.TupleSelect(0), "negative", out Row_Cross, out Column_Cross);
                HOperatorSet.GenCrossContourXld(out Cross1, Row_Cross, Column_Cross,
                    20, 0); //显示中心交点             
                ////////////////////////////////////////////////////////////////////////////////

                GC.Collect();
            }
            catch (HOperatorException e)
            {
                string str, expMsg;
                HTuple expTuple;
                e.ToHTuple(out expTuple);
                expMsg = expTuple[1].S;
                str = "Halcon 错误:\r\n";
                str += expMsg;
                //输出到输出结构参数ExceptionString。
                OptParam.ExceptionString = str;

                OptParam.ErrorCode = 255;

                return false;
            }

            //计算时间，输出运行时间
            DateTime timeEnd = System.DateTime.Now;
            TimeSpan timeSpan = timeEnd.Subtract(timeStart);
            OptParam.SpanTime = timeSpan.Milliseconds;

            return true;
        }
    }
}
