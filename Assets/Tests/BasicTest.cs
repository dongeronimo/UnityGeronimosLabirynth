using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BasicTest
    {
        [Test]
        public void CanAssertSomething()
        {
            bool foo = false;
            Assert.AreEqual(false, foo);
        }
    }
}
