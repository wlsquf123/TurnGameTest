using UnityEngine;

public class SkillBook : MonoBehaviour
{
    public GameObject SkillButton;

    public void Buy()
    {

        if (GameManager.instance.player.Money < 50)
        {
            GameManager.instance.UIManager.BigMSG("골드가 부족합니다!");
            return;
        }

        GameManager.instance.player.Money -= 50;

        SkillButton.SetActive(true);
        gameObject.SetActive(false);

        GameManager.instance.UIManager.BigMSG( name + " 스킬 획득!");
    }

    // 새 게임 초기화
    public void ResetBook()
    {
        // 상점 스킬북 다시 등장
        gameObject.SetActive(true);

        // 배운 스킬 다시 잠금
        SkillButton.SetActive(false);
    }
}