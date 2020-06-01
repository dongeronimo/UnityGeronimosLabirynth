using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class JoystickServicesTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CanShowAtCorrectPosition()
        {
            //Constrói a hierarquia esperada
            GameObject joystick = new GameObject();
            joystick.name = "joystick";
            joystick.AddComponent<JoystickService>();
            GameObject touchIndicator = new GameObject();
            touchIndicator.name = "TouchIndicator";
            touchIndicator.AddComponent<RectTransform>();
            touchIndicator.GetComponent<RectTransform>().SetTop(10);
            touchIndicator.GetComponent<RectTransform>().SetLeft(10);
            touchIndicator.GetComponent<RectTransform>().SetRight(20);
            touchIndicator.GetComponent<RectTransform>().SetBottom(20);
            touchIndicator.AddComponent<ShowOrHideTouchPosition>();
            touchIndicator.AddComponent<ChangeTouchIndicatorPosition>();
            touchIndicator.transform.parent = joystick.transform;
            //Muda
            joystick.GetComponent<JoystickService>().ShowTouchPosition(new Vector2(30,30));
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
            joystick.name = "joystick";
            joystick.AddComponent<JoystickService>();
            GameObject touchIndicator = new GameObject();
            touchIndicator.name = "TouchIndicator";
            touchIndicator.AddComponent<RectTransform>();
            touchIndicator.GetComponent<RectTransform>().SetTop(10);
            touchIndicator.GetComponent<RectTransform>().SetLeft(10);
            touchIndicator.GetComponent<RectTransform>().SetRight(20);
            touchIndicator.GetComponent<RectTransform>().SetBottom(20);
            touchIndicator.AddComponent<ShowOrHideTouchPosition>();
            touchIndicator.AddComponent<ChangeTouchIndicatorPosition>();
            touchIndicator.transform.parent = joystick.transform;
            //Muda
            joystick.GetComponent<JoystickService>().HideTouchPosition();
            //Valida
            bool isEnabled = touchIndicator.GetComponent<Behaviour>().enabled;
            Assert.IsFalse(isEnabled);
        }
    }
}
