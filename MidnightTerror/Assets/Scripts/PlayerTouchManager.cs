using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTouchManager : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private LayerMask _layerMask;

    private Camera _camera;
    private Vector2 _touchWorldPosition;

    private void Awake()
    {
        _camera = Camera.main;

        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.SingleTouch.performed += SingleTouch_performed;
    }

    private void SingleTouch_performed(InputAction.CallbackContext obj)
    {
        Vector2 touchPosition = obj.ReadValue<Vector2>();

        _touchWorldPosition = _camera.ScreenToWorldPoint(touchPosition);

        RaycastHit2D hit = Physics2D.Raycast(_touchWorldPosition, Vector2.zero, _layerMask);

        if(hit)
        {
            DetrermineItemAndInteract(hit.collider.gameObject);
        }
    }
    private void DetrermineItemAndInteract(GameObject gameObject)
    {
        IInteractable interactableObject;
        PickableItem pickableItem;
        EndingActivator endingActivator;

        if(gameObject.TryGetComponent<IInteractable>(out interactableObject))
        {
            interactableObject.TryExecuteInteraction();
        }

        else if (gameObject.TryGetComponent<PickableItem>(out pickableItem))
        {
            if (gameObject.TryGetComponent<EndingActivator>(out endingActivator))
            {
                endingActivator.ActivateEndingArea();
            }

            pickableItem.PlaceItemInInventory();
        }
    }
}
