using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fractals
{
    public class MandelbrotData
    {
        public string InstanceName = null;

        public int iter;
        public bool grey;
        public bool blackWhite;
        public int zoomScale;
        public double x_min;
        public double x_max;
        public double y_min;
        public double y_max;
        public int zPower;
        public int cPower;
        internal MandelbrotData()
        {
            this.iter = 50;
            this.zoomScale = 7;
            this.grey = false;
            this.blackWhite = false;
            this.x_max = 1.0;
            this.x_min = -2.5;
            this.y_max = 1.0;
            this.y_min = -1.0;
            this.zPower = 2;
            this.cPower = 0;
        }
        public MandelbrotData(int _iter, int _zoom, bool _grey, bool _blackwhite, double xMin, double xMax, double yMin, double yMax,
            int _zpower, int _cpower)
        {
            this.iter = _iter;
            this.zoomScale = _zoom;
            this.grey = _grey;
            this.blackWhite = _blackwhite;
            this.x_max = xMax;
            this.x_min = xMin;
            this.y_max = yMax;
            this.y_min = yMin;
            this.zPower = _zpower;
            this.cPower = _cpower;
        }
        public MandelbrotData(string InstanceName, int _iter, int _zoom, bool _grey, bool _blackwhite, double xMin, double xMax, double yMin, double yMax,
          int _zpower, int _cpower)
        {
            this.InstanceName = InstanceName;
            this.iter = _iter;
            this.zoomScale = _zoom;
            this.grey = _grey;
            this.blackWhite = _blackwhite;
            this.x_max = xMax;
            this.x_min = xMin;
            this.y_max = yMax;
            this.y_min = yMin;
            this.zPower = _zpower;
            this.cPower = _cpower;
        }

        public void SetInstanceName(string name)
        {
            this.InstanceName = name;
        }

        public int GetIter()
        {
            return this.iter;
        }

        public int GetZoomScale()
        {
            return this.zoomScale;
        }

        public bool GetGrey()
        {
            return this.grey;
        }

        public bool GetBlackWhite()
        {
            return this.blackWhite;
        }

        public double GetXMin()
        {
            return this.x_min;
        }

        public double GetXMax()
        {
            return this.x_max;
        }

        public double GetYMin()
        {
            return this.y_min;
        }

        public double GetYMax()
        {
            return this.y_max;
        }

        public int GetZExponent()
        {
            return this.zPower;
        }

        public int GetCExponent()
        {
            return this.cPower;
        }
        public static object[] ToArray(MandelbrotData instance)
        {
            return new object[11]
            { 
                instance.InstanceName,
                instance.iter,
                instance.zoomScale,
                instance.grey, 
                instance.blackWhite, 
                instance.x_max, 
                instance.x_min, 
                instance.y_max, 
                instance.y_min, 
                instance.zPower, 
                instance.cPower 
            };
        }
        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}. {3}, {4}, {5}, {6}, {7}, {8}, {9} {10}.", MandelbrotData.ToArray(this));
        }
    }
}
