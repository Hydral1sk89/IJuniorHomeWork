using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeClick : MonoBehaviour
{
    [SerializeField] private Resources _resources;
    [SerializeField] private TMP_Text _currentCount;
    [SerializeField] private TMP_Text _mushroomPerClick;
    [SerializeField] private TMP_Text _currentPrice;
    [SerializeField] private Button _sellButton;
    [SerializeField] private int _count = 0;
    [SerializeField] private int _countMushroomPerClick = 1;
    [SerializeField] private float _price = 100;
    [SerializeField] private float _multiplyPrice = 1.1f;
    [SerializeField] private int _AddMushroomPerClick = 1;

    private int _counter;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
    }

    private void Start()
    {
        Display();
    }

    public void OnButtonClick()
    {
        if (_resources.TryToPay(_price))
        {
            _count++;
            _countMushroomPerClick++;
            _price *= _multiplyPrice;
            _resources.AddMushroomPerClick(_AddMushroomPerClick);
            Display();
        }
    }

    private void Display()
    {
        _currentCount.text = $"������� ���-��: {_count}";
        _mushroomPerClick.text = $"���� ������ �� ����: {_countMushroomPerClick}";
        _currentPrice.text = $"{Mathf.Round(_price)}";
    }
}
