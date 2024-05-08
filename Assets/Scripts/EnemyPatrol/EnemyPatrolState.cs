using UnityEngine;

public abstract class EnemyPatrolState : MonoBehaviour
{
    protected EnemyPatrol EnemyPatrol;

    public virtual void GetWaypointMovement(WaypointMovement waypointMovement)
    {
    }

    public virtual void Init(EnemyPatrol enemyPatrol) 
    {
        EnemyPatrol = enemyPatrol;
    }

    public abstract void GuardTerritory();
}
