using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private MeshRenderer _changer;
    [SerializeField] private Color _targetColor;
    [SerializeField] private float _duration;

    private void Start()
    {
        _changer.material.DOColor(_targetColor, _duration)
            .SetLoops(-1, LoopType.Yoyo);
    }
}