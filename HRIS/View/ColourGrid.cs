using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HRIS.View
{
    //This is a class for colour of the heatmap
    class ColourGrid
    {
        //For displaying time value on the grid
        public DateTime Time { get; set; }
        //For putting number in the rows
        public object[] Value { get; } = new object[5];
        //For setting the colour of background cell
        public Brush[] Colours { get; } = new Brush[5];
    }
}
