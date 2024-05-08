using UnityEngine;

public class PatrolState : EnemyPatrolState
{
    private WaypointMovement _waypointMovement;

    public override void Init(EnemyPatrol enemyPatrol)
    {
        base.Init(enemyPatrol);
    }

    public override void GuardTerritory()
    {
        _waypointMovement.MoveToPoint();

        if (EnemyPatrol.Target != null)
            EnemyPatrol.SetState(EnemyPatrolStateType.Follow);
    }

    public override void GetWaypointMovement(WaypointMovement waypointMovement)
    {
        _waypointMovement = waypointMovement;
    }
}
