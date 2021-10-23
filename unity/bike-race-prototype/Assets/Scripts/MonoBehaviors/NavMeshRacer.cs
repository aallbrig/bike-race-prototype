using UnityEngine;
using UnityEngine.AI;

namespace MonoBehaviors
{
    public class NavMeshRacer : MonoBehaviour, IRace
    {
        public Vector3 Destination
        {
            get => _agent.destination;
            set => _agent.destination = value;
        }

        private NavMeshAgent _agent;
        public float Speed
        {
            get => _agent.speed;
            set => _agent.speed = value;
        }

        public float Acceleration
        {
            get => _agent.acceleration;
            set => _agent.acceleration = value;
        }

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

    }

}