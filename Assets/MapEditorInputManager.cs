using UnityEngine;
using UnityEngine.InputSystem;

namespace MapBuilder
{
    enum EditMode
    {
        remove,
        place,
        floatingPlace,
        stack,
    }

    // A singleton class that gives a reference to the creative player input.
    public class MapEditorInputManager : MonoBehaviour
    {
        private static MapEditorInputManager _instance;
        public static MapEditorInputManager Instance { get { return _instance; } }

        private PlayerInput _playerInput;
        public PlayerInput playerInput { get { return _playerInput; } }

        private Vector2 _moveDirection;
        private Vector2 _lookDirection;

        public Vector2 moveDirection { get { return _moveDirection; } }
        public Vector2 lookDirection { get { return _lookDirection; } }

        private InputAction _moveAction;
        private InputAction _lookAction;
        private InputAction _placeAction;
        private InputAction _removeAction;
        private InputAction _upAction;
        private InputAction _downAction;
        private InputAction _fastAction;
        private InputAction _rotateAction;
        private InputAction _removeModeAction;
        private InputAction _placeModeAction;
        private InputAction _floatingPlaceModeAction;
        private InputAction _stackModeAction;

        public InputAction moveAction { get { return _moveAction; } }
        public InputAction lookAction { get { return _lookAction; } }
        public InputAction placeAction { get { return _placeAction; } }
        public InputAction removeAction { get { return _removeAction; } }
        public InputAction upAction { get { return _upAction; } }
        public InputAction downAction { get { return _downAction; } }
        public InputAction fastAction { get { return _fastAction; } }
        public InputAction rotateAction { get { return _rotateAction; } }
        public InputAction removeModeAction { get { return _removeModeAction; } }
        public InputAction placeModeAction { get { return _placeModeAction; } }
        public InputAction floatingPlaceModeAction { get { return _floatingPlaceModeAction; } }
        public InputAction stackModeAction { get { return _stackModeAction; } }

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;

            if (_instance != null)
            {
                Destroy(_instance.gameObject);
            }
            _instance = this;

            _playerInput = GetComponent<PlayerInput>();

            _moveAction = _playerInput.currentActionMap.FindAction("Move");
            _lookAction = _playerInput.currentActionMap.FindAction("Look");
            _placeAction = _playerInput.currentActionMap.FindAction("Place");
            _removeAction = _playerInput.currentActionMap.FindAction("Remove");
            _upAction = _playerInput.currentActionMap.FindAction("Up");
            _downAction = _playerInput.currentActionMap.FindAction("Down");
            _fastAction = _playerInput.currentActionMap.FindAction("Fast");
            _rotateAction = _playerInput.currentActionMap.FindAction("Rotate");
            _removeModeAction = _playerInput.currentActionMap.FindAction("RemoveMode");
            _placeModeAction = _playerInput.currentActionMap.FindAction("PlaceMode");
            _floatingPlaceModeAction = _playerInput.currentActionMap.FindAction("FloatingPlaceMode");
            _stackModeAction = _playerInput.currentActionMap.FindAction("StackMode");

            _playerInput.onActionTriggered += OnAction;
        }

        private void OnAction(InputAction.CallbackContext context)
        {
            if (context.action == _moveAction)
            {
                _moveDirection = moveAction.ReadValue<Vector2>();
            }

            if (context.action == _lookAction)
            {
                _lookDirection = lookAction.ReadValue<Vector2>();
            }
        }
    }
}
