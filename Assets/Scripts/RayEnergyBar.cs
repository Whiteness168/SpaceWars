using UnityEngine;
using UnityEngine.UI;

public class RayEnergyBar : MonoBehaviour
{
    [SerializeField]
    private Image _bar;
    private AmmoStockpile _ammoStockpile;   

    private void RayEnergyBarAnimation()
    {
        _bar.fillAmount = _ammoStockpile.LaserCharge;
    }

    private void Awake()
    {
        _ammoStockpile = GameObject.Find("SpaceShip").GetComponent<AmmoStockpile>();
    }

    void Update()
    {
        RayEnergyBarAnimation();
    }
}