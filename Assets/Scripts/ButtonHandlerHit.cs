using UnityEngine;
using UnityEngine.UI;

public class ButtonHandlerHit : MonoBehaviour
{
    [SerializeField] protected Health _health;
    [SerializeField] protected float _value;
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

    protected virtual void Click()
    {
        _health.TakeDamage(_value);
    }
}
