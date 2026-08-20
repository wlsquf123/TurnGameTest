using UnityEngine;

public class 급습 : Skill
{
    public override void Select()
    {
        if (Turn > 0)
        {
            GameManager.instance.UIManager.SmallMSG("급습 쿨타임이 " + Turn + "턴 남았습니다");

            return;
        }

        base.Select();
    }

    public override void Use(Enemy enemy)
    {
        if (enemy.IsDefing)
        {
            enemy.Damage(GetDamage(2.5f));

            enemy.IsDefing = false;
            enemy.DefImage.gameObject.SetActive(false);
        }
        else
        {
            enemy.Damage(GetDamage(1.5f));
        }

        Turn = 3;
    }
}