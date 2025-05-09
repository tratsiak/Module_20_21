using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private ParticleSystem _shotParticleEffect;

    private const int LeftMouseKey = 0;
    private const int RightMouseKey = 1;

    private DragAndDrop _dragAndDrop;
    private IShooter _shooter;

    private void Awake()
    {
        _dragAndDrop = new DragAndDrop(_groundLayerMask, 50); //sorry for magic numbers
        _shooter = new RayShooter(new RadialExplosion(5, 1), _shotParticleEffect);
    }

    private void Update()
    {
        HandleLeftMouse();
        HandleRightMouse();
    }

    private void HandleLeftMouse()
    {
        if (Input.GetMouseButtonDown(LeftMouseKey))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            _dragAndDrop.Select(ray.origin, ray.direction);
        }
        else if (Input.GetMouseButton(LeftMouseKey))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            _dragAndDrop.Drag(ray.origin, ray.direction);
        }
        else if (Input.GetMouseButtonUp(LeftMouseKey))
        {
            _dragAndDrop.Drop();
        }
    }

    private void HandleRightMouse()
    {
        if (Input.GetMouseButtonDown(RightMouseKey))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            _shooter.Shoot(ray.origin, ray.direction);
        }
    }
}
