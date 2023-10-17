using TMPro;
using UnityEngine;

public class DisplayCursorScore : MonoBehaviour
{
    [SerializeField] private MushroomClick _mushroomClick;
    [SerializeField] private Resources _resources;

    private TMP_Text _scorePerClickText;

    private void OnEnable()
    {
        _mushroomClick.MushroomButtonClick += Display;
    }

    private void OnDisable()
    {
        _mushroomClick.MushroomButtonClick -= Display;
    }

    private void Display()
    {
        Instantiate(_scorePerClickText);
    }
}
