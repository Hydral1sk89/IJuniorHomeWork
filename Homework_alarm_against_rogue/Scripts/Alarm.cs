using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _volumeStep = 0.01f;

    private float _increase = 1;
    private float _decrease = 0;
    private AudioSource _alarm;
    private Coroutine _ChangeVolumeJob;

    public void AlarmStart()
    {
        if (_ChangeVolumeJob != null)
        {
            StopCoroutine(_ChangeVolumeJob);
        }

        _alarm.volume = 0;
        _alarm.Play();
        _ChangeVolumeJob = StartCoroutine(ChangeVolume(_volumeStep, _increase));
    }

    public void AlarmStop()
    {
        if (_ChangeVolumeJob != null) 
        {
            StopCoroutine(_ChangeVolumeJob); 
        }

        _ChangeVolumeJob = StartCoroutine(ChangeVolume(_volumeStep, _decrease));

        if(_alarm.volume == 0)
        {
            _alarm.Stop();
        }
    }

    private void Awake()
    {
        _alarm = GetComponentInParent<AudioSource>();
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
