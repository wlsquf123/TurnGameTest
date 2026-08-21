using UnityEngine;

public class Stage1Boss : Enemy
{
    public override float EnemyMaxHp => 250f;
    public override float EnemyAttack => 20f;
    public override float EnemyDef => 30f;
    public override float EnemySpeed => 12f;
    public override int EnemyExp => 150 * EnemyLv;

    private void Start()
    {
        EnemyLv = 4;
        EnemyHp = EnemyMaxHp;
    }

    public override void Attack()
    {
        Turn++;

        if (Turn % 8 == 0)
        {
            EnemyAnimator.Play("attack");
            GameManager.instance.player.Damage(EnemyAttack * 1.8f);
            GameManager.instance.UIManager.BigMSG("³»·ÁÂï±â");
        }
        else
        {
            base.Attack();
        }

    }


}
