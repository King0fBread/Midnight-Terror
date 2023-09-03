using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTouchManager : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;

        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.SingleTouch.performed += SingleTouch_performed;
    }

    private void SingleTouch_performed(InputAction.CallbackContext obj)
    {
        print("touch");
        Vector2 touchPosition = obj.ReadValue<Vector2>();
        RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
        if(hit.collider != null)
        {
            print(hit.collider.gameObject.name);


        }
    }
    private void DetrermineItemAndInteract(GameObject gameObject)
    {
        if()
    }
}
