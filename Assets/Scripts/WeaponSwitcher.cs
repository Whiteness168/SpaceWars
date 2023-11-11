using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] Weapons;
    private int _currentWeaponIndex = 0;

    private void SwitchWeapon(int index)
    {
        Weapons[_currentWeaponIndex].SetActive(false);

        Weapons[index].SetActive(true);

        _currentWeaponIndex = index;
    }

    private void StartChoiceGun()
    {
        Weapons[1].SetActive(false);
        Weapons[2].SetActive(false);
    }

    void Start()
    {
        StartChoiceGun();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
            Debug.Log(0 + "Active");
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
            Debug.Log(1 + "Active");
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            SwitchWeapon(2);
            Debug.Log(2 + "Active");
        }
    }
}
