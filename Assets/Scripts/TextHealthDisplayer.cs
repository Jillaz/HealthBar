using TMPro;
using UnityEngine;

public class TextHealthDisplayer : MonoBehaviour
{
    [SerializeField] private Health _health;
    private TextMeshProUGUI _textMeshPro;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _textMeshPro.text = $"{_health.Value} / {_health.MaxValue}";
    }

    private void OnEnable()
    {
        _health.ValueUpdated += UpdateText;
    }

    private void OnDisable()
    {
        _health.ValueUpdated -= UpdateText;        
    }

    private void UpdateText(float value)
    {
        _textMeshPro.text = $"{value} / {_health.MaxValue}";
    }
}
