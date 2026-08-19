using UnityEngine;

public class Stage3Enemy1 : Enemy
{
    public override float EnemyMaxHp => 70f + (EnemyLv * 10f);
    public override float EnemyAttack => 13f + (EnemyLv * 2f);
    public override float EnemyDef => 25f;
    public override float EnemySpeed => 13f;
    public override int EnemyExp => 80;

    private void Start()
    {
        EnemyLv = Random.Range(7, 10);
        EnemyHp = EnemyMaxHp;
    }
}
