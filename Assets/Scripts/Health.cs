using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action Died;
    public event Action<float> ValueUpdated;
    public event Action Hitted;

    [field: SerializeField] public float MaxValue { get; private set; } = 100;
    [field: SerializeField] public float Value { get; private set; } = 50;
    [field: SerializeField] public float MinValue { get; private set; } = 0;

    public void TakeDamage(float damage)
    {
        Value -= CheckNegativeValue(damage);
        Value = LimitValue(Value);
        Hitted?.Invoke();
        ValueUpdated?.Invoke(Value);

        if (Value == MinValue)
        {
            ValueUpdated?.Invoke(Value);
            Died?.Invoke();
        }
    }

    public void Healing(float healingAmount)
    {
        Value += CheckNegativeValue(healingAmount);
        Value = LimitValue(Value);
        ValueUpdated?.Invoke(Value);
    }

    public void Kill()
    {
        TakeDamage(Value);
    }

    public void Ressurect()
    {
        Value = MaxValue;
    }

    private float CheckNegativeValue(float value)
    {
        if (value < 0)
        {
            return 0;
        }
        else
        {
            return value;
        }
    }

    private float LimitValue(float value)
    {
        if (value < MinValue)
        {
            return MinValue;
        }

        if (value > MaxValue) 
        { 
            return MaxValue;
        }

        return value;
    }
}