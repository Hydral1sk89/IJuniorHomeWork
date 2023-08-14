using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _volumeStep = 0.01f;

    private float _increase = 1;
    private float _decrease = 0;
    private float _volumeZero = 0;
    private AudioSource _alarm;
    private Coroutine _ChangeVolumeJob;

    private void Awake()
    {
        _alarm = GetComponent<AudioSource>();
    }

    public void AlarmStart()
    {
        StopCoroutineChangeVolume();

        _alarm.volume = _volumeZero;
        _alarm.Play();
        _ChangeVolumeJob = StartCoroutine(ChangeVolume(_volumeStep, _increase));
    }

    public void AlarmStop()
    {
        StopCoroutineChangeVolume();

        _ChangeVolumeJob = StartCoroutine(ChangeVolume(_volumeStep, _decrease));

        if(_alarm.volume == _volumeZero)
        {
            _alarm.Stop();
        }
    }

    private void StopCoroutineChangeVolume()
    {
        if (_ChangeVolumeJob != null)
        {
            StopCoroutine(_ChangeVolumeJob);
        }
    }

    private IEnumerator ChangeVolume(float step, float target)
    {
        while(Mathf.Abs(_alarm.volume - target) > Mathf.Epsilon)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, target, step * Time.deltaTime);

            yield return null;
        }
    }
}
