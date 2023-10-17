using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class MushroomClick : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Resources _resources;

    private RectTransform _rectTransform;

    public event UnityAction MushroomButtonClick;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnButtonClick()
    {
        _resources.AddMushroom(_resources.MushroomPerClick);
        MushroomButtonClick?.Invoke();
    }
}
