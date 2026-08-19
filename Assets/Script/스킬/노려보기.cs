using UnityEngine;

public class 노려보기 : Skill
{
    public override void Select()
    {
        if (!player.SetMP(MpCost))
        {
            Debug.Log("MP가 부족합니다!");
            return;
        }

        player.SkillTurn[0] = 4;

        GameManager.instance.BattleManager.EndPlayerTurn();
    }
}
