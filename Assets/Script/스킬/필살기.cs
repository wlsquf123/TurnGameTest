using UnityEngine;

public class 필살기 : Skill
{
    public override void Select()
    {
        if (player.SkillTurn[2] > 0)
        {
            Debug.Log("필살기 쿨타임이 " + player.SkillTurn[2] + "턴 남았습니다");
            return;
        }
        if (!player.SetMP(MpCost))
        {
            Debug.Log("MP가 부족합니다!");
            return;
        }
        
        foreach (var en in GameManager.instance.BattleManager.Enemys)
        {
            en.Damage(GetDamage(3f));
        }

        Debug.Log("필살기 사용!");
        player.SkillTurn[2] = 10;
        GameManager.instance.BattleManager.EndPlayerTurn();
    }
}
