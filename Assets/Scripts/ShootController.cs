using UnityEngine;

public class ShootController : WeaponController
{
    [SerializeField]
    protected Transform _firePoint;

    void Update()
    {
        Shoot(_firePoint);
    }
}