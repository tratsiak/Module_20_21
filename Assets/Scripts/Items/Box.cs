using UnityEngine;

public class Box : MonoBehaviour, IDraggable, IExplodable
{
    [SerializeField] private GameObject _boxView;

    private Rigidbody _rigidbody;
    private Material _boxMaterial;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _boxMaterial = _boxView.GetComponent<Renderer>().material;
    }

    public void OnSelect()
    {
        _boxMaterial.color = Color.green;
    }

    public void OnDrag()
    {
        _rigidbody.isKinematic = true;
    }

    public void OnRelease()
    {
        _rigidbody.isKinematic = false;

        _boxMaterial.color = Color.white;
    }

    public void Explode(float explosionForce, Vector3 forceDirection)
    {
        _rigidbody.AddForce(forceDirection * explosionForce, ForceMode.Impulse);
    }

}
