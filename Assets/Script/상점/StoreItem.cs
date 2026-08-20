using UnityEngine;

public class StoreItem : MonoBehaviour
{
    public int Price;
    public Item Item;

    public void Buy()
    {
        Player player = GameManager.instance.player;

        if (player.Money < Price)
        {
            Debug.Log("골드가 부족합니다!");
            return;
        }

        if (Item.Count >= Item.MaxCount)
        {
            Debug.Log("더 이상 구매할 수 없습니다!");
            return;
        }

        player.Money -= Price;
        Item.Count++;
        Item.ItemButton.SetActive(true);

        GameManager.instance.UIManager.BigMSG(name + " 구매!");
    }
}
