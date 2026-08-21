using UnityEngine;

public class SkillBook : MonoBehaviour
{
    public GameObject SkillButton;

    public void Buy()
    {

        if (GameManager.instance.player.Money < 50)
        {
            GameManager.instance.UIManager.BigMSG("°ñµå°¡ ºÎÁ·ÇÕ´Ï´Ù!");
            return;
        }

        GameManager.instance.player.Money -= 50;

        SkillButton.SetActive(true);
        gameObject.SetActive(false);

        GameManager.instance.UIManager.BigMSG( name + " ½ºÅ³ È¹µæ!");
    }
}