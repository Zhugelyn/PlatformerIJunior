using UnityEngine;

public class EnemyPatrol : Unit, IAttacking, IDamagable
{
    [Header("stats")]
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _visibilityRange = 5f;
    [SerializeField] private int _attackRange = 3;

    [SerializeField] private EnemyPatrolAttack _enemyPatrolAttack;

    private Player _target;
    private EnemyPatrolState _currentState;
    private EnemyPatrolStateType _startState = EnemyPatrolStateType.Patrol;
    private WaypointMovement _waypointMovement;
    private float _lastShotTime = 0f;
    private int _maxHealth = 100;

    public float Speed => _speed;
    public Player Target => _target;

    private void Awake()
    {
        Init(_maxHealth);
    }

    private void Start()
    {
        _waypointMovement = gameObject.GetComponent<WaypointMovement>();
        SetState(_startState);
    }

    private void Update()
    {
        _currentState.GuardTerritory();
        CheckTargetInSight(_visibilityRange);

        if (CheckTargetInSight(_attackRange))
            Attack();
    }

    private void OnEnable()
    {
        Health.Die += Die;
    }

    private void OnDisable()
    {
        Health.Die -= Die;
    }

    public void SetState(EnemyPatrolStateType stateType)
    {
        switch (stateType)
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
                Debug.LogError(string.Format("Not enemy patrol state for type {0}", stateType));
                break;
        }
    }

    private bool CheckTargetInSight(float range)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);

        foreach (var collider in colliders)
        {
            if (collider.gameObject.TryGetComponent(out Player player))
            {
                _target = player;
                return true;
            }
        }

        _target = null;

        return false;
    }

    public void Attack()
    {
        if (Time.time > _lastShotTime)
        {
            _enemyPatrolAttack.Shoot(_target.transform.position);
            _lastShotTime = Time.time + _enemyPatrolAttack.ShotDelay;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        Health.TakeDamage(damage);
    }
}
