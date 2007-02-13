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
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using NUnit.Framework;
using Microsoft.Xna.Framework.Tests;
using Microsoft.Xna.Framework.Content.Tests;
using System.Threading;
using System.IO;

namespace Microsoft.Xna.Framework.Graphics.Tests
{
    [TestFixture]
    public class DisplayModeTest
    {
        /// <summary>
        /// A test for the constructors
        /// </summary>
        [Test]
        public void ConstructorTest()
        {
            DisplayMode mode = new DisplayMode();
            Assert.AreEqual(mode.RefreshRate, 0, "#1");
            Assert.AreEqual(mode.Format, (SurfaceFormat)0, "#2");
            Assert.AreEqual(mode.Height, 0, "#3");
            Assert.AreEqual(mode.Width, 0, "#4");
        }

        /// <summary>
        ///A test for Equals (object)
        ///</summary>
        [Test]
        public void EqualsTest()
        {
            DisplayMode mode = new DisplayMode();
            Assert.AreNotEqual(mode, null, "#1");
            Assert.IsTrue(mode == mode, "#2");
            Assert.IsFalse(mode != mode, "#3");
        }

        /// <summary>
        ///A test for ToString ()
        ///</summary>
        [Test]
        public void ToStringTest()
        {
            DisplayMode mode = new DisplayMode();
            Assert.AreEqual(mode.ToString(), "{Width:" + mode.Width + " Height:" + mode.Height + " Format:" + mode.Format + " RefreshRate" + mode.RefreshRate + "}");
        }
    }
}