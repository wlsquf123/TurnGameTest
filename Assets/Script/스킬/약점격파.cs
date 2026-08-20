using UnityEngine;

public class 약점격파 : Skill
{
    public override void Select()
    {
        if (Turn > 0)
        {
            GameManager.instance.UIManager.SmallMSG("약점격파 쿨타임이 " + Turn + "턴 남았습니다");

            return;
        }
        base.Select();
    }


    public override void Use(Enemy enemy)
    {
        float Damage = GetDamage(1.3f);

        enemy.Damage(Damage);


        // 적 방어력 감소
        enemy.SkillTurn = 3;


        // 약점격파 쿨타임
        Turn = 3;


        Debug.Log(enemy.Name + " 방어력 30% 감소!");
    }
}