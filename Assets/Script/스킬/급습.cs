using UnityEngine;

public class 급습 : Skill
{
    public override void Select()
    {
        if (player.SkillTurn[5] > 0)
        {
            Debug.Log("급습 쿨타임이 " + player.SkillTurn[5] + "턴 남았습니다");
            return;
        }
        base.Select();

    }
    public override void Use(Enemy enemy)
    {
        if (enemy.IsDefing)
        {
            enemy.Damage(GetDamage(2.5f));
            enemy.IsDefing = false;
        }
        else
        {
            enemy.Damage(GetDamage(1.5f));
        }
        player.SkillTurn[5] = 3;
    }
}
