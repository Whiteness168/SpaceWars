using UnityEngine;
using TMPro;

public class ShowAmountAmmoController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textField;
    [SerializeField]
    private float _fontSize;

    private AmmoStockpile _ammoStockpile;
    private WeaponSwitcher _weaponSwitcher;
    private readonly string _bulletAmount = "∞";

    private void SetText()
    {
        switch (_weaponSwitcher.CurrentWeaponIndex)
        {
            case 0:
            {
                _textField.text = _bulletAmount;
                break;
            }
            case 1:
            {
                _textField.text = " ";
                break;
            }
            case 2:
            {
                _textField.text = _ammoStockpile.RocketAmount.ToString();
                break;
            }
        }
    }

    private void Awake()
    {
        _ammoStockpile = GameObject.Find("SpaceShip").GetComponent<AmmoStockpile>();
        _weaponSwitcher = GameObject.Find("Ship's Armament").GetComponent<WeaponSwitcher>();
    }

    private void Start()
    {
        _textField.fontSize = _fontSize;
    }

    void Update()
    {
        SetText();
    }
}