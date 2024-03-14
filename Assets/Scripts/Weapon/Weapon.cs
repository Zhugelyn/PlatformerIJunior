using UnityEngine;

public interface IMeeleWeapon
{
    public void Strike();
}

public interface IRangeWeapon
{
    public void Shoot(Vector3 targetPosition);
}

