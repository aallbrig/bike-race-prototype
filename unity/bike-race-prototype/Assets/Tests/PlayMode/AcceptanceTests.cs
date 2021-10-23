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
            var levelDetected = false;

            foreach (var gameObject in rootGameObjects)
            {
                // Find a level game object
                if (gameObject.name == "Level")
                {
                    levelDetected = true;
                }
            }

            Assert.IsTrue(levelDetected);
        }

        [UnityTest]
        public IEnumerator PlayerSeeACharacterTheyCanControl()
        {
            yield return LoadTargetScene(TargetScene);
            var activeScene = SceneManager.GetActiveScene();
            var rootGameObjects = activeScene.GetRootGameObjects();
            var levelDetected = false;

            foreach (var gameObject in rootGameObjects)
            {
                // Find a level game object
                if (gameObject.name == "Player")
                {
                    levelDetected = true;
                }
            }

            Assert.IsTrue(levelDetected);
        }
    }
}