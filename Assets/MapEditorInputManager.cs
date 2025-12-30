using UnityEngine;
using UnityEngine.InputSystem;

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

    public InputAction moveAction { get { return _moveAction; } }
    public InputAction lookAction { get { return _lookAction; } }
    public InputAction placeAction { get { return _placeAction; } }
    public InputAction removeAction { get { return _removeAction; } }
    public InputAction upAction { get { return _upAction; } }
    public InputAction downAction { get { return _downAction; } }
    public InputAction fastAction { get { return _fastAction; } }
    public InputAction rotateAction { get { return _rotateAction; } }

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

