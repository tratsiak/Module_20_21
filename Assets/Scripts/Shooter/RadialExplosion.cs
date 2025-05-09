using UnityEngine;

public class RadialExplosion : IShotEffect
{
    private float _explosionRadius;
    private float _explosionForce;

    public RadialExplosion(float explosionRadius, float explosionForce)
    {
        _explosionRadius = explosionRadius;
        _explosionForce = explosionForce;
    }

    public void Execute(Vector3 hitPoint, Collider hitCollider)
    {
        Collider[] colliders = Physics.OverlapSphere(hitPoint, _explosionRadius);

        foreach (Collider collider in colliders)
        {
            IExplodable explodableObject = collider.GetComponent<IExplodable>();

            if (explodableObject != null)
            {
                Vector3 forceDirection = (collider.transform.position - hitPoint).normalized;
                explodableObject.Explode(_explosionForce, forceDirection);
            }
        }
    }
}
