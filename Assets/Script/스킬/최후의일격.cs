using UnityEngine;

public class 최후의일격 : Skill
{
    public override void Select()
    {
        if (player.SkillTurn[6] > 0)
        {
            Debug.Log("최후의일격 쿨타임이 " + player.SkillTurn[6] + "턴 남았습니다");
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
        player.SkillTurn[6] = 2;
    }
}