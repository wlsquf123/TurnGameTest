using UnityEngine;

public class Stage3Elite : Enemy
{
    public override float EnemyMaxHp => 100 + EnemyLv * 8;
    public override float EnemyAttack => 17 * EnemyLv * 2;
    public override float EnemyDef => 40f;
    public override float EnemySpeed => 15;
    public override int EnemyExp =>  120 * EnemyLv;

    private void Start()
    {
        EnemyLv = 9;
        EnemyHp = EnemyMaxHp;
    }

    public override void Attack()
    {
        Turn++;
        if (Turn % 4 == 0)
        {
            EnemyAnimator.Play("attack"); // 애니메이션 이거를 다르게 << 
            GameManager.instance.player.Damage(EnemyAttack * 2);
            GameManager.instance.UIManager.BigMSG("정예 몬스터 스킬 사용!");
        }
        else
        {
            base.Attack();
        }
    }
}
