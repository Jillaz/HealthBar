using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float Value;
    [SerializeField] private bool _isHealer = true;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Click);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Click);
    }

    private void Click()
    {
        if (_isHealer)
        {
            _health.Healing(Value);
        }
        else
        {
            _health.TakeDamage(Value);
        }
    }
}
