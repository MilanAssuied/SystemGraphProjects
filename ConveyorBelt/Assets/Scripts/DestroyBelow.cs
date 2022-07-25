using UnityEngine;

public class DestroyBelow : MonoBehaviour
{
    public float minY = -10f;

    void Update()
    {
        if (transform.position.y < minY)
            Destroy(gameObject);
    }
}
