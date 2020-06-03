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
            GameObject playerRoot = new GameObject();
            playerRoot.AddComponent<CardinalOrientation>();
            playerRoot.GetComponent<CardinalOrientation>().YAxis = 1.0f;
            playerRoot.GetComponent<CardinalOrientation>().XAxis = 0.0f;
            yield return null;
            var orientation = playerRoot.transform.forward;
            Assert.AreEqual(orientation.x, 0);
            Assert.AreEqual(orientation.z, 1);
        }
        [UnityTest]
        public IEnumerator CanFaceSouth()
        {
            GameObject playerRoot = new GameObject();
            playerRoot.AddComponent<CardinalOrientation>();
            playerRoot.GetComponent<CardinalOrientation>().YAxis = -1.0f;
            playerRoot.GetComponent<CardinalOrientation>().XAxis = 0.0f;
            yield return null;
            var orientation = playerRoot.transform.forward;
            Assert.AreEqual(orientation.x, 0);
            Assert.AreEqual(orientation.z, -1);
        }
        [UnityTest]
        public IEnumerator CanFaceEast()
        {
            GameObject playerRoot = new GameObject();
            playerRoot.AddComponent<CardinalOrientation>();
            playerRoot.GetComponent<CardinalOrientation>().YAxis = 0.0f;
            playerRoot.GetComponent<CardinalOrientation>().XAxis = 1.0f;
            yield return null;
            var orientation = playerRoot.transform.forward;
            Assert.Less(Mathf.Abs(orientation.x - 1.0f), 0.001f);
            Assert.Less(Mathf.Abs(orientation.z - (0f)), 0.001f);
        }
        [UnityTest]
        public IEnumerator CanFaceWest()
        {
            GameObject playerRoot = new GameObject();
            playerRoot.AddComponent<CardinalOrientation>();
            playerRoot.GetComponent<CardinalOrientation>().YAxis = 0.0f;
            playerRoot.GetComponent<CardinalOrientation>().XAxis = -1.0f;
            yield return null;
            var orientation = playerRoot.transform.forward;
            Assert.Less(Mathf.Abs(orientation.x - (-1.0f)), 0.001f);
            Assert.Less(Mathf.Abs(orientation.z - (0f)), 0.001f);

        }
    }
}
