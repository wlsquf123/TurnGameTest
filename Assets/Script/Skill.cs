using UnityEngine;

public class Skill : MonoBehaviour
{
    public string SkillName;
    public int MpCost;

    public int Turn = 0;


    // 일반적인 타겟 선택 스킬
    public virtual void Select()
    {
        if (!GameManager.instance.player.SetMP(MpCost))
        {
            Debug.Log("MP가 부족합니다!");
            return;
        }

        GameManager.instance.BattleManager.SelectSkill(this);
    }


    // 공격 데미지
    public float GetDamage(float damagePercent)
    {
        GameManager.instance.player.PlayerAnimator.Play("Attack");

        float damage = GameManager.instance.player.attack * damagePercent;

        // 지식의 영약
        if (!(this is 일반))
        {
            foreach (Item item in FindObjectsByType<Item>(FindObjectsSortMode.None))
            {
                if (item.ItemType == 3 && item.Turn > 0)
                {
                    damage *= 1.3f;
                    break;
                }
            }
        }

        int random = Random.Range(0, 100);

        if (random < GameManager.instance.player.crit)
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