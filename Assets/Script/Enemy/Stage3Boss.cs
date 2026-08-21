using UnityEngine;

public class Stage3Boss : Enemy
{
    public float attack = 40;
    public float def = 60;

    public override float EnemyMaxHp => 800;
    public override float EnemyAttack => attack;
    public override float EnemyDef => def;
    public override float EnemySpeed => 18;
    public override int EnemyExp => 600 * EnemyLv;

    public bool HalfUsed= false;

    private void Start()
    {
        EnemyLv = 11;
        EnemyHp = EnemyMaxHp;
    }

    public override void Attack()
    {
        Turn++;

        if (Turn % 10 == 9)
        {
            GameManager.instance.UIManager.BigMSG("보스가 파괴광선을 준비합니다!");
        }
        if (Turn % 10 == 0)
        {
            GameManager.instance.player.Damage(EnemyAttack * 3f);
            GameManager.instance.BattleManager.StopTurn = 3;

            GameManager.instance.UIManager.BigMSG("파괴 광선!");
        }
        if (Turn % 7 == 0)
        {
            GameManager.instance.player.Damage(EnemyAttack * 1.2f);
            GameManager.instance.BattleManager.StopTurn = 1;

            GameManager.instance.UIManager.BigMSG("암흑!");
        }
        if (Turn % 4 == 0) // 170% 피해를 입히고 가한 피해의 50% 회복
        {
            float damage = EnemyAttack * 1.7f;

            GameManager.instance.player.Damage(damage);

            EnemyHp += damage * 0.5f;
            EnemyHp = Mathf.Clamp(EnemyHp, 0, EnemyMaxHp);

            GameManager.instance.UIManager.BigMSG("영혼 흡수!");
        }
        else
        {
            base.Attack();
        }

        // 체력 50% 이하
        if (EnemyHp <= EnemyMaxHp / 2 && !HalfUsed)
        {
            EnemyHp += EnemyMaxHp * 0.25f;

            HalfUsed = true;

            attack += 20;
            def -= 30;

            GameManager.instance.UIManager.BigMSG("보스의 체력이 50% 이하라 체력을 25% 회복했습니다! (방여력30 감소, 공격력20 증가)");
        }
    }
}
