using UnityEngine;

public class InputController : MonoBehaviour
{
    private IInteractable interactableObject;

    private void Update()
    {
        HandleInteraction();
    }

    private void HandleInteraction()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                interactableObject = hitInfo.collider.GetComponent<IInteractable>();

                interactableObject?.OnSelect();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (interactableObject != null)
            {
                interactableObject.OnRelease();
                interactableObject = null;
            }
        }
    }
}
