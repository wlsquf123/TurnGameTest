using UnityEngine;

public class 약점격파 : Skill
{
    // 얘는 플레이어에서 턴 감소가 아닌 방어감소 받은 애의 Enemy 코드

    public override void Select()
    {
        if (player.SkillTurn[4] > 0)
        {
            Debug.Log("약점격파 쿨타임이 " + player.SkillTurn[4] + "턴 남았습니다");
            return;
        }
        
        base.Select();
    }

    public override void Use(Enemy enemy)
    {
        float Damage = GetDamage(1.3f);

        enemy.Damage(Damage);

        // 선택한 적에게 방어력 감소 3턴
        enemy.SkillTurn[0] = 3;
        player.SkillTurn[4] = 3;

        Debug.Log(enemy.Name + " 방어력 30% 감소!");
    }
}
