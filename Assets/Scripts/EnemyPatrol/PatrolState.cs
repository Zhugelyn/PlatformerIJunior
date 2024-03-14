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

        if (_enemyPatrol.CheckTargetInSight(_enemyPatrol.VisibilityRange))
            _enemyPatrol.SetState(EnemyPatrolStateType.Follow);
    }

    public override void GetWaypointMovement(WaypointMovement waypointMovement)
    {
        _waypointMovement = waypointMovement;
    }
}
