using UnityEngine;

public class FollowState : EnemyPatrolState
{
    public override void Init(EnemyPatrol enemyPatrol)
    {
        base.Init(enemyPatrol);
    }

    public override void GuardTerritory()
    {
        if (_enemyPatrol.Target == null)
            _enemyPatrol.SetState(EnemyPatrolStateType.Patrol);

        Chase();
    }

    private void Chase()
    {
        if (_enemyPatrol.Target == null)
            return;

        _enemyPatrol.transform.position = Vector2.MoveTowards(_enemyPatrol.transform.position, 
            _enemyPatrol.Target.transform.position, 
            _enemyPatrol.Speed * Time.deltaTime);
    }
}
