using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    private float _volumeStep = 0.01f;
    private Coroutine _increaseVolumeJob;
    private Coroutine _decreaseVolumeJob;
    private WaitForSeconds _delay = new WaitForSeconds(0.003f);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rogue>(out Rogue rogue))
        {
            _alarm.Play();
            _increaseVolumeJob = StartCoroutine(GradualIncreaseVolume());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rogue>(out Rogue rogue))
        {
            _decreaseVolumeJob = StartCoroutine(GradualDecreaseVolume());
        }
    }

    IEnumerator GradualIncreaseVolume()
    {
        int milliseconds = 1000;

        for (float i = 0; i < milliseconds; i++)
        {
            _alarm.volume = i / milliseconds;

            yield return _delay;
        }

        StopCoroutine(_increaseVolumeJob);
    }

    IEnumerator GradualDecreaseVolume()
    {
        int milliseconds = 1000;

        for (float i = milliseconds; i >= 0; i--)
        {
            _alarm.volume = i / milliseconds;

            yield return _delay;
        }

        StopCoroutine(_decreaseVolumeJob);
    }
}
