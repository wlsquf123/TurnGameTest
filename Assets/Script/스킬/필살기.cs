using UnityEngine;

public class 필살기 : Skill
{
    public override void Select()
    {
        if (Turn > 0)
        {
            Debug.Log("필살기 쿨타임이 " + Turn + "턴 남았습니다");

            return;
        }

        foreach (Enemy enemy in GameManager.instance.BattleManager.Enemys)
        {
            if (enemy != null && !enemy.IsDie)
            {
                enemy.Damage(GetDamage(3f));
            }
        }

        Turn = 10;

        GameManager.instance.UIManager.BigMSG("필살기 사용!");
        GameManager.instance.BattleManager.EndPlayerTurn();
    }
}