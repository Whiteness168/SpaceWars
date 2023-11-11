using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : Weapon
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        Shoot(_bulletPrefab, _firePoint);
    }
}