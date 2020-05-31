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

    }
}
