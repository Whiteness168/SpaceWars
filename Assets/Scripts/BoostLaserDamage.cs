using UnityEngine;

public class BoostLaserDamage : MonoBehaviour
{
    [SerializeField]
    private float _boostDamage;
    private Health _health;
    private WeaponSwitcher _weaponSwitcher;

    private void BoostDamageOn()
    {
        _health.ReducedLaserResistance += _boostDamage;
    }

    private void BoostDamageOff()
    {
        _health.ReducedLaserResistance += 0;
    }

    void Start()
    {
        _health = GetComponent<Health>();
        _weaponSwitcher = GameObject.Find("Ship's Armament").GetComponent<WeaponSwitcher>();   
    }

    void Update()
    {
        if (_weaponSwitcher.CurrentWeaponIndex == 1)
        {
            BoostDamageOn();
        }
        else
        {
            BoostDamageOff(); 
        }
    }
}