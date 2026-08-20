using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int ItemType;
    public int Count = 0;
    public GameObject ItemButton;
    public int MaxCount = 5;
    public Text CountText;

    private void Update()
    {
        CountText.text = Count + " / " + MaxCount;
    }

    public void Use()
    {
        if (Count <= 0)
        {
            return;
        }

        Player player = GameManager.instance.player;

        switch (ItemType)
        {
            case 0:
                player.Hp += player.MaxHp * 0.2f;

                if (player.Hp > player.MaxHp)
                {
                    player.Hp = player.MaxHp;
                }
                break;

            case 1:
                player.Mp += player.MaxMp * 0.2f;

                if (player.Mp > player.MaxMp)
                {
                    player.Mp = player.MaxMp;
                }
                break;
        }

        Count--;

        if (Count <= 0)
        {
            ItemButton.SetActive(false);
        }
    }
}