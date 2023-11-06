using DG.Tweening;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _x;
    [SerializeField] private float _y;
    [SerializeField] private float _z;

    private void Start()
    {
        transform.DORotate(new Vector3(_x, _y, _z), _duration, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetRelative()
            .SetEase(Ease.Linear);
    }
}