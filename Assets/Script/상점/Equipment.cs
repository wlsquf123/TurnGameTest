using UnityEngine;

public class Equipment : MonoBehaviour
{
    public int Price;

    [Header("´É·ÂÄ¡")]
    public float AddAttack;
    public float AddDef;
    public float AddCrit;

    [Header("UI")]
    public GameObject BuyButton;
    public GameObject EquipButton;


    // ±¸¸Å
    public void Buy()
    {
        Player player = GameManager.instance.player;

        if (player.Money < Price)
        {
            Debug.Log("°ñµå°¡ ºÎÁ·ÇÕ´Ï´Ù!");
            return;
        }

        player.Money -= Price;

        BuyButton.SetActive(false); // ±¸¸Å¹öÆ° ºñÈ°¼ºÈ­
        GameManager.instance.UIManager.BigMSG(name + " ±¸¸Å!");
    }


    // ¹«±â ÀåÂø
    public void EquipWeapon()
    {
        Player player = GameManager.instance.player;

        // ±âÁ¸ ¹«±â ´É·ÂÄ¡ Á¦°Å
        player.attack -= player.¹«±â.AddAttack;
        player.Def -= player.¹«±â.AddDef;
        player.crit -= player.¹«±â.AddCrit;

        // ±âÁ¸ ¹«±â ÀåÂø¹öÆ° ´Ù½Ã Ç¥½Ã
        player.¹«±â.EquipButton.SetActive(true);

        // »õ ¹«±â
        player.¹«±â = this;

        player.attack += AddAttack;
        player.Def += AddDef;
        player.crit += AddCrit;

        // ÇöÀç ¹«±â ÀåÂø¹öÆ° ¼û±è
        EquipButton.SetActive(false);

        GameManager.instance.UIManager.BigMSG(name + " ÀåÂø!");
    }


    // °©¿Ê ÀåÂø
    public void EquipArmor()
    {
        Player player = GameManager.instance.player;

        // ±âÁ¸ °©¿Ê ´É·ÂÄ¡ Á¦°Å
        player.attack -= player.°©¿Ê.AddAttack;
        player.Def -= player.°©¿Ê.AddDef;
        player.crit -= player.°©¿Ê.AddCrit;

        // ±âÁ¸ °©¿Ê ÀåÂø¹öÆ° ´Ù½Ã Ç¥½Ã
        player.°©¿Ê.EquipButton.SetActive(true);

        // »õ °©¿Ê
        player.°©¿Ê = this;

        player.attack += AddAttack;
        player.Def += AddDef;
        player.crit += AddCrit;

        // ÇöÀç °©¿Ê ÀåÂø¹öÆ° ¼û±è
        EquipButton.SetActive(false);

        GameManager.instance.UIManager.BigMSG(name + " ÀåÂø!");
    }
}