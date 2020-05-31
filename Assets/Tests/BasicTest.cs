using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        [Test]
        public void CanCatchErrors()
        {
            GameObject foo = new GameObject("test");
            //Foo has no rigidbody and here i assert that the exception that I expect is being thrown where I expect.
            Assert.Throws<MissingComponentException>(() => foo.GetComponent<Rigidbody>().velocity = Vector3.one);
        }
    }
}
