using UnityEngine;
using UnityEngine.UI;

public class HealthViewBarSmooth : HealthView
{
    [SerializeField] private Slider _bar;
    [SerializeField] private int _smoothingSpeed = 20;
    [SerializeField] private Unit _unit;

    private void Start()
    {
        _bar.maxValue = _unit.Health.MaxHealth;
        _bar.value = _unit.Health.MaxHealth;
    }

    private void Update()
    {
        if (_unit.Health != null)
            ChangeHealth(_unit.Health.Count);
    }

    private void ChangeHealth(int count)
    {
        _bar.value = Mathf.MoveTowards(_bar.value, count, Time.deltaTime * _smoothingSpeed);
    }
}
