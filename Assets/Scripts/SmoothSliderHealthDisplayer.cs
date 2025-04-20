using UnityEngine;
using System.Collections;

public class SmoothSliderHealthDisplayer : SliderHealthDisplayer
{
    [SerializeField] private float _updateStep =0.1f;
    [SerializeField] private float _refreshRate = 0.001f;
    private Coroutine _coroutine;
       
    private IEnumerator BarUpdate(float targetValue)
    {
        float currentValue = _slider.value;
        var delay = new WaitForSeconds(_refreshRate);

        while (currentValue != targetValue)
        {
            currentValue = Mathf.Lerp(currentValue, targetValue, _updateStep);
            _slider.value = currentValue;
            yield return delay;
        }
    }

    protected override void SetValue(float value)
    {
        float targetValue = value / _health.MaxValue;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(BarUpdate(targetValue));
    }
}
