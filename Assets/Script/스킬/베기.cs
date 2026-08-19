using UnityEngine;

public class º£±â : Skill
{
    public override void Use(Enemy enemy)
    {
        float Damage = GetDamage(1.7f);
        enemy.Damage(Damage);
    }
}
