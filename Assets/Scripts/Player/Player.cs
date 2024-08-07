using UnityEngine;

public class Player : Unit, IAttacking, IDamagable
{
    [Header("Weapon")]
    [SerializeField] private Rigidbody2D _bulletPrefab;
    [SerializeField] private Transform _spawnBullet;
    [SerializeField] private PlasmaGun _gun;

    [Header("Ability")]
    [SerializeField] private Vamprism _vamprism;

    private int _amountCoint = 0;
    private InputReader _inputReader = new InputReader();
    private int _maxHealth = 100;

    private void Awake()
    {
        Init(_maxHealth);
    }

    private void Update()
    {
        Attack();
        Vampirize();
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
        Health.Restore(recovery);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        Health.TakeDamage(damage);
    }

    private void Vampirize()
    {
        if (_inputReader.GetVampirismInput())
            _vamprism.Activate();
    }
}
