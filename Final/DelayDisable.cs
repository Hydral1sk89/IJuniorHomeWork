using System.Collections;
using UnityEngine;

public class DelayDisable : MonoBehaviour
{
    [SerializeField] private float _delay;

    private void OnEnable()
    {
        StartCoroutine(Disable());
    }

    private IEnumerator Disable()
    {
        var wait = new WaitForSeconds(_delay);
        yield return wait;
        gameObject.SetActive(false);
    }
}
