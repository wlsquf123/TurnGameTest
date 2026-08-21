using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int ItemType;

    public GameObject ItemButton;
    public Text CountText;

    public int Count = 0;
    public int MaxCount = 5;

    // 아이템 효과 지속 턴
    public int Turn = 0;

    private void Update()
    {
        CountText.text = "개수: " + Count + " / " + MaxCount;
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
            // 빨간 포션
            case 0:
                player.Hp += player.MaxHp * 0.2f;
                player.Hp = Mathf.Clamp(player.Hp, 0f, player.MaxHp);

                GameManager.instance.UIManager.BigMSG("빨간 포션 사용!");
                break;


            // 파란 포션
            case 1:
                player.Mp += player.MaxMp * 0.2f;
                player.Mp = Mathf.Clamp(player.Mp, 0f, player.MaxMp);

                GameManager.instance.UIManager.BigMSG("파란 포션 사용!");
                break;


            // 힘의 영약
            case 2:
                player.attack *= 1.3f;
                Turn = 5;
                GameManager.instance.UIManager.BigMSG("힘의 영약 사용!");
                break;


            // 지식의 영약
            case 3:
                Turn = 5;
                GameManager.instance.player.attack *= 1.3f;
                GameManager.instance.UIManager.BigMSG("지식의 영약 사용!");
                break;


            // 회피의 물약
            case 4:
                player.eva *= 2f;
                Turn = 1;
                GameManager.instance.UIManager.BigMSG("회피의 물약 사용!");
                break;
        }

        Count--;

        if (Count <= 0)
        {
            ItemButton.SetActive(false);
        }
    }


    // 지속 턴 감소
    public void TurnDown()
    {
        if (Turn > 0)
        {
            Turn--;

            if (Turn == 0)
            {
                Player player = GameManager.instance.player;

                switch (ItemType)
                {
                    // 힘의 영약 종료
                    case 2:
                        player.attack /= 1.3f;

                        GameManager.instance.UIManager.SmallMSG("힘의 영약 효과 종료!");
                        break;

                    // 지식의 영약 종료
                    case 3:
                        player.attack /= 1.3f;
                        GameManager.instance.UIManager.SmallMSG("지식의 영약 효과 종료!");
                        break;

                    case 4:
                        player.eva /= 2f;
                        GameManager.instance.UIManager.SmallMSG("회피의 물약 효과 종료!");
                        break;
                }
            }
        }
    }

    public void ResetItem()
    {
        Player player = GameManager.instance.player;

        if (Turn > 0)
        {
            switch (ItemType)
            {
                case 2:
                    player.attack /= 1.3f;
                    break;

                case 3:
                    player.attack /= 1.3f;
                    break;

                case 4:
                    player.eva /= 2f;
                    break;
            }
        }

        Turn = 0;
    }
}