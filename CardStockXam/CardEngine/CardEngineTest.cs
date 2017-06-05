﻿﻿using NUnit.Framework;
using System;
using CardEngine;
using Players;
namespace CardEngine
// TODO unit testing for everything in CardEngine 
// focus on cloning
{
    [TestFixture()]
    public class NUnitTestClass
    {
        [Test()]
        public void TestTesting()
        {
            Node a = new Node{Value="red"};
            var c = new CardEngine.Card(a);
            StringAssert.Contains(c.attributes.Value, "red");
        }

       
    }
}
