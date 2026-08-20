using UnityEngine;

public class Skill : MonoBehaviour
{
    public Player player;
    public string SkillName;
    public int MpCost;

    public int Turn = 0;


    // 일반적인 타겟 선택 스킬
    public virtual void Select()
    {
        if (!player.SetMP(MpCost))
        {
            Debug.Log("MP가 부족합니다!");
            return;
        }

        GameManager.instance.BattleManager.SelectSkill(this);
    }


    // 공격 데미지
    public float GetDamage(float damagePercent)
    {
        player.PlayerAnimator.Play("Attack");

        float damage = player.attack * damagePercent;

        int random = Random.Range(0, 100);

        if (random < player.crit)
        {
            damage *= 2;

            Debug.Log("크리티컬!");
        }

        return damage;
    }


    public virtual void Use(Enemy enemy)
    {

    }


    // 턴 감소
    public virtual void TurnDown()
    {
        if (Turn > 0)
        {
            Turn--;
        }
    }


    // 새 전투 시작
    public virtual void ResetSkill()
    {
        Turn = 0;
    }
}