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
}
