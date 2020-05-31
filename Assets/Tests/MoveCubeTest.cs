using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MoveCubeTest
    {
        [Test]
        public void CanMoveCube()
        {
            GameObject objectThatWillBeMoved = new GameObject();
            objectThatWillBeMoved.AddComponent<MoveCube>();
            objectThatWillBeMoved.GetComponent<MoveCube>().MoveRight();
            Vector3 modifiedPosition = objectThatWillBeMoved.transform.position;
            float xEpsilon = Mathf.Abs(Mathf.Abs(modifiedPosition.x) - Mathf.Abs(1.0f));
            Assert.Less(xEpsilon, 0.0001f);
        }
        /*
        // A Test behaves as an ordinary method
        [Test]
        public void MoveCubeTestSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator MoveCubeTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }*/
    }
}
