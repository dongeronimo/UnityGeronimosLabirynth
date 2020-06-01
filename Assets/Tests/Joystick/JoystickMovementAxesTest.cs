using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class JoystickMovementAxesTest
    {
        [Test]
        public void CanCalculateTheAxes()
        {
            Vector2 eventPosInSC = new Vector2(8, 5);
            Rect rect = new Rect(0, 0, 10, 10);
            Vector2 eventInLC = new EventPositionInLocalCoordinates().Calculate(rect.center, eventPosInSC);
            Vector2 movementAxes = new JoystickMovementAxes().Calculate(eventInLC, rect);
            Assert.AreEqual(1, movementAxes.x);
            Assert.AreEqual(0, movementAxes.y);
        }
        [Test]
        public void XIsNegativeToTheLeftOfOrigin()
        {
            Vector2 eventPosInSC = new Vector2(8, 5);
            Rect rect = new Rect(0, 0, 10, 10);
            Vector2 eventInLC = new EventPositionInLocalCoordinates().Calculate(rect.center, eventPosInSC);
            Vector2 movementAxes = new JoystickMovementAxes().Calculate(eventInLC, rect);
            Assert.Greater(movementAxes.x, 0);
        }
        [Test]
        public void XIsPositiveToTheRightOfOrigin()
        {
            Vector2 eventPosInSC = new Vector2(1, 5);
            Rect rect = new Rect(0, 0, 10, 10);
            Vector2 eventInLC = new EventPositionInLocalCoordinates().Calculate(rect.center, eventPosInSC);
            Vector2 movementAxes = new JoystickMovementAxes().Calculate(eventInLC, rect);
            Assert.Less(movementAxes.x, 0);
        }
        [Test]
        public void YIsPositiveToTheTopOfOrigin()
        {
            Vector2 eventPosInSC = new Vector2(5, 8);
            Rect rect = new Rect(0, 0, 10, 10);
            Vector2 eventInLC = new EventPositionInLocalCoordinates().Calculate(rect.center, eventPosInSC);
            Vector2 movementAxes = new JoystickMovementAxes().Calculate(eventInLC, rect);
            Assert.Greater(movementAxes.y, 0);
        }
        [Test]
        public void YIsNegativeToTheBottomOfOrigin()
        {
            Vector2 eventPosInSC = new Vector2(5, 2);
            Rect rect = new Rect(0, 0, 10, 10);
            Vector2 eventInLC = new EventPositionInLocalCoordinates().Calculate(rect.center, eventPosInSC);
            Vector2 movementAxes = new JoystickMovementAxes().Calculate(eventInLC, rect);
            Assert.Less(movementAxes.y, 0);
        }
        [Test]
        public void DiagonalIsCorrect()
        {
            Vector2 eventPosInSC = new Vector2(10, 10);
            Rect rect = new Rect(0, 0, 10, 10);
            Vector2 eventInLC = new EventPositionInLocalCoordinates().Calculate(rect.center, eventPosInSC);
            Vector2 movementAxes = new JoystickMovementAxes().Calculate(eventInLC, rect);
            var xEpsilon = Mathf.Abs(Mathf.Abs(movementAxes.x) - Mathf.Abs(0.7071f));
            var yEpsilon = Mathf.Abs(Mathf.Abs(movementAxes.x) - Mathf.Abs(0.7071f));
            Assert.Less(xEpsilon, 0.0001f);
            Assert.Less(yEpsilon, 0.0001f);
        }
    }
}
