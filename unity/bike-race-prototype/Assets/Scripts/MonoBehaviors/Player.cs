using Generated;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MonoBehaviors
{
    [RequireComponent(typeof(BikeRacer))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private Color helmetColor;
        [SerializeField] private Color jerseyColor;

        private BikeRacer _bikeRacer;
        private PlayerActionMap _playerActions;
        private Camera _camera;

        private void Start()
        {
            _bikeRacer = GetComponent<BikeRacer>();
            _camera = Camera.main;
            _playerActions.Player.Interaction.started += HandleInteraction;
        }
        private void Awake() => _playerActions = new PlayerActionMap();
        private void OnEnable() => _playerActions.Enable();
        private void OnDisable() => _playerActions.Disable();

        private void HandleInteraction(InputAction.CallbackContext context)
        {
            var position = _playerActions.Player.Position.ReadValue<Vector2>();

            // HACK: initial tap/click is 0,0,0
            if (position == Vector2.zero) return;

            var ray = _camera.ScreenPointToRay(position);
            if (Physics.Raycast(ray, out var hit))
            {
                _bikeRacer.Go(hit.point);
            }
        }
    }
}