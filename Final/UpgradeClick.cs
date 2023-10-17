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
            _countMushroomPerClick++;
            _resources.AddMushroomPerClick(_AddMushroomPerClick);
            _price *= _multiplyPrice;
            Display();
        }
    }

    private void Display()
    {
        _currentCount.text = $"Текущее кол-во: {_count}";
        _mushroomPerClick.text = $"Сбор грибов за клик: {_countMushroomPerClick}";
        _currentPrice.text = $"{Mathf.Round(_price)}";
    }
}
