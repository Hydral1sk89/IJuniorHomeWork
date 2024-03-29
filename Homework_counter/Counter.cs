using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private float _quantity = 0f;

    private Coroutine _countJob;
    private bool _isRun = false;

    public void Push()
    {
        if (_isRun == false)
        {
            _isRun = true;
            _countJob = StartCoroutine(Delay());
        }
        else
        {
            StopCoroutine(_countJob);
            _isRun = false;
        }
    }

    private IEnumerator Delay()
    {
        var wait = new WaitForSeconds(_delay);

        while (true)
        {
            yield return wait;

            _quantity++;
            Debug.Log("Количество - " + _quantity);
        }
    }
}