using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UIManager UIManager;
    public BattleManager BattleManager;
    public StoreManager StoreManager;

    public Player player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        ChatKey();
    }

    public void LoadeStage(int index)
    {
        SceneManager.LoadScene("Stage" + index);
    }

    public void Next()
    {
        UIManager.StoreObj.SetActive(false);

        string scene = SceneManager.GetActiveScene().name;

        if (scene == "Stage1")
        {
            SceneManager.LoadScene("Stage1Boss");
        }
        else if (scene == "Stage2")
        {
            SceneManager.LoadScene("Stage2Boss");
        }
        else if (scene == "Stage3")
        {
            SceneManager.LoadScene("Stage3Elite");
        }
        else if (scene == "Stage3Elite")
        {
            SceneManager.LoadScene("Stage3Boss");
        }
        else
        {
            UIManager.MapObj.SetActive(true);
        }
    }

    public void ChatKey()
    {
        if (Input.GetKeyDown(KeyCode.F1)) // 무적
        {
            player.isDamage = !player.isDamage;
            if (player.isDamage)
            {
                UIManager.BigMSG("무적모드 사용!");
            }
            else
            {
                UIManager.BigMSG("무적모드 해제!");
            }
        }

        if (Input.GetKeyDown(KeyCode.F2)) // 공격력 100 증가
        {
            UIManager.BigMSG("공격력 100 증가");
            player.attack += 100;
        }

        if (Input.GetKeyDown(KeyCode.F3)) // 체력 최대 회복
        {
            UIManager.BigMSG("HP 최대 회복");
            player.Hp = player.MaxHp;
        }

        if (Input.GetKeyDown(KeyCode.F4)) // 마나 최대 회복
        {
            UIManager.BigMSG("MP 최대 회복");
            player.Mp = player.MaxMp;
        }

        if (Input.GetKeyDown(KeyCode.F5)) // 레벨업 플레이어
        {
            if (player.Lv >= 10)
            {
                UIManager.BigMSG("최대 레벨 달성!");
                return;
            }
            player.ChatExp();
            UIManager.BigMSG( player.Lv + "레벨 증가!");
        }

        if (Input.GetKeyDown(KeyCode.F6)) // 현재 전투의 모든 적 제거
        {
            UIManager.BigMSG("모든 적 제거!");
            BattleManager.AllKillEnemy();
        }

        if (Input.GetKeyDown(KeyCode.F7)) // 메인화면 이동 (메인은 나중에. + 시작버튼 누르면 다 초기화해야하기 때문에 마지막에 제작할거임.)
        {
            UIManager.BigMSG("메인화면 이동");
        }

        if (Input.GetKeyDown(KeyCode.F8)) // 1스테이지 이동
        {
            UIManager.BigMSG("1스테이지 이동");
            SceneManager.LoadScene("Stage1");
        }

        if (Input.GetKeyDown(KeyCode.F9)) // 2스테이지 이동
        {
            UIManager.BigMSG("2스테이지 이동");
            SceneManager.LoadScene("Stage2");
        }

        if (Input.GetKeyDown(KeyCode.F10)) // 3스테이지 이동
        {
            UIManager.BigMSG("3스테이지 이동");
            SceneManager.LoadScene("Stage3");
        }
    }
}
