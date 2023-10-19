using UnityEngine;

public class MushroomsGenerator : ObjectPool
{
    [SerializeField] private ClickIcon[] _icons;
    [SerializeField] private MushroomClick _mushroomClick;
    [SerializeField] private Resources _resources;

    private void OnEnable()
    {
        _mushroomClick.MushroomButtonClick += SpawnIcons;
    }

    private void OnDisable()
    {
        _mushroomClick.MushroomButtonClick -= SpawnIcons;
    }

    private void Start()
    {
        Initialize(_icons);
    }

    private void SpawnIcons()
    {
        if(TryGetObject(out ClickIcon icon))
        {
            icon.gameObject.SetActive(true);
            icon.Initialize(_resources.MushroomPerClick);
        }
    }
}
