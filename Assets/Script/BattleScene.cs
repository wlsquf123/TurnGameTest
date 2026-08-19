using UnityEngine;

public class BattleScene : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.BattleManager.StartBattle();
    }
}