using System.Collections;
using MonoBehaviors;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode
{
    public class BikeRacerTests
    {
        [UnityTest]
        public IEnumerator CanBeToldWhereToGo()
        {
            var destination = new Vector3(0, 0, 13);
            var sut = new GameObject().AddComponent<BikeRacer>();
            yield return new WaitForFixedUpdate();

            sut.Go(destination);

            Assert.AreEqual(destination, sut.Destination);
        }
    }
}