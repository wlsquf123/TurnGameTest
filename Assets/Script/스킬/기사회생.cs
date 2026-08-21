using UnityEngine;

public class 기사회생 : Skill
{
    public override void Use(Enemy enemy)
    {
        float Hpr = 1f - (GameManager.instance.player.Hp / GameManager.instance.player.MaxHp);

        float DamagePercent = 1.5f + Hpr;

        enemy.Damage(GetDamage(DamagePercent));
        Debug.Log("기사회생 스킬 사용! 배율: " + DamagePercent);
    }
}
