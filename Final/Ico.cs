using UnityEngine;

public class Ico : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;

    private Vector3 _position;
    private bool _isFirstStart = true;

    private void OnEnable()
    {
        if (_isFirstStart)
        {
            _isFirstStart = false;
            _position = _rectTransform.localPosition;
        }

        _rectTransform.localPosition = _position;
    }
}
