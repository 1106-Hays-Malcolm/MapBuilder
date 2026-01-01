using UnityEngine;
using UnityEngine.InputSystem;

namespace MapBuilder
{
    public class PieceSelectorMenu : MonoBehaviour
    {
        private bool _menuOpen = false;

        void Start()
        {
            MapEditorInputManager.Instance.menuAction.started += OnMenu;
        }

        private void OnMenu(InputAction.CallbackContext context)
        {
            _menuOpen = !_menuOpen;

            if (_menuOpen)
            {

            }
            else if (!_menuOpen)
            {

            }
        }
    }
}
