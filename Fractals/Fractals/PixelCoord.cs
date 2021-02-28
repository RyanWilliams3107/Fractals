using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fractals
{
    public struct PixelCoord
    {
        public int xPixel;
        public int yPixel;
        public PixelCoord(int x, int y)
        {
            this.xPixel = x;
            this.yPixel = y;
        }
        public int GetXPixel()
        {
            return this.xPixel;
        }
        public int GetYPixel()
        {
            return this.yPixel;
        }
    }
}
