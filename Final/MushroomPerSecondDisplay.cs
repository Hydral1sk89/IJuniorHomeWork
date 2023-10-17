using TMPro;
using UnityEngine;

public class MushroomPerSecondDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text _mushroomPerSecond;
    [SerializeField] Resources _resources;

    private void OnEnable()
    {
        _resources.ResourcesChanged += Display;
    }

    private void OnDisable()
    {
        _resources.ResourcesChanged -= Display;
    }

    private void Display()
    {
        _mushroomPerSecond.text = $"грибочки в секунду: {Mathf.Round(_resources.MushroomPerSecond).ToString()}";
    }
}
