using UnityEngine;

public class Player : MonoBehaviour, IAttacking
{
    [SerializeField] private Rigidbody2D _bulletPrefab;
    [SerializeField] private Transform _spawnBullet;
    [SerializeField] private PlasmaGun _gun;

    private int _amountCoint = 0;
    private InputReader _inputReader = new InputReader();

    public int MaxHealth { get; private set; } = 100;
    public Health Health { get; private set; }

    private void Awake()
    {
        Health = new Health();
        Health.Init(MaxHealth);
    }

    private void Update()
    {
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

    public void AddCoin(int amountCoin)
    {
        _amountCoint += amountCoin;
    }

    public void Attack()
    {
        if (_inputReader.GetAttackInput())
        {
            _gun.Shoot(Vector3.one);
        }
    }

    public void RestoreHealth(int recovery)
    {
        Health.Restore(recovery, MaxHealth);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
