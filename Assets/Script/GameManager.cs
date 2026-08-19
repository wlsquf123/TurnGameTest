using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UIManager UIManager;
    public BattleManager BattleManager;

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
}
