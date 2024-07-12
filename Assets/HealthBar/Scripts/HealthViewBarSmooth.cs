using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewBarSmooth : HealthView
{
    [SerializeField] private Slider _bar;
    [SerializeField] private Unit _unit;

    private float _smoothingSpeed = 2f;

    private void OnEnable()
    {
        _unit.Health.Changed += SetValue;
    }

    private void OnDisable()
    {
        _unit.Health.Changed -= SetValue;
    }

    private void Start()
    {
        _bar.maxValue = _unit.Health.MaxHealth;
        _bar.value = _unit.Health.MaxHealth;
    }

    private void SetValue(int count)
    {
        StartCoroutine(ChangeHealth(count));
    }

    private IEnumerator ChangeHealth(int count)
    {
        var delay = 0.05f;
        var wait = new WaitForSeconds(delay);

        while (_bar.value != count)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, count, _smoothingSpeed);
            yield return wait;
        }
    }
}
