using UnityEngine;

public class Player : MonoBehaviour, IDamagable, IAttacking
{
    [SerializeField] private Rigidbody2D _bulletPrefab;
    [SerializeField] private Transform _spawnBullet;
    [SerializeField] private PlasmaGun _gun;

    private int _amountCoint = 0;
    private int _maxHealth = 100;
    [SerializeField] private int _health;
    private InputReader _inputReader = new InputReader();

    private void Awake()
    {
        _health = _maxHealth;
    }

    private void Update()
    {
        Attack();
    }

    public void RestoreHealth(int amountHealtRestore)
    {
        bool isMoreMaxHealth = _health + amountHealtRestore > _maxHealth ? true : false;

        if (isMoreMaxHealth)
            _health = _maxHealth;

        _health += amountHealtRestore;
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

    public void TakeDamge(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
