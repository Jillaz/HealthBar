using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderHealthDisplayer : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField] private bool _isSmooth = false;
    [SerializeField] private float _updateStep = 0.01f;
    [SerializeField] private float _refreshRate = 0.1f;
    private Coroutine _coroutine;

    private void Awake()
    {
        _scrollbar = GetComponent<Scrollbar>();
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

    IEnumerator BarUpdate(float targetValue)
    {
        var delay = new WaitForSeconds(_refreshRate);

        while (_scrollbar.size != targetValue)
        {
            _scrollbar.size = Mathf.MoveTowards(_scrollbar.size, targetValue, _updateStep);
            yield return delay;
        }
    }

    private void SetValue(float value)
    {
        float targetValue = value / _health.MaxValue;

        if (_isSmooth)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(BarUpdate(targetValue));
        }
        else
        {
            _scrollbar.size = targetValue;
        }
    }
}
