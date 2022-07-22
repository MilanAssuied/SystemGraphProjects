using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    [SerializeField]
    private float _travelDistance = 0.02f;

    public bool Pushed { get; private set; }

    private void OnMouseDown()
    {
        transform.Translate(_travelDistance * (Pushed ? Vector3.up : Vector3.down), Space.Self);
        Pushed = !Pushed;
    }
}
