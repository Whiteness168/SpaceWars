using UnityEngine;

[RequireComponent(typeof(Pool))]
public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private AmmoStockpile _ammoStockpile;
    [SerializeField]
    private WeaponSwitcher _weaponSwitcher;

    private Pool _pool;
    private Sounds _sounds;

    private KeyCode _activationKey = KeyCode.LeftAlt;

    private bool IsKeyPressed()
    {
        if (Input.GetKeyDown(_activationKey))
        {
            return true;
        }
        else
        { 
            return false;
        }
    }

    protected void Shoot(Transform firePoint)
    {
        if (IsKeyPressed())
        {
            if (_ammoStockpile.AllAmmoCountCheck(_weaponSwitcher.CurrentWeaponIndex) || gameObject.name == "AlienEnemy")
            {
                _pool.GetFreeElement(firePoint.position, firePoint.rotation);
                _ammoStockpile.DecrementAmmo(_weaponSwitcher.CurrentWeaponIndex);
                _sounds.PlayClip();
            }
            else
            {
                Debug.Log("Патроны кончились");
            }
        }
    }

    void Awake()
    {
        _pool = GetComponent<Pool>();
        _sounds = GetComponent<Sounds>();
    }
}