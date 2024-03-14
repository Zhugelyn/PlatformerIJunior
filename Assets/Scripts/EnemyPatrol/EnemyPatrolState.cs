using UnityEngine;

public abstract class EnemyPatrolState : MonoBehaviour
{
    protected EnemyPatrol _enemyPatrol;

    public virtual void GetWaypointMovement(WaypointMovement waypointMovement)
    {
    }

    public virtual void Init(EnemyPatrol enemyPatrol) 
    {
        _enemyPatrol = enemyPatrol;
    }

    public abstract void GuardTerritory();
}
