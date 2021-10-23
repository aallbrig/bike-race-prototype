using UnityEngine;

namespace MonoBehaviors
{
    public class FollowTarget: MonoBehaviour
    {
        [SerializeField] private GameObject target;
        private Vector3 _offset;
        private void Start()
        {
            if (target == null) Debug.LogError("Target must not be null");

            _offset = transform.position - target.transform.position;
        }

        private void Update()
        {
            if (target == null) return;

            transform.position = target.transform.position + _offset;
        }
    }
}