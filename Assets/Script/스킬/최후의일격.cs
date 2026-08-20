using UnityEngine;

public class 최후의일격 : Skill
{
    public override void Select()
    {
        if (Turn > 0)
        {
            GameManager.instance.UIManager.SmallMSG("최후의일격 쿨타임이 " + Turn + "턴 남았습니다");

            return;
        }

        base.Select();
    }


    public override void Use(Enemy enemy)
    {
        if (player.Hp <= player.MaxHp * 0.3f)
        {
            enemy.Damage(GetDamage(3f));
        }
        else
        {
            enemy.Damage(GetDamage(1.7f));
        }


        Turn = 2;

        GameManager.instance.UIManager.BigMSG("최후의 일격 사용!");
    }
}