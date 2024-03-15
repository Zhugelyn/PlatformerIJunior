using UnityEngine;

public class PlasmaGun : MonoBehaviour, IRangeWeapon
{
    [SerializeField] private Rigidbody2D _bulletPrefab;
    [SerializeField] private Transform _shootingPoint;

    public void Shoot(Vector3 targetPositon)
    {
        var rotationY = transform.localScale.x > 0 ? 0 : 180;
        var rotation = Quaternion.Euler(0, rotationY, 0);
        var bullet = Instantiate(_bulletPrefab, _shootingPoint.position, rotation);
    }
}
