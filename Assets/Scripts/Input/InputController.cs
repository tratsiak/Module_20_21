using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _shooterEffect;

    private const int LeftMouseKey = 0;
    private const int RightMouseKey = 1;

    private IDraggable _draggableObject;
    private IShooter _shooter;

    private void Awake()
    {
        _shooter = new ExplosionShooter(_shooterEffect, 5, 300); //sorry for magic numbers
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

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.TryGetComponent<IDraggable>(out _draggableObject))
                {
                    _draggableObject.OnSelect();
                }
            }
        }
        else if (Input.GetMouseButton(LeftMouseKey))
        {
            _draggableObject?.OnDrag(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(LeftMouseKey))
        {
            _draggableObject?.OnRelease();

            _draggableObject = null;
        }
    }

    private void HandleRightMouse()
    {
        if (Input.GetMouseButtonDown(RightMouseKey))
        {
            _shooter.Shoot();
        }
    }
}
