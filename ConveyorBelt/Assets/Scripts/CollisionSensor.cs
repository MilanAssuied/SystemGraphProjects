using System;
using UnityEngine;

public class CollisionSensor : MonoBehaviour
{
    public event Action StateChanged;

    public bool CollisionDetected { get; private set; }

    public void OnTriggerEnter(Collider other)
    {
        CollisionDetected = true;
        StateChanged?.Invoke();
    }
    
    public void OnTriggerExit(Collider other)
    {
        CollisionDetected = false;
        StateChanged?.Invoke();
    }
}
