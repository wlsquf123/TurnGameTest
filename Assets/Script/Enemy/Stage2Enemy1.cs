using UnityEngine;

public class Stage2Enemy1 : Enemy
{
    public override float EnemyMaxHp => 60f + (EnemyLv * 10f);
    public override float EnemyAttack => 11f + (EnemyLv * 2f);
    public override float EnemyDef => 0f;
    public override float EnemySpeed => 11f;
    public override int EnemyExp => 50;

    private void Start()
    {
        EnemyLv = Random.Range(4, 7);
        EnemyHp = EnemyMaxHp;
    }
}
