using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _counter.Push();
        }
    }
}