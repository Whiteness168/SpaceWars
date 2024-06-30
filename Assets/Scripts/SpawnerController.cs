using UnityEngine;

public class SpawnerController : WeaponController
{
    [SerializeField]
    protected Transform _firePoint;

    void Update()
    {
        Shoot(_firePoint);
    }
}