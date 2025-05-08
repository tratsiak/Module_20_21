using UnityEngine;

public class DragAndDrop : MonoBehaviour, IDraggable
{
    [SerializeField] private LayerMask _draggableLayer;
    [SerializeField] private float _dragSpeed;

    private bool _isDragging;

    public void OnSelect()
    {
        _isDragging = true;
    }

    public void OnDrag(Vector3 position)
    {
        if (_isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(position);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _draggableLayer))
            {
                Vector3 newPosition = new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z);
                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * _dragSpeed);
            }
        }
    }

    public void OnRelease()
    {
        _isDragging = false;
    }
}
