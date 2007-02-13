#region License
/*
MIT License
Copyright � 2006 The Mono.Xna Team
http://www.taoframework.com
All rights reserved.

Authors:
 * Rob Loach

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.Globalization;

namespace Microsoft.Xna.Framework.Graphics
{
    [Serializable]
    public struct DisplayMode
    {
        #region Constructors
        internal DisplayMode(int width, int height, int refreshRate, SurfaceFormat format)
        {
            this.width = width;
            this.height = height;
            this.refreshRate = refreshRate;
            this.format = format;
        }
        #endregion Constructors

        #region Operators
        public static bool operator !=(DisplayMode left, DisplayMode right)
        {
            return !(left == right);
        }

        public static bool operator ==(DisplayMode left, DisplayMode right)
        {
            return (left.format == right.format) &&
                (left.height == right.height) &&
                (left.refreshRate == right.refreshRate) &&
                (left.width == right.width);
        }
        #endregion Operators

        #region Public Properties
        public SurfaceFormat Format 
        {
            get { return format; } 
        }
        
        public int Height 
        {
            get { return height; }
        }

        public int RefreshRate 
        {
            get { return refreshRate; }
        }
        
        public int Width 
        {
            get { return width; } 
        }

        #endregion Public Properties

        #region Public Methods
        public override bool Equals(object obj)
        {
            return obj is DisplayMode && this == (DisplayMode)obj;
        }
        
        public override int GetHashCode()
        {
            return (width.GetHashCode() ^ height.GetHashCode() ^ refreshRate.GetHashCode() ^ format.GetHashCode());
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{{Width:{0} Height:{1} Format:{2} RefreshRate{3}}}", new object[] { width, height, format, refreshRate });
        }
        #endregion Public Methods

        #region Private Fields

        private int width, height, refreshRate;
        private SurfaceFormat format;

        #endregion Private Fields
    }
}
