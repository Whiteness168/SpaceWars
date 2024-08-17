using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] Weapons;
    private int _currentWeaponIndex = 0;
    public int CurrentWeaponIndex
    {  get { return _currentWeaponIndex; } }

    private void SwitchWeapon(int index)
    {
        Weapons[_currentWeaponIndex].SetActive(false);

        Weapons[index].SetActive(true);

        _currentWeaponIndex = index;
    }

    private void StartChoiceGun()
    {
        for (int i = 0; i < Weapons.Length; i++)
        {
            if (i > _currentWeaponIndex)
            {
                Weapons[i].SetActive(false);
            }
        }
    } 

    private void CheckKeyPressed()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
            Debug.Log("firstWeapon" + "Active");
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
            Debug.Log("secondWeapon" + "Active");
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            SwitchWeapon(2);
            Debug.Log("thirdWeapon" + "Active");
        }
    }

    void Start()
    {
        StartChoiceGun();
    }

    void Update()
    {
        CheckKeyPressed();
    }
}