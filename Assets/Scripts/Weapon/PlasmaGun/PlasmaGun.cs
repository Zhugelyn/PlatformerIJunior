using UnityEngine;

public class PlasmaGun : MonoBehaviour, IRangeWeapon
{
    [SerializeField] private Rigidbody2D _bulletPrefab;
    [SerializeField] private Transform _shootingPoint;

    public void Shoot(Vector3 shotDirection)
    {
        Instantiate(_bulletPrefab, _shootingPoint.transform.position, _shootingPoint.transform.rotation);
    }
}
