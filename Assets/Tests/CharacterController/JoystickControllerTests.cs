using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class JoystickControllerTests
    {
        [Test]
        public void HasCurrentScene()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            Assert.IsNotNull(currentScene);
            Debug.Log("HasCurrentScene = " + currentScene.name);
        }
        [Test]
        public void CanAddAnEventSystemToScene()
        {
            GameObject eventSystemGameObject = new GameObject();
            eventSystemGameObject.AddComponent<EventSystem>();
            var currentEventSystem = EventSystem.current;
            Assert.IsNotNull(currentEventSystem);
        }
        /*
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator JoystickControllerTestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
        */
    }
}
