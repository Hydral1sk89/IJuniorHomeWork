using System.Collections;
using UnityEngine;

public class DestroyDelay : MonoBehaviour
{
    [SerializeField] private float _delay;

    private void OnEnable()
    {
        StartCoroutine(Dissolve());
    }

    private IEnumerator Dissolve()
    {
        var wait = new WaitForSeconds(_delay);
        yield return wait;
        Destroy(gameObject);
    }
}
