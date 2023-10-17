using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Resources : MonoBehaviour
{
    [SerializeField] private float _currentMushroom = 0;
    [SerializeField] private float _mushroomPerClick = 1;
    [SerializeField] private float _mushroomPerSecond = 1;
    [SerializeField] private int _second = 1;

    public event UnityAction ResourcesChanged;

    public float CurrentMushroom => _currentMushroom;
    public float MushroomPerClick => _mushroomPerClick;
    public float MushroomPerSecond => _mushroomPerSecond;

    private void Start()
    {
        StartCoroutine(CalculationMushroomPerSecond());
    }

    public void AddMushroom(float number)
    {
        _currentMushroom += number;
        ResourcesChanged?.Invoke();
    }

    public void AddMushroomPerClick(float number)
    {
        _mushroomPerClick += number;
        ResourcesChanged?.Invoke();
    }

    public void AddMushroomPerSecond(float number)
    {
        _mushroomPerSecond += number;
        ResourcesChanged?.Invoke();
    }

    public bool TryToPay(float price)
    {
        if (price <= _currentMushroom)
        {
            _currentMushroom -= price;
            ResourcesChanged?.Invoke();
            return true;
        }
        else return false;
    }

    private IEnumerator CalculationMushroomPerSecond()
    {
        var wait = new WaitForSeconds(_second);

        while (enabled)
        {
            _currentMushroom += _mushroomPerSecond;
            ResourcesChanged?.Invoke();
            yield return wait;
        }
    }
}
