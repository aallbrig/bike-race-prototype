using UnityEngine;

namespace MonoBehaviors
{
    public interface IRace
    {
        public Vector3 Destination { get; set; }
        public float Speed { get; set; }
        public float Acceleration { get; set; }
    }

    public class BikeRacer : MonoBehaviour
    {
        public Vector3 Destination => _racer.Destination;
        private IRace _racer;
        private void Start()
        {
            _racer = GetComponent<IRace>();
            if (_racer == null) Debug.LogError("Bike racer requires a component that implements IRace");
        }

        public void Go(Vector3 destination)
        {
            _racer.Destination = destination;
        }
    }
}
