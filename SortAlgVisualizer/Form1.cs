using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortAlgVisualizer
{
    public partial class Form1 : Form
    {
        int[] NumberArray;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            g = displayPanel.CreateGraphics();
            int NumEntries = displayPanel.Width;
            int MaxVal = displayPanel.Height;
            NumberArray = new int[NumEntries];
            g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), 0, 0, NumEntries, MaxVal);
            Random rand = new Random();
            for(int i = 0; i < NumEntries; i++)
            {
                NumberArray[i] = rand.Next(0, MaxVal);
            }
            for (int i = 0; i < NumEntries; i++)
            {
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i, MaxVal - NumberArray[i], 1, MaxVal);

            }
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            ISortEngine sortEngine = new BubbleSortEngine();
            sortEngine.DoWork(NumberArray, g, displayPanel.Height);
        }
    }
}
