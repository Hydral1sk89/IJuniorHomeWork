using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    [SerializeField] private BirdMover _mover;

    public event UnityAction GameOver;

    private void OnValidate()
    {
        if (_mover == null)
            _mover = GetComponent<BirdMover>();
    }

    public void ResetPlayer()
    {
        _mover.ResetBird();
    }

    public void Die()
    {
        GameOver?.Invoke();
    }
}
