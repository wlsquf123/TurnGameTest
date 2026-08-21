using UnityEngine;

public class 노려보기 : Skill
{
    public override void Select()
    {
        if (Turn == 0)
        {
            GameManager.instance.player.crit += 25;
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
                GameManager.instance.player.crit -= 25;
            }
        }
    }

    public override void ResetSkill()
    {
        if (Turn > 0)
        {
            GameManager.instance.player.crit -= 25;
        }

        Turn = 0;
    }
}