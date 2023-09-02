using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTouchManager : MonoBehaviour
{
    private void Awake()
    {
        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.SingleTouch.performed += SingleTouch_performed;
    }

    private void SingleTouch_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        print("touch");
    }
}
