using UnityEngine;
using UnityEngine.UI;

public class SliderHealthDisplayer : MonoBehaviour
{
    [SerializeField] protected Health _health;
    [SerializeField] protected Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.ValueUpdated += SetValue;
    }

    private void OnDisable()
    {
        _health.ValueUpdated -= SetValue;
    }

    private void Start()
    {
        SetValue(_health.Value);
    }

    protected virtual void SetValue(float value)
    {
        _slider.value = value / _health.MaxValue;
    }
}
