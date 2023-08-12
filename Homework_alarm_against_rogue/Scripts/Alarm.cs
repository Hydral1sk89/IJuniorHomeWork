using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private AudioSource _alarm;
    private float _volumeStep = 0.01f;
    private Coroutine _increaseVolumeJob;
    private Coroutine _decreaseVolumeJob;
    private WaitForSeconds _delay = new WaitForSeconds(0.003f);

    private void Awake()
    {
        _alarm = GetComponentInParent<AudioSource>();
    }

    public void AlarmStart()
    {
        _alarm.Play();
        _increaseVolumeJob = StartCoroutine(IncreaseVolume());
    }

    public void AlarmStop()
    {
        StopCoroutine(_increaseVolumeJob);
        _decreaseVolumeJob = StartCoroutine(DecreaseVolume());
    }

    private IEnumerator IncreaseVolume()
    {
        int milliseconds = 1000;

        for (float i = 0; i < milliseconds; i++)
        {
            _alarm.volume = i / milliseconds;

            yield return _delay;
        }
    }

    private IEnumerator DecreaseVolume()
    {
        int milliseconds = 1000;

        for (float i = milliseconds; i >= 0; i--)
        {
            _alarm.volume = i / milliseconds;

            yield return _delay;
        }
    }
}
