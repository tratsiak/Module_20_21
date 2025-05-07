using UnityEngine;

public class Box : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _boxView;

    private IInteractor _interactor;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = _boxView.GetComponent<Renderer>();
    }

    private void Start()
    {
        _interactor = new DragInteractor(transform);
    }

    public void OnSelect()
    {
        _interactor.Interact();

        _renderer.material.color = Color.green;
    }

    public void OnRelease()
    {
        _renderer.material.color = Color.white;
    }
}
