using UnityEngine;

public interface IShotEffect
{
    void Execute(Vector3 hitPoint, Collider hitCollider);
}
