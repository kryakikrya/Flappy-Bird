using TMPro;
using UnityEngine;

public class ScoreView : View
{
    private const string TextBase = "Score: ";

    [SerializeField] private TextMeshProUGUI _text;

    public override void Display(int value)
    {
        _text.text = $"{TextBase} {value}";
    }
}
