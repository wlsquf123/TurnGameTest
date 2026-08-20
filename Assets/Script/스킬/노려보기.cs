using UnityEngine;

public class 노려보기 : Skill
{
    public override void Select()
    {

        // 처음 적용될 때만 +25
        if (Turn == 0)
        {
            player.crit += 25;
        }

        Turn = 4;

        GameManager.instance.BattleManager.EndPlayerTurn();
    }


    public override void TurnDown()
    {
        if (Turn > 0)
        {
            Turn--;

            if (Turn == 0)
            {
                player.crit -= 25;
            }
        }
    }


    public override void ResetSkill()
    {
        if (Turn > 0)
        {
            player.crit -= 25;
        }

        Turn = 0;
    }
}