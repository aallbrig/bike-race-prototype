using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode
{
    public class BikeRacerPrefab
    {
        [UnityTest]
        public IEnumerator Exists()
        {
            var sut = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Bike Racer"));
            yield return null;
            Assert.NotNull(sut);
        }
    }

    public class PlayerPrefab
    {
        [UnityTest]
        public IEnumerator Exists()
        {
            var sut = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
            yield return null;
            Assert.NotNull(sut);
        }
    }
}