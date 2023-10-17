using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private MushroomClick _mushroomClick;
    [SerializeField] private Resources _resources;

    private void OnEnable()
    {
        _mushroomClick.MushroomButtonClick += Display;
        _resources.ResourcesChanged += Display;
    }

    private void OnDisable()
    {
        _mushroomClick.MushroomButtonClick -= Display;
        _resources.ResourcesChanged -= Display;
    }

    public void Display()
    {
        _score.text = Mathf.Round(_resources.CurrentMushroom).ToString();
    }
}
