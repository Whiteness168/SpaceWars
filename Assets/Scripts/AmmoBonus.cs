using UnityEngine;

public class AmmoBonus : Bonus
{
    private AmmoStockpile _ammoStockpile;

    protected override void AddPointsToStats()
    {
        _ammoStockpile.AddRocket((int)_bonusPoint);
    }

    protected override void Awake()
    {
        base.Awake();
        _ammoStockpile = GameObject.Find("SpaceShip").GetComponent<AmmoStockpile>();
    }
}