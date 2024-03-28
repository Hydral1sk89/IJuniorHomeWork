using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private float _quantity = 0f;

    private Coroutine _AddCountJob;
    private bool _isStarted = false;

    public void Push()
    {
        if (_isStarted == false)
        {
            _isStarted = true;
            _AddCountJob = StartCoroutine(Delay());
        }
        else
        {
            StopCoroutine(_AddCountJob);
            _isStarted = false;
        }
    }

    private IEnumerator Delay()
    {
        while (true)
        {
            var wait = new WaitForSeconds(_delay);
            yield return wait;

            _quantity++;
            Debug.Log("Количество - " + _quantity);
        }
    }
}