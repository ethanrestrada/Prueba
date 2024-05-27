using System;
using System.Drawing;

namespace mat
{
    public class ECGDrawer
    {
        private int[] data;
        private int dataIndex;

        public ECGDrawer(int[] ecgData)
        {
            data = ecgData;
        }

        public void DrawECG(Graphics g, Rectangle bounds)
        {
            int x = bounds.X;
            int y = bounds.Y + bounds.Height / 2;

            for (int i = 0; i < bounds.Width; i++)
            {
                g.DrawLine(Pens.Red, x, y, x + 1, y - data[dataIndex]);
                dataIndex = (dataIndex + 1) % data.Length;
                x++;
            }
        }
    }

}