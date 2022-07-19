using UnityEngine;

public class CollisionSensor : MonoBehaviour
{
    [SerializeField]
    private bool m_CollisionDetected;

    public bool collisionDetected => m_CollisionDetected;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");
        m_CollisionDetected = true;
    }
    
    public void OnTriggerExit(Collider other)
    {
        Debug.Log("Collision exited");
        m_CollisionDetected = false;
    }
}
