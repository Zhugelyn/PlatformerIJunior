using System.Collections;
using UnityEngine;

public class Vamprism : MonoBehaviour, IUsable
{
    [Header("Stats")]
    [SerializeField] private float _range;
    [SerializeField] private int _countPerSecond;
    [SerializeField] private float _duration;
    [SerializeField] private float _cooldown;

    [SerializeField] private Player _player;
    [SerializeField] private VampirismVisualization _visualization;

    [SerializeField] private bool _isActive = false;

    public void Activate()
    {
        if (_isActive == false)
        {
            _isActive = true;

            _visualization.VisualizeAbility(_duration);
            StartCoroutine("GetHealthy");
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
        _visualization.VisualizeReloading(_cooldown);

        float delay = 1f;
        var wait = new WaitForSeconds(delay);
        int i = 0;

        while (_cooldown > i)
        {
            i++;

            yield return wait;
        }

        _isActive = false;

        StopCoroutine("Relod");
    }

    private IEnumerator GetHealthy()
    {
        float delay = 1f;
        var wait = new WaitForSeconds(delay);
        float i = 0;

        while (_duration > i)
        {
            var enemy = GetNearestEnemy();

            if (enemy != null)
            {
                enemy.TakeDamage(_countPerSecond);
                _player.RestoreHealth(_countPerSecond);
            }

            i += delay;

            yield return wait;
        }

        StartCoroutine("Reload");
        StopCoroutine("GetHealthy");
    }
}
