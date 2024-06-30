using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    [SerializeField]
    protected float _bonusPoint;

    private DeathController _deathController;

    protected virtual void OnTriggerEnter2D(Collider2D collision )
    {
        if ( collision.name == "SpaceShip")
        {
            AddPointsToStats();
            _deathController.Die();
        }
    }

    protected virtual void AddPointsToStats ()
    {
    }

    protected virtual void Awake()
    {
        _deathController = gameObject.GetComponent<DeathController>();
    }
}