using UnityEngine;

public class InputController : MonoBehaviour
{
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
                if (hitInfo.collider.TryGetComponent<IInteractable>(out var interactableObject))
                {
                    interactableObject.OnSelect();
                }
            }
        }
    }
}
