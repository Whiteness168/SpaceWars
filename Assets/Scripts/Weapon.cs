using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public virtual float Damage { get; protected set; }
    protected KeyCode _activationKey = KeyCode.LeftAlt;

    protected void DealDamage(Enemy gameObject)
    {
        gameObject.TakeDamage(Damage);
    }

    protected void Shoot(GameObject ordnance, Transform firePoint)
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Instantiate(ordnance, firePoint.position, firePoint.rotation);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {

    }
}