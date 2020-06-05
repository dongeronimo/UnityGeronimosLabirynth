using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CardinalOrientationTests
    {
        [UnityTest]
        public IEnumerator CanFaceNorth()
        {
            //Broken test - Dont know how to test the interpolation
            GameObject playerRoot = new GameObject();
            playerRoot.AddComponent<CardinalOrientation>();
            playerRoot.GetComponent<CardinalOrientation>().currentOrientation = new Vector3(1, 0, 0);
            playerRoot.GetComponent<CardinalOrientation>().finalOrientation = new Vector3(1, 0, 0);
            yield return null;
            var orientation = playerRoot.transform.forward;
            Assert.AreEqual(orientation.x, 0);
            Assert.AreEqual(orientation.z, 1);
        }
        [UnityTest]
        public IEnumerator CanFaceSouth()
        {
            //Broken test - Dont know how to test the interpolation
            GameObject playerRoot = new GameObject();
            playerRoot.AddComponent<CardinalOrientation>();
            playerRoot.GetComponent<CardinalOrientation>().currentOrientation = new Vector3(-1, 0, 0);
            yield return null;
            var orientation = playerRoot.transform.forward;
            Assert.AreEqual(orientation.x, 0);
            Assert.AreEqual(orientation.z, -1);
        }
        [UnityTest]
        public IEnumerator CanFaceEast()
        {
            //Broken test - Dont know how to test the interpolation
            GameObject playerRoot = new GameObject();
            playerRoot.AddComponent<CardinalOrientation>();
            playerRoot.GetComponent<CardinalOrientation>().currentOrientation = new Vector3(0, 0, 1);
            yield return null;
            var orientation = playerRoot.transform.forward;
            Assert.Less(Mathf.Abs(orientation.x - 1.0f), 0.001f);
            Assert.Less(Mathf.Abs(orientation.z - (0f)), 0.001f);
        }
        [UnityTest]
        public IEnumerator CanFaceWest()
        {
            //Broken test - Dont know how to test the interpolation
            GameObject playerRoot = new GameObject();
            playerRoot.AddComponent<CardinalOrientation>();
            playerRoot.GetComponent<CardinalOrientation>().currentOrientation = new Vector3(0, 0, -1);
            yield return null;
            var orientation = playerRoot.transform.forward;
            Assert.Less(Mathf.Abs(orientation.x - (-1.0f)), 0.001f);
            Assert.Less(Mathf.Abs(orientation.z - (0f)), 0.001f);

        }
    }
}
