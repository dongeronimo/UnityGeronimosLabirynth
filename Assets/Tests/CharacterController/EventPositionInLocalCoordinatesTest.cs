using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EventPositionInLocalCoordinatesTest
    {

        [Test]
        public void CanConvertScreenCoordinatesToLocalCoordinatesInsideARect()
        {
            EventPositionInLocalCoordinates calculator = new EventPositionInLocalCoordinates();
            Vector2 rectTransformPositionInScreenCoordinates = new Vector2(10, 10);
            Vector2 eventInScreenCoordinates = new Vector2(15, 15);
            Vector2 result = calculator.Calculate(rectTransformPositionInScreenCoordinates, eventInScreenCoordinates);
            Assert.AreEqual(new Vector2(5, 5), result);
        }
        [Test]
        public void XIsPositiveIfToTheRightOfOrigin()
        {
            EventPositionInLocalCoordinates calculator = new EventPositionInLocalCoordinates();
            Vector2 origin = new Vector2(2, 2);
            Vector2 ev = new Vector2(4, 1);
            Assert.Greater(calculator.Calculate(origin, ev).x, 0);
        }
        [Test]
        public void XIsNegativeIfToTheLeftOfOrigin()
        {
            EventPositionInLocalCoordinates calculator = new EventPositionInLocalCoordinates();
            Vector2 origin = new Vector2(2, 2);
            Vector2 ev = new Vector2(1, 3);
            Assert.Less(calculator.Calculate(origin, ev).x, 0);
        }
        [Test]
        public void YIsPositiveIfAboveOrigin()
        {
            EventPositionInLocalCoordinates calculator = new EventPositionInLocalCoordinates();
            Vector2 origin = new Vector2(2, 2);
            Vector2 ev = new Vector2(2, 3);
            Assert.Greater(calculator.Calculate(origin, ev).y, 0);
        }
        [Test]
        public void YIsNegativeIfBelowOrigin()
        {
            EventPositionInLocalCoordinates calculator = new EventPositionInLocalCoordinates();
            Vector2 origin = new Vector2(2, 2);
            Vector2 ev = new Vector2(2, 1);
            Assert.Less(calculator.Calculate(origin, ev).y, 0);
        }

    }
}
