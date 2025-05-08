using UnityEngine;

public class ExplosionShooter : IShooter
{
    private ParticleSystem _explosionEffect;
    private float _explosionRadius;
    private float _explosionForce;
    private Vector3 _explosionPosition;

    public ExplosionShooter(float explosionRadius, float explosionForce)
    {
        _explosionRadius = explosionRadius;
        _explosionForce = explosionForce;
    }

    public ExplosionShooter(ParticleSystem explosionEffect, float explosionRadius, float explosionForce)
    {
        _explosionEffect = explosionEffect;
        _explosionRadius = explosionRadius;
        _explosionForce = explosionForce;
    }

    public void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Vector3 _explosionPosition = hitInfo.point;

            Collider[] colliders = Physics.OverlapSphere(_explosionPosition, _explosionRadius);

            foreach (Collider collider in colliders)
            {
                Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

                if (rigidbody != null)
                {
                    rigidbody.AddExplosionForce(_explosionForce, _explosionPosition, _explosionRadius);

                    PlayExplosionEffect();
                }
            }
        }
    }

    private void PlayExplosionEffect()
    {
        if (_explosionEffect != null)
            Object.Instantiate(_explosionEffect, _explosionPosition, Quaternion.identity);
    }
}
