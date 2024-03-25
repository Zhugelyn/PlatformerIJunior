using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _bulletPrefab;
    [SerializeField] private Transform _shootingPoint;
}

public interface IMeeleWeapon
{
    public void Strike();
}

public interface IRangeWeapon
{
    public void Shoot(Vector3 targetPosition);
}

