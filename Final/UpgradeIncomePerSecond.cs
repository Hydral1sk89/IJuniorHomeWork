using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeIncomePerSecond : MonoBehaviour
{
    [SerializeField] private Resources _resources;
    [SerializeField] private TMP_Text _currentCount;
    [SerializeField] private TMP_Text _mushroomPerSecond;
    [SerializeField] private TMP_Text _currentPrice;
    [SerializeField] private Button _sellButton;
    [SerializeField] private int _count = 0;
    [SerializeField] private int _countMushroomPerSecond = 1;
    [SerializeField] private float _price = 1000;
    [SerializeField] private float _multiplyPrice = 2;
    [SerializeField] private int _AddMushroomPerSecond = 1;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
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
            _countMushroomPerSecond += _AddMushroomPerSecond;
            _resources.AddMushroomPerSecond(_AddMushroomPerSecond);
            _price *= _multiplyPrice;
            Display();
        }
    }

    private void Display()
    {
        _currentCount.text = $"Текущее кол-во: {_count}";
        _mushroomPerSecond.text = $"Грибов в секунду: {_countMushroomPerSecond}";
        _currentPrice.text = $"{Mathf.Round(_price)}";
    }
}
