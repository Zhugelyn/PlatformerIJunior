using UnityEngine;

public class EnemyPatrol : MonoBehaviour, IDamagable, IAttacking
{
    [Header("stats")]
    [SerializeField] private int _health = 100;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _visibilityRange = 5f;
    [SerializeField] private int _attackRange = 3;

    [SerializeField] private EnemyPatrolAttack _enemyPatrolAttack;

    public Player target;

    private EnemyPatrolState _currentState;
    private EnemyPatrolStateType _startState = EnemyPatrolStateType.Patrol;
    private WaypointMovement _waypointMovement;
    private float _lastShotTime = 0f;

    public float Speed => _speed;
    public float VisibilityRange => _visibilityRange;

    private void Start()
    {
        _waypointMovement = gameObject.GetComponent<WaypointMovement>();
        SetState(_startState);
    }

    private void Update()
    {
        _currentState.GuardTerritory();

        if (CheckTargetInSight(_attackRange))
            Attack();
    }

    public void SetState(EnemyPatrolStateType _stateType)
    {
        switch (_stateType)
        {
            case EnemyPatrolStateType.Follow:
                _currentState = new FollowState();
                _currentState.Init(this);
                break;

            case EnemyPatrolStateType.Patrol:
                _currentState = new PatrolState();
                _currentState.Init(this);
                _currentState.GetWaypointMovement(_waypointMovement);
                break;
            default:
                _currentState = null;
                Debug.LogError(string.Format("Not enemy patrol state for type {0}", _stateType));
                break;
        }
    }

    public bool CheckTargetInSight(float range)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);

        foreach (var collider in colliders)
        {
            if (collider.gameObject.TryGetComponent(out Player player))
            {
                target = player;
                return true;
            }
        }

        return false;
    }

    public void TakeDamge(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    public void Attack()
    {
        if (Time.time > _lastShotTime)
        {
            _enemyPatrolAttack.Shoot(target.transform.position);
            _lastShotTime = Time.time + _enemyPatrolAttack.ShotDelay;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
