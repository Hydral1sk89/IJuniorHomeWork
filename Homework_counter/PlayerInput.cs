using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _counter.Push();
        }
    }
}