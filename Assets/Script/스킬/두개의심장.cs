using UnityEngine;

public class 두개의심장 : Skill
{
    public override void Select()
    {
        if (player.SkillTurn[8] > 0)
        {
            Debug.Log("두개의 심장 쿨타임이" + player.SkillTurn[8] + "남았습니다");
            return;
        }

        GameManager.instance.BattleManager.ExtraAction = true;
        player.SkillTurn[8] = 11;

        Debug.Log("두개의 심장 사용!");
    }
}
