#region License
/*
MIT License
Copyright � 2006 The Mono.Xna Team

All rights reserved.

Authors:
Alan McGovern

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
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Graphics
{
    [SerializableAttribute]
    public struct VertexPositionColor
    {
        #region Fields
        public Color Color;

        public Vector3 Position;

        public static readonly VertexElement[] VertexElements;
        #endregion Fields


        #region Properties
        public static int SizeInBytes
        {
            get { throw new NotImplementedException(); }
        }
        #endregion


        #region Constructors
        public VertexPositionColor(Vector3 position, Color color)
        {
            throw new NotImplementedException();
        }
        #endregion Constructors


        #region Methods
        public static bool operator ==(VertexPositionColor left, VertexPositionColor right)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(VertexPositionColor left, VertexPositionColor right)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
        #endregion Methods
    }
}