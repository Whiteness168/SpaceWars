using UnityEngine;

public class Aid : Bonus
{
    private Health _health;

    protected override void AddPointsToStats()
    {
        _health.AddHealthPoint(_bonusPoint);
    }

    protected override void Awake()
    {
        base.Awake();
        _health = GameObject.Find("SpaceShip").GetComponent<Health>();
    }
}
