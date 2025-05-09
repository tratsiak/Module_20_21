using UnityEngine;

public class RayShooter : IShooter
{
    private IShotEffect _shotEffect;
    private ParticleSystem _shotParticleEffect;

    public RayShooter(IShotEffect shotEffect, ParticleSystem shotParticleEffect)
    {
        _shotEffect = shotEffect;
        _shotParticleEffect = shotParticleEffect;
    }

    public void Shoot(Vector3 origin, Vector3 direction)
    {
        if (Physics.Raycast(origin, direction, out RaycastHit hitInfo))
        {
            _shotEffect.Execute(hitInfo.point, hitInfo.collider);

            Object.Instantiate(_shotParticleEffect, hitInfo.point, Quaternion.identity);
        }
    }
}
