using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _duration;

    void Start()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_text.DOText("текст", _duration).SetRelative());
        sequence.Append(_text.DOText("Здесь могла бы быть ваша реклама", _duration));
        sequence.Append(_text.DOColor(Color.red, _duration));
        sequence.Append(_text.DOText("Выходи из матрицы", _duration, true, ScrambleMode.All));
        sequence.Append(_text.DOColor(Color.green,_duration));
    }
}