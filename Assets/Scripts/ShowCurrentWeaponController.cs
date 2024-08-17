using UnityEngine;

public class ShowCurrentWeaponController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _currentWeapon;

    private WeaponSwitcher _weaponSwitcher;
    private int _currentWeaponIndex = 0;

    private void SwitchWeapon(int index)
    {
        _currentWeapon[_currentWeaponIndex].SetActive(false);

        _currentWeapon[index].SetActive(true);

        _currentWeaponIndex = index;
    }

    private void StartChoiceWeapon()
    {
        for (int i = 0; i < _currentWeapon.Length; i++)
        {
            if (i > _currentWeaponIndex)
            {
                _currentWeapon[i].SetActive(false);
            }
        }
    }

    private void Awake()
    {
        _weaponSwitcher = GameObject.Find("Ship's Armament").GetComponent<WeaponSwitcher>();
    }

    void Start()
    {
        StartChoiceWeapon();
    }

    void Update()
    {
        SwitchWeapon(_weaponSwitcher.CurrentWeaponIndex);
    }
}