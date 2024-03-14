using UnityEngine;

public class FollowState : EnemyPatrolState
{
    public override void Init(EnemyPatrol enemyPatrol)
    {
        base.Init(enemyPatrol);
    }

    public override void GuardTerritory()
    {
        Chase();

        if (_enemyPatrol.CheckTargetInSight(_enemyPatrol.VisibilityRange) == false)
            _enemyPatrol.SetState(EnemyPatrolStateType.Patrol);
    }

    private void Chase()
    {
        _enemyPatrol.transform.position = Vector2.MoveTowards(_enemyPatrol.transform.position, 
            _enemyPatrol.target.transform.position, 
            _enemyPatrol.Speed * Time.deltaTime);
    }
}
