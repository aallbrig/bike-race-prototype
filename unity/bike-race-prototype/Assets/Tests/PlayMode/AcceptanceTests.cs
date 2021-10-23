using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests.PlayMode
{
    public class AcceptanceTests
    {
        private const string TargetScene = "BikeRacePrototype";

        private IEnumerator LoadTargetScene(string targetSceneName)
        {
            var sceneAsync = SceneManager.LoadSceneAsync(targetSceneName, LoadSceneMode.Single);
            var ready = false;
            sceneAsync.completed += operation => ready = true;
            yield return new WaitWhile(() => ready == false);
        }

        [UnityTest]
        public IEnumerator PlayerSeesALevel()
        {
            yield return LoadTargetScene(TargetScene);
            var activeScene = SceneManager.GetActiveScene();
            var rootGameObjects = activeScene.GetRootGameObjects();
            var detected = false;

            foreach (var gameObject in rootGameObjects)
            {
                // Find a level game object
                if (gameObject.name == "Level")
                {
                    detected = true;
                }
            }

            Assert.IsTrue(detected);
        }

        [UnityTest]
        public IEnumerator PlayerSeeACharacterTheyCanControl()
        {
            yield return LoadTargetScene(TargetScene);
            var sut = SceneManager.GetActiveScene();
            var rootGameObjects = sut.GetRootGameObjects();
            var detected = false;

            foreach (var gameObject in rootGameObjects)
            {
                // Find a level game object
                if (gameObject.name == "Player")
                {
                    detected = true;
                }
            }

            Assert.IsTrue(detected);
        }

        [UnityTest]
        public IEnumerator CameraFollowsThePlayer()
        {
            yield return LoadTargetScene(TargetScene);
            var player = GameObject.Find("Player");
            var cameraPosition = Camera.main.transform.position;

            player.transform.position = new Vector3(0, 0, 10);

            yield return new WaitForFixedUpdate();
            
            Assert.AreNotEqual(cameraPosition, Camera.main.transform.position);
        }
    }
}