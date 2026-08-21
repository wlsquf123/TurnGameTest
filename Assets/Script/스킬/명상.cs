using UnityEngine;

public class 명상 : Skill
{
    public override void Select()
    {
        if (Turn > 0)
        {
            Debug.Log("명상 쿨타임이 " + Turn + "턴 남았습니다");

            return;
        }

        var player = GameManager.instance.player;
        player.Hp += player.MaxHp * 0.3f;
        player.Hp = Mathf.Clamp(player.Hp, 0, player.MaxHp);

        Turn = 5;
        GameManager.instance.BattleManager.EndPlayerTurn();
    }
}