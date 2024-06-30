using UnityEngine;

public class ArmorSet : Bonus
{
    private Armor _armor;

    protected override void AddPointsToStats()
    {
        _armor.AddArmorPoint(_bonusPoint);
    }

    protected override void Awake()
    {
        base.Awake();
        _armor = GameObject.Find("SpaceShip").GetComponent<Armor>();
    }
}