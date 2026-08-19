using UnityEngine;

public class 일반 : Skill
{
    public override void Use(Enemy enemy)
    {
        float damage = GetDamage(1f);

        enemy.Damage(damage);

        Debug.Log("일반 공격!");
    }
}