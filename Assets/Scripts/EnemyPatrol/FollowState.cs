using UnityEngine;

public class FollowState : EnemyPatrolState
{
    public override void Init(EnemyPatrol enemyPatrol)
    {
        base.Init(enemyPatrol);
    }

    public override void GuardTerritory()
    {
        if (EnemyPatrol.Target == null)
            EnemyPatrol.SetState(EnemyPatrolStateType.Patrol);

        Chase();
    }

    private void Chase()
    {
        if (EnemyPatrol.Target == null)
            return;

        EnemyPatrol.transform.position = Vector2.MoveTowards(EnemyPatrol.transform.position,
            EnemyPatrol.Target.transform.position,
            EnemyPatrol.Speed * Time.deltaTime);
    }
}
