using UnityEngine;

public class SpawnerController : WeaponController
{
    [SerializeField] 
    protected GameObject _missileType;
    [SerializeField]
    protected Transform _firePoint;

    void Update()
    {
        Shoot(_missileType, _firePoint);
    }
}
