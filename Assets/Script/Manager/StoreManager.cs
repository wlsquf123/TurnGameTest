using System;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public SkillBook[] SkillBooks;
    public bool IsHp = false;

    public void ResetStore()
    {
        foreach (SkillBook book in SkillBooks)
        {
            book.gameObject.SetActive(true);
            book.SkillButton.SetActive(false);
        }
    }

    public void ReHp()
    {
        if (IsHp)
        {
            GameManager.instance.UIManager.BigMSG("이미 회복을 사용했습니다");
            return;
        }
        var player = GameManager.instance.player;
        player.Hp += player.MaxHp * 0.3f;
        player.Hp = Mathf.Clamp(player.Hp, 0, player.MaxHp);
        IsHp = true;
        GameManager.instance.UIManager.BigMSG("체력 30% 회복!");
    }
}
