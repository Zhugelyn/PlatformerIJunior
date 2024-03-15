using UnityEngine;

public class EnemyPatrolAttack : MonoBehaviour, IRangeWeapon
{
    [SerializeField] private Rigidbody2D _bulletPrefab;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private ForceMode2D _forceMode2D = ForceMode2D.Impulse;
    [SerializeField] private float _force = 25;

    private float _shotDelay = 1f;

    public float ShotDelay => _shotDelay;

    public void Shoot(Vector3 targetPositon)
    {
        var direction = (targetPositon - transform.position).normalized;
        var bullet = Instantiate(_bulletPrefab, _shootingPoint.transform.position, Quaternion.identity);
        bullet.AddForce(direction * _force, _forceMode2D);
    }
}
