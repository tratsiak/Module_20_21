using Unity.Burst.CompilerServices;
using UnityEngine;

public class DragInteractor : IInteractor
{
    private Transform _target;

    public DragInteractor(Transform target)
    {
        _target = target;
    }

    public void Interact()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Vector3 newPosition = new Vector3(hitInfo.point.x, _target.position.y, hitInfo.point.z);
            _target.position = newPosition;
        }
    }
}
