using UnityEngine;

public class Stage2Enemy2 : Enemy
{
    public override float EnemyMaxHp => 50f + (EnemyLv * 10f);
    public override float EnemyAttack => 14f + (EnemyLv * 3f);
    public override float EnemyDef => 0f;
    public override float EnemySpeed => 13f;
    public override int EnemyExp => 60;

    private void Start()
    {
        EnemyLv = Random.Range(4, 7);
        EnemyHp = EnemyMaxHp;
    }
}
