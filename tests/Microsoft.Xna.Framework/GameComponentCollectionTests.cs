#region License

/*
MIT License
Copyright � 2006-2007 The Mono.Xna Team

All rights reserved.

Authors: Isaac Llopis (neozack@gmail.com)

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

#endregion

using NUnit.Framework;

namespace Tests.Microsoft.Xna.Framework
{
    [TestFixture]
    public class GameComponentCollectionTests
    {
        GameComponentCollection components;
        TestGame game;

        #region Setup

        [SetUp]
        public void Init()
        {
            game = new TestGame(true);
            components = game.Components;
        }

        #endregion

        #region Public Constructors

        [Test]
        public void ValidateComponents()
        {
            Assert.IsInstanceOfType(typeof (GameComponentCollection), components);
        }

        #endregion

        #region Public Fields Tests

        #endregion

        #region Protected Fields Tests

        #endregion

        #region Public Properties Tests

        [Test]
        public void CountIsZeroTest()
        {
            Assert.AreEqual(0, components.Count);
        }

        [Test]
        public void Item()
        {
            MyComponent c = new MyComponent(game);
            components.Add(c);
            Assert.AreSame(c, components[0]);
        }

        #endregion

        [Test]
        public void Add()
        {
            MyComponent c = new MyComponent(game);
            components.Add(c);
            Assert.AreSame(c, components[0]);
        }

        [Test]
        public void Clear()
        {
            MyComponent c = new MyComponent(game);
            components.Add(c);
            Assert.AreEqual(1, components.Count, "Should contain 1 component");
            components.Clear();
            Assert.AreEqual(0, components.Count);
        }

        [Test]
        public void Contains()
        {
            MyComponent c = new MyComponent(game);
            components.Add(c);
            Assert.IsTrue(components.Contains(c), "Failed to find MyComponent");
        }

        [Test]
        public void ComponentAddedEventTest()
        {
            bool fired = false;
            components.ComponentAdded += delegate(object sender, GameComponentCollectionEventArgs args) { fired = true; };
            MyComponent c = new MyComponent(game);
            components.Add(c);
            Assert.IsTrue(fired, "ComponentAdded event did not fire.");
        }

        [Test]
        public void ComponentAddedEventArgsEventTest()
        {
            MyComponent c = new MyComponent(game);
            
            components.ComponentAdded += delegate(object sender, GameComponentCollectionEventArgs args)
                                             {
                                                 Assert.AreSame(c, args.GameComponent, "Unexpected component in args");
                                             };
            components.Add(c);
            Assert.AreEqual(1, components.Count, "Component was not added to collection");
        }

        [Test]
        public void ComponentRemovedEventTest()
        {
            bool fired = false;
            components.ComponentRemoved += delegate(object sender, GameComponentCollectionEventArgs args) { fired = true; };
            MyComponent c = new MyComponent(game);
            components.Add(c);
            components.Remove(c);
            Assert.IsTrue(fired, "ComponentRemoved event did not fire.");
        }

        [Test]
        public void ComponentRemovedEventArgsEventTest()
        {
            MyComponent c = new MyComponent(game);
            
            components.ComponentAdded += delegate(object sender, GameComponentCollectionEventArgs args)
                                             {
                                                 Assert.AreSame(c, args.GameComponent, "Unexpected component in args");
                                             };
            components.Add(c);
            Assert.AreEqual(1, components.Count, "Component was not added to collection");
            components.Remove(c);
            Assert.AreEqual(0, components.Count, "Component was not removed from collection");
        }

        #region Other tests

        #endregion
    }
}