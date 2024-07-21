using System;
using System.Collections;
using UnityEngine;

public class Vamprism : MonoBehaviour, IUsable
{
    [Header("Stats")]
    [SerializeField] private float _range;
    [SerializeField] private int _countPerSecond;
    [SerializeField] private float _duration;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _delay;

    [SerializeField] private Player _player;

    public event Action<float, float> Activated;
    public event Action<float> Deactivated;

    private bool _isActive = false;

    private Coroutine _reload;
    private Coroutine _getHealthy;


    public void Activate()
    {
        if (_isActive == false)
        {
            _isActive = true;

            Activated.Invoke(_duration,_delay);
            _getHealthy = StartCoroutine(GetHealthy());
        }
    }

    private EnemyPatrol GetNearestEnemy()
    {
        var targets = Physics2D.OverlapCircleAll(transform.position, _range);

        foreach (var target in targets)
        {
            if (target.TryGetComponent(out EnemyPatrol enemy))
                return enemy;
        }

        return null;
    }

    public IEnumerator Reload()
    {
        Deactivated?.Invoke(_cooldown);

        float delay = 1f;
        var wait = new WaitForSeconds(delay);

        for (int i = 0; i < _cooldown; i++)
            yield return wait;

        _isActive = false;

        if (_reload != null)
            StopCoroutine(_reload);

        if (_getHealthy != null)
            StopCoroutine(_getHealthy);
    }

    private IEnumerator GetHealthy()
    { 
        var wait = new WaitForSeconds(_delay);

        for (float i = 0; i < _duration; i+= _delay)
        {
            var enemy = GetNearestEnemy();

            if (enemy != null)
            {
                enemy.TakeDamage(_countPerSecond);
                _player.RestoreHealth(_countPerSecond);
            }

            yield return wait;
        }

        _reload = StartCoroutine(Reload());
    }
}
