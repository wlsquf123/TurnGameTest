using UnityEngine;

public class 일반 : Skill
{
    public override void Use(Enemy enemy)
    {
        float damage = GetDamage(1f);

        enemy.Damage(damage);

        GameManager.instance.UIManager.BigMSG("일반 공격!");
    }
}