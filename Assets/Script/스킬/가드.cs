using UnityEngine;

public class 가드 : Skill
{
    public override void Select()
    {
        if (!player.SetMP(MpCost))
        {
            Debug.Log("MP가 부족합니다!");
            return;
        }

        player.SkillTurn[3] = 2;

        GameManager.instance.BattleManager.EndPlayerTurn();
    }
}