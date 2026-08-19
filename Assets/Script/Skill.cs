using UnityEngine;

public class Skill : MonoBehaviour
{
    public Player player;
    public string SkillName;
    public int MpCost;

    // 스킬 버튼을 눌렀을 때
    public virtual void Select()
    {
        if (!player.SetMP(MpCost))
        {
            Debug.Log("MP가 부족합니다!");
            return;
        }
        GameManager.instance.BattleManager.SelectSkill(this);
    }
    

    // 공격 데미지 계산
    public float GetDamage(float damagePercent)
    {
        float damage = player.attack * damagePercent;

        // 크리티컬
        int random = Random.Range(0, 100);

        if (random < player.GetCrit())
        {
            damage *= 2;
            Debug.Log("크리티컬!");
        }

        return damage;
    }

    // 실제 스킬 사용
    public virtual void Use(Enemy enemy)
    {
        
    }
}
