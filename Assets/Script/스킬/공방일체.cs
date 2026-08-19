using UnityEngine;

public class 공방일체 : Skill
{
    public override void Select()
    {
        if (player.SkillTurn[7] > 0)
        {
            Debug.Log("공방일체 쿨타임이 " + player.SkillTurn[7] + "턴 남았습니다");
            return;
        }

        base.Select();
    }

    public override void Use(Enemy enemy)
    {
        foreach (Enemy target in GameManager.instance.BattleManager.Enemys)
        {
            target.Damage(GetDamage(1f));
        }
        player.SkillTurn[7] = 4;
    }
}
