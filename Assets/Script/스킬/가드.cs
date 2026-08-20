using UnityEngine;

public class 가드 : Skill
{
    public float AddDef = 0;


    public override void Select()
    {
        if (Turn == 0)
        {
            AddDef = player.Def * 0.3f;

            player.Def += AddDef;
        }

        Turn = 2;

        GameManager.instance.BattleManager.EndPlayerTurn();
    }


    public override void TurnDown()
    {
        if (Turn > 0)
        {
            Turn--;

            if (Turn == 0)
            {
                player.Def -= AddDef;

                AddDef = 0;
            }
        }
    }

    public override void ResetSkill()
    {
        if (Turn > 0)
        {
            player.Def -= AddDef;
        }

        AddDef = 0;
        Turn = 0;
    }
}