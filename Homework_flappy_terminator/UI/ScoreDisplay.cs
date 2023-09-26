using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;

    protected void Display(int score)
    {
        _score.text = score.ToString();
    }
}
