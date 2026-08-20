using UnityEngine;

public class 베기 : Skill
{
    public override void Use(Enemy enemy)
    {
        float Damage = GetDamage(1.7f);
        enemy.Damage(Damage);
        GameManager.instance.UIManager.BigMSG("베기 공격!");
    }
}
