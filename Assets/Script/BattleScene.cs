using UnityEngine;

public class BattleScene : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.UIManager.MapObj.SetActive(false);
        GameManager.instance.BattleManager.StartBattle();
    }
}