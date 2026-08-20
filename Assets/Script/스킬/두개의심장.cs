using UnityEngine;

public class 두개의심장 : Skill
{
    public override void Select()
    {
        if (Turn > 0)
        {
            GameManager.instance.UIManager.SmallMSG("두개의 심장 쿨타임이 " + Turn + "턴 남았습니다");

            return;
        }


        GameManager.instance.BattleManager.ExtraAction = true;


        Turn = 11;

        GameManager.instance.UIManager.BigMSG("두개의 심장 사용!");
    }
}