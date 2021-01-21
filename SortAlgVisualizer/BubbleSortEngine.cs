using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgVisualizer
{
    class BubbleSortEngine : ISortEngine
    {
        private bool sorted = false;
        private int[] NumberArray;
        private Graphics g;
        private int MaxVal;
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

        public void DoWork(int[] numberArray, Graphics graphics, int maxVal)
        {
            NumberArray = numberArray;
            g = graphics;
            MaxVal = maxVal;

            while (!sorted)
            {
                for(int i = 0; i < NumberArray.Count() - 1; i++)
                {
                    if(NumberArray[i] > NumberArray[i + 1])
                    {
                        Swap(i, i + 1);
                    }
                }
                sorted = IsSorted();
            } 
        }

        private void Swap(int i, int v)
        {
            int temp = NumberArray[i];
            NumberArray[i] = NumberArray[i + 1];
            NumberArray[i + 1] = temp;

            g.FillRectangle(BlackBrush, i, 0, 1, MaxVal);
            g.FillRectangle(BlackBrush, v, 0, 1, MaxVal);

            g.FillRectangle(WhiteBrush, i, MaxVal - NumberArray[i], 1, MaxVal);
            g.FillRectangle(WhiteBrush, v, MaxVal - NumberArray[v], 1, MaxVal);
        }

        private bool IsSorted()
        {
            for(int i = 0; i < NumberArray.Count() - 1; i++)
            {
                if(NumberArray[i] > NumberArray[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
