using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int _capacity;

    private Camera _camera;

    private List<ClickIcon> _pool = new List<ClickIcon>();

    protected void Initialize(ClickIcon[] prefabs)
    {
        _camera = Camera.main;

        for(int i= 0; i < _capacity; i++)
        {
            ClickIcon icon = Instantiate(prefabs[i]);
            icon.gameObject.SetActive(false);
            icon.transform.SetParent(gameObject.transform);
            _pool.Add(icon);
        }
    }

    protected bool TryGetObject(out ClickIcon result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }
}
