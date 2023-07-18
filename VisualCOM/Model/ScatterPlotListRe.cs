using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCOM.Model
{
    public class ScatterPlotListRe<T> : ScatterPlotList<T>
    {
        public List<T> GetXs()
        {
            return base.Xs;
        }

        public List<T> GetYs()
        {
            return base.Ys;
        }
    }
}
