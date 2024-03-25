using UnityEngine;

public class PlasmaGun : MonoBehaviour, IRangeWeapon
{
    [SerializeField] private Rigidbody2D _bulletPrefab;
    [SerializeField] private Transform _shootingPoint;

    public void Shoot(Vector3 targetPositon)
    {
        Instantiate(_bulletPrefab, _shootingPoint.position, _shootingPoint.rotation);
    }
}
