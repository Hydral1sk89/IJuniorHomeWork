using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(RectTransform))]
public class ClickIcon : MonoBehaviour
{
    [SerializeField] private float _minPositionX;
    [SerializeField] private float _maxPositionX;
    [SerializeField] private float _minPositionY;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _delay;

    private RectTransform _rectTransform;
    private TMP_Text _text;

    private void OnEnable()
    {
        _text = GetComponentInChildren<TMP_Text>();
    }

    public void Initialize(float number)
    {
        _text.alpha = 255;
        _rectTransform = GetComponent<RectTransform>();
        _text.text = $"+{number.ToString()}";
        _rectTransform.localPosition = SetRandomPosition();
        StartCoroutine(Dissolve());
    }

    private Vector3 SetRandomPosition()
    {
        Vector3 position;
        position.x = Random.Range(_minPositionX, _maxPositionX);
        position.y = Random.Range(_minPositionY, _maxPositionY);
        position.z = 0;

        return position;
    }

    private IEnumerator Dissolve()
    {
        var wait = new WaitForSeconds(_delay);
        yield return wait;
        _text.alpha = 0;
    }
}
