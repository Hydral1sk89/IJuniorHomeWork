using UnityEngine;
using TMPro;

[RequireComponent(typeof(RectTransform))]
public class ClickIcon : MonoBehaviour
{
    [SerializeField] private float _minPositionX;
    [SerializeField] private float _maxPositionX;
    [SerializeField] private float _minPositionY;
    [SerializeField] private float _maxPositionY;

    private RectTransform _rectTransform;
    private TMP_Text _text;

    public void Initialize(float number)
    {
        _rectTransform = GetComponent<RectTransform>();
        _text = GetComponentInChildren<TMP_Text>();
        _text.text = $"+{number.ToString()}";
        _rectTransform.localPosition = SetRandomPosition();
    }

    private Vector3 SetRandomPosition()
    {
        Vector3 position;
        position.x = Random.Range(_minPositionX, _maxPositionX);
        position.y = Random.Range(_minPositionY, _maxPositionY);
        position.z = 0;

        return position;
    }
}
