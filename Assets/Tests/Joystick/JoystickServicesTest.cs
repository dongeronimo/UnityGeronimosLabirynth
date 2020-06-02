using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class JoystickServicesTest
    {
        private void BuildStructure(GameObject joystick, GameObject touchIndicator)
        {
            joystick.name = "joystick";
            joystick.AddComponent<JoystickServices>();
            joystick.AddComponent<RectTransform>();
            joystick.GetComponent<RectTransform>().SetTop(0);
            joystick.GetComponent<RectTransform>().SetLeft(0);
            joystick.GetComponent<RectTransform>().SetRight(30);
            joystick.GetComponent<RectTransform>().SetBottom(30);

            touchIndicator.name = "TouchIndicator";
            touchIndicator.AddComponent<RectTransform>();
            touchIndicator.GetComponent<RectTransform>().SetTop(10);
            touchIndicator.GetComponent<RectTransform>().SetLeft(10);
            touchIndicator.GetComponent<RectTransform>().SetRight(20);
            touchIndicator.GetComponent<RectTransform>().SetBottom(20);
            touchIndicator.AddComponent<ShowOrHideTouchPosition>();
            touchIndicator.AddComponent<ChangeTouchIndicatorPosition>();
            touchIndicator.transform.parent = joystick.transform;
        }
        // A Test behaves as an ordinary method
        [Test]
        public void CanShowAtCorrectPosition()
        {
            GameObject joystick = new GameObject();
            GameObject touchIndicator = new GameObject();
            BuildStructure(joystick, touchIndicator);
            //Muda
            joystick.GetComponent<JoystickServices>().ShowTouchPosition(new Vector2(30,30));
            //Valida
            Vector2 indicatorPos = touchIndicator.transform.position;
            bool isEnabled = touchIndicator.GetComponent<Behaviour>().enabled;
            Assert.AreEqual(indicatorPos, new Vector2(30, 30));
            Assert.IsTrue(isEnabled);
        }
        [Test]
        public void CanHide()
        {
            //Constrói a hierarquia esperada
            GameObject joystick = new GameObject();
            GameObject touchIndicator = new GameObject();
            BuildStructure(joystick, touchIndicator);
            //Muda
            joystick.GetComponent<JoystickServices>().HideTouchPosition();
            //Valida
            bool isEnabled = touchIndicator.GetComponent<Behaviour>().enabled;
            Assert.IsFalse(isEnabled);
        }
        [Test]
        public void IsMovementAxesCorrect()
        {
            GameObject joystick = new GameObject();
            GameObject touchIndicator = new GameObject();
            BuildStructure(joystick, touchIndicator);
            joystick.GetComponent<JoystickServices>().ShowTouchPosition(new Vector2(30, 30));
            Vector2  axes = joystick.GetComponent<JoystickServices>().CurrentMovementAxes;
            var xEpsilon = Mathf.Abs(Mathf.Abs(axes.x) - Mathf.Abs(-0.948f));
            var yEpsilon = Mathf.Abs(Mathf.Abs(axes.y) - Mathf.Abs(-0.316f));
            Assert.Less(xEpsilon, 0.01f);
            Assert.Less(yEpsilon, 0.01f);
        }
    }
}
