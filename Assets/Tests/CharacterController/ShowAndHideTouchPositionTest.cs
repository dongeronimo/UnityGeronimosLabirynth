using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ShowAndHideTouchPositionTest
    {


        [Test]
        public void CanShow()
        {
            GameObject go = new GameObject();
            go.AddComponent<ShowOrHideTouchPosition>();
            go.GetComponent<ShowOrHideTouchPosition>().ShowTouchPosition();
            Assert.IsTrue(go.GetComponent<Behaviour>().enabled);
        }
        [Test]
        public void CanHide()
        {
            GameObject go = new GameObject();
            go.AddComponent<ShowOrHideTouchPosition>();
            go.GetComponent<ShowOrHideTouchPosition>().HideTouchPosition();
            Assert.IsFalse(go.GetComponent<Behaviour>().enabled);
        }

    }
}
