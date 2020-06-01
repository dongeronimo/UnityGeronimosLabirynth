using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ChangeTouchIndicatorPositionTest
    {
        [Test]
        public void CanChangeTouchIndicatorPosition()
        {
            GameObject touchIndicator = new GameObject();
            touchIndicator.AddComponent<RectTransform>();
            touchIndicator.AddComponent<ChangeTouchIndicatorPosition>();
            touchIndicator.GetComponent<ChangeTouchIndicatorPosition>().SetPosition(new Vector2(10, 10));
            Vector2 pos = touchIndicator.GetComponent<RectTransform>().position;
            Assert.AreEqual(pos, new Vector2(10, 10));
        }
        [Test]
        public void RaisesErrorIfGameObjectHasNoRectTransform()
        {
            GameObject touchIndicator = new GameObject();
            touchIndicator.AddComponent<ChangeTouchIndicatorPosition>();
            Assert.Throws<MissingComponentException>(() =>
            {
                touchIndicator.GetComponent<ChangeTouchIndicatorPosition>()
                .SetPosition(new Vector2(10, 10));
            });
        }
    }
}
