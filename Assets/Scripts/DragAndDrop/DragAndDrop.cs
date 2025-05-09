using UnityEngine;

public class DragAndDrop
{
    private LayerMask _draggableLayer;
    private float _dragSpeed;
    private IDraggable _draggableObject;
    private Transform _draggableObjectTransform;

    public DragAndDrop(LayerMask draggableLayer, float dragSpeed)
    {
        _draggableLayer = draggableLayer;
        _dragSpeed = dragSpeed;
    }

    public void Select(Vector3 origin, Vector3 direction)
    {
        if (Physics.Raycast(origin, direction, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.TryGetComponent(out _draggableObject))
            {
                _draggableObject.OnSelect();

                _draggableObjectTransform = hitInfo.collider.transform;
            }
        }
    }

    public void Drag(Vector3 origin, Vector3 direction)
    {
        if (Physics.Raycast(origin, direction, out RaycastHit hitInfo, Mathf.Infinity, _draggableLayer))
        {
            _draggableObject.OnDrag();

            Vector3 newPosition = new Vector3(hitInfo.point.x, _draggableObjectTransform.position.y, hitInfo.point.z);
            _draggableObjectTransform.position = Vector3.Lerp(_draggableObjectTransform.position, newPosition, Time.deltaTime * _dragSpeed);
        }
    }

    public void Drop()
    {
        _draggableObject.OnRelease();

        _draggableObject = null;
    }
}
