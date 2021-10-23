using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests.PlayMode
{
    public class AcceptanceTests
    {
        const string TargetScene = "BikeRacePrototype";

        [UnityTest]
        public IEnumerator PlayerSeesALevel()
        {
            var sceneAsync = SceneManager.LoadSceneAsync(TargetScene);
            var ready = false;
            sceneAsync.completed += operation => ready = true;
            yield return new WaitWhile(() => ready == false);

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
    }
}