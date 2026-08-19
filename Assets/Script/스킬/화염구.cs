using UnityEngine;

public class 화염구 : Skill
{
    public override void Use(Enemy enemy)
    {
        foreach (Enemy target in GameManager.instance.BattleManager.Enemys)
        {
            if (target != null && !target.IsDie)
            {
                target.Damage(GetDamage(1.8f));
            }
        }
    }
}
