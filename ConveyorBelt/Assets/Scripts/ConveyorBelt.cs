using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [field: SerializeField]
    public float Speed { get; set; }

    private List<GameObject> _onBelt = new();

    private void Update()
    {
        foreach (GameObject obj in _onBelt)
            if (obj.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.velocity = Speed * transform.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _onBelt.Add(collision.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        _onBelt.Remove(collision.gameObject);
    }
}
