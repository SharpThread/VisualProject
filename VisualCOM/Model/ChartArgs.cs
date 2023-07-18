using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScottPlot;
using ScottPlot.Styles;
using ScottPlot.Drawing.Colormaps;
namespace VisualCOM.Model
{
    public class ChartArgs
    {
        public ChartArgs()
        {
            //default
            pointShape = MarkerShape.filledCircle;
            pointSize = 5;

            lineSize = 1;
            lineShape = LineStyle.Solid;
            
            chartColor = System.Drawing.Color.Red;

            chartType = "折线";
        }

        public string PointShape { get; set; }

        public string LineShape { get; set; }

        public string Style { get; set; }

        public string Color { get; set; }

        public string ChannelName { get; set; }

        private float pointSize;

        public float PointSize
        {
            get { return pointSize; }
            set { pointSize = value; }
        }

        private MarkerShape pointShape;

        public void SetPointShape(string shapeName)
        {
            PointShape=shapeName;
            switch (shapeName)
            {
                case "实心圆": pointShape = MarkerShape.filledCircle; break;
                case "空心圆": pointShape = MarkerShape.openCircle; break;
                case "实心方": pointShape = MarkerShape.filledSquare; break;
                case "空心方": pointShape = MarkerShape.openSquare; break;
                case "不显示": pointShape = MarkerShape.none; break;
                default: pointShape = MarkerShape.filledCircle; break;
            }
        }
        public MarkerShape GetPointShape()
        {
            return pointShape;
        }

        private float lineSize;

        public float LineSize
        {
            get { return lineSize; }
            set { lineSize = value; }
        }

        private LineStyle lineShape;
        public void SetLineShape(string shapeName)
        {
            LineShape=shapeName;
            switch (shapeName)
            {
                case "实线": lineShape = LineStyle.Solid; break;
                case "虚线": lineShape = LineStyle.Dash; break;
                default: lineShape = LineStyle.Solid; break;
            }
        }
        public LineStyle GetLineShape()
        {
            return lineShape;
        }

        private System.Drawing.Color chartColor;
        public void SetColor(string colorName)
        {
            Color = colorName;
            switch (colorName)
            {
                case "红色": chartColor = System.Drawing.Color.Red; break;
                case "浅绿色": chartColor = System.Drawing.Color.SpringGreen; break;
                case "深绿色": chartColor = System.Drawing.Color.DarkGreen; break;
                case "浅蓝色": chartColor = System.Drawing.Color.DeepSkyBlue; break;
                case "深蓝色": chartColor = System.Drawing.Color.DodgerBlue; break;
                case "橙色": chartColor = System.Drawing.Color.Orange; break;
                case "浅紫色": chartColor = System.Drawing.Color.BlueViolet; break;
                case "深紫色": chartColor = System.Drawing.Color.Purple; break;
                case "粉红色": chartColor = System.Drawing.Color.HotPink; break;
                default: chartColor = System.Drawing.Color.Red; break;
            }
        }
        public System.Drawing.Color GetColor()
        {
            return chartColor;
        }

        private ScottPlot.Styles.IStyle chartStyle;
        public void SetStyle(string styleName)
        {
            Style=styleName;
            switch (styleName)
            {
                case "默认": chartStyle = new ScottPlot.Styles.Default(); break;
                case "黑色": chartStyle = new ScottPlot.Styles.Black(); break;
                case "蓝色": chartStyle = new ScottPlot.Styles.Blue1(); break;
                case "灰色": chartStyle = new ScottPlot.Styles.Gray1(); break;
                case "酒红色": chartStyle = new ScottPlot.Styles.Burgundy(); break;
                default: chartStyle = new ScottPlot.Styles.Default(); break;
            }
        }
        public IStyle GetStyle()
        {
            return chartStyle;
        }

        private string chartType;

        public string ChartType
        {
            get { return chartType; }
            set { chartType = value; }
        }

    }
}
