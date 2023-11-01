using DG.Tweening;
using UnityEngine;

public class Scale : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _sizeX;
    [SerializeField] private float _sizeY;
    [SerializeField] private float _sizeZ;

    void Start()
    {
        transform.DOScale(new Vector3(_sizeX, _sizeY, _sizeZ), _duration)
            .SetLoops(-1, LoopType.Yoyo);
    }
}