using UnityEngine;

public class Stage3Enemy2 : Enemy
{
    public override float EnemyMaxHp => 60f + (EnemyLv * 10f);
    public override float EnemyAttack => 17f + (EnemyLv * 2f);
    public override float EnemyDef => 10f;
    public override float EnemySpeed => 17f;
    public override int EnemyExp => 90 * EnemyLv;

    private void Start()
    {
        EnemyLv = Random.Range(7, 10);
        EnemyHp = EnemyMaxHp;
    }
}