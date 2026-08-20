using UnityEngine;

public class Stage1Enemy1 : Enemy
{
    public override float EnemyMaxHp => 50f + (EnemyLv * 10f);
    public override float EnemyAttack =>  8f + (EnemyLv * 2f);
    public override float EnemyDef =>  0f;
    public override float EnemySpeed => 8f;
    public override int EnemyExp =>  20 * EnemyLv;

    private void Start()
    {
        EnemyLv = Random.Range(1, 4);
        EnemyHp = EnemyMaxHp;
    }
}
