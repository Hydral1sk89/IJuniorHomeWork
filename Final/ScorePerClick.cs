using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ScorePerClick : MonoBehaviour
{
    [SerializeField] private MushroomClick _mushroomClick;
    [SerializeField] private ClickIcon _clickIcon;
    [SerializeField] private Resources _resources;


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
        var icon = Instantiate(_clickIcon);
        icon.transform.SetParent(_mushroomClick.transform);
        icon.Initialize(_resources.MushroomPerClick);
    }
}
