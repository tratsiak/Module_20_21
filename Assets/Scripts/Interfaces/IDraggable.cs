using UnityEngine;

public interface IDraggable
{
    void OnSelect();
    void OnDrag(Vector3 position);
    void OnRelease();
}
