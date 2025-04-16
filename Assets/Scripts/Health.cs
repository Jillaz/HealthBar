using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action CharacterDied;
    public event Action<float> ValueUpdated;
    public event Action Hitted;

    [field: SerializeField] public float MaxValue { get; private set; } = 100;
    [field: SerializeField] public float Value { get; private set; } = 50;
    [field: SerializeField] public float LethalValue { get; private set; } = 0;

    public void TakeDamage(float damage)
    {
        Value -= Mathf.Clamp(damage, LethalValue, float.MaxValue);
        Hitted?.Invoke();
        ValueUpdated?.Invoke(Value);

        if (Value <= LethalValue)
        {
            Value = LethalValue;
            CharacterDied?.Invoke();
            ValueUpdated?.Invoke(Value);
        }
    }

    public void Healing(float healingAmount)
    {
        Value += Mathf.Clamp(healingAmount, LethalValue, MaxValue - Value);
        ValueUpdated?.Invoke(Value);
    }

    public void TakeLethalDamage()
    {
        TakeDamage(Value);
    }

    public void Ressurect()
    {
        Value = MaxValue;
    }
}