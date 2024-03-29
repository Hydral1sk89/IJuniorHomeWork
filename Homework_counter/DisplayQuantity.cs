using TMPro;
using UnityEngine;

public class DisplayQuantity : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counter;

    public void Show(float quantity)
    {
        _counter.text = quantity.ToString();
    }
}