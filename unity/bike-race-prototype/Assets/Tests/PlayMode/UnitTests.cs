using System.Collections;
using MonoBehaviors;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode
{
    public class TestIRacer : MonoBehaviour, IRace
    {

        public Vector3 Destination { get; set; }

        public float Speed { get; set; }

        public float Acceleration { get; set; }
    }

    public class BikeRacerTests
    {
        [UnityTest]
        public IEnumerator CanBeToldWhereToGo()
        {
            var destination = new Vector3(0, 0, 13);
            var gameObject = new GameObject();
            var output = gameObject.AddComponent<TestIRacer>();
            var sut = gameObject.AddComponent<BikeRacer>();
            yield return new WaitForFixedUpdate();

            sut.Go(destination);

            Assert.AreEqual(destination, output.Destination);
        }
    }
}