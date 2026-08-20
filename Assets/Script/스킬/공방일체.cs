using UnityEngine;

public class 공방일체 : Skill
{
    public float AddDef = 0;

    public override void Select()
    {
        if (Turn > 0)
        {
            Debug.Log("공방일체 쿨타임이 " + Turn + "턴 남았습니다");

            return;
        }

        base.Select();
    }


    public override void Use(Enemy enemy)
    {
        float Damage = GetDamage(1f);


        foreach (Enemy target in GameManager.instance.BattleManager.Enemys)
        {
            if (target != null && !target.IsDie)
            {
                target.Damage(Damage);
            }
        }

        AddDef = player.Def * 0.3f;
        player.Def += AddDef;

        Turn = 4;
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