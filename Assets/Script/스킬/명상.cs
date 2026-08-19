using UnityEngine;

public class 명상 : Skill
{
    public override void Select()
    {
        if (player.SkillTurn[1] > 0)
        {
            Debug.Log("명상 쿨타임이 " + player.SkillTurn[1] + "턴 남았습니다");
            return;
        }
        if (!player.SetMP(MpCost))
        {
            Debug.Log("MP가 부족합니다!");
            return;
        }

        player.Hp += player.MaxHp * 0.3f;
        player.Hp = Mathf.Clamp(player.Hp, 0, player.MaxHp);
        player.SkillTurn[1] = 5;

        GameManager.instance.BattleManager.EndPlayerTurn();
    }
}
