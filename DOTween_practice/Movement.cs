using DG.Tweening;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _targetPositionX;

    private void Start()
    {
        transform.DOMoveX(_targetPositionX, _duration)
            .SetLoops(-1, LoopType.Yoyo);
    }
}