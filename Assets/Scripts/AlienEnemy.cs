using UnityEngine;

public class AlienEnemy : Enemy {
    protected override void Awake() {
        base.Awake();
        GetComponent<EnemyMoveController>().OnStop += CanShoot;
    }
}
