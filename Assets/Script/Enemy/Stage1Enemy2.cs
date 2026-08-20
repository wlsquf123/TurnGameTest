using UnityEngine;

public class Stage1Enemy2 : Enemy
{
    public override float EnemyMaxHp => 40f + (EnemyLv * 10f);
    public override float EnemyAttack => 10f + (EnemyLv * 2f);
    public override float EnemyDef => 0f;
    public override float EnemySpeed => 11f;
    public override int EnemyExp => 30 * EnemyLv;

    private void Start()
    {
        EnemyLv = Random.Range(1, 4);
        EnemyHp = EnemyMaxHp;
    }

}
