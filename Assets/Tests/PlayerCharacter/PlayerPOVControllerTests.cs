using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerPOVControllerTests
    {

        [UnityTest]
        public IEnumerator CameraPositionChangesIfParentChanges()
        {
            throw new System.Exception("Not implemented");
        }
        [UnityTest]
        public IEnumerator CameraPositionAndOrientationIsCorrectlySetInUpdate()
        {
            //Creates the camera
            GameObject camera = new GameObject();
            //Creates the parent
            GameObject parent = new GameObject();
            parent.transform.position = new Vector3(0, 0, 0);
            //Creates the POV 
            GameObject playerPOV = new GameObject();
            playerPOV.transform.position = new Vector3(0f, 1.59f, -3.82f);
            playerPOV.transform.parent = parent.transform;
            playerPOV.AddComponent<PlayerPOVController>();
            playerPOV.GetComponent<PlayerPOVController>().SceneCamera = camera.transform;
            //skip a frame to process, since the change happens inside Update method.
            yield return null;
            //do the tests
            var cameraPosition = camera.transform.position;
            var orientation = camera.transform.forward;
            Assert.AreEqual(cameraPosition, playerPOV.transform.position);
            var orientationXEpsilon = Mathf.Abs(Mathf.Abs(orientation.x) - Mathf.Abs(0));
            var orientationYEpsilon = Mathf.Abs(Mathf.Abs(orientation.y) - Mathf.Abs(-0.384f));
            var orientationZEpsilon = Mathf.Abs(Mathf.Abs(orientation.z) - Mathf.Abs(-0.923f));
            Assert.Less(orientationXEpsilon, 0.001f);
            Assert.Less(orientationYEpsilon, 0.001f);
            Assert.Less(orientationZEpsilon, 0.001f);
            yield return null;
        }
    }
}
