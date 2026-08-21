using UnityEngine;
using UnityEngine.UI;

public class Stage2Boss : Enemy
{
    public override float EnemyMaxHp => 500;
    public override float EnemyAttack => 30;
    public override float EnemyDef => 45;
    public override float EnemySpeed => 14;
    public override int EnemyExp => 300 * EnemyLv;

    private void Start()
    {
        EnemyLv = 7;
        EnemyHp = EnemyMaxHp;
    }

    public bool HalfUsed = false;
    public int DownTurn = 0;
    public bool Confusion = false;

    public override void Attack()
    {
        Turn++;

        if (Confusion)
        {
            foreach (Skill sk in FindObjectsByType<Skill>(FindObjectsSortMode.None))
            {
                sk.GetComponent<Button>().interactable = true;
            }

            Confusion = false;
        }

        if (DownTurn > 0)
        {
            DownTurn--;

            if (DownTurn == 0)
            {
                GameManager.instance.player.attack /= 0.7f;
                GameManager.instance.UIManager.BigMSG("공격력이 원래대로 돌아왔습니다!");
            }
        }

        if (Turn % 5 == 0)
        {
            EnemyAnimator.Play("attack3");
            GameManager.instance.player.Damage(EnemyAttack * 1.2f);
            foreach (Skill sk in FindObjectsByType<Skill>(FindObjectsSortMode.None))
            {
                if (!(sk is 일반))
                {
                    sk.GetComponent<Button>().interactable = false;
                }
            }
            Confusion = true;
            GameManager.instance.UIManager.BigMSG("보스가 혼란의 일격을 사용했습니다!");
        }
        if (Turn % 9 == 0)
        {
            EnemyAnimator.Play("attack2");
            GameManager.instance.player.Damage(EnemyAttack * 2);
            GameManager.instance.UIManager.BigMSG("보스가 혼신의 일격을 사용했습니다!");
        }

        if (EnemyHp <= EnemyMaxHp / 2 && !HalfUsed)
        {
            GameManager.instance.player.attack *= 0.7f;
            HalfUsed = true;
            DownTurn = 4;
            GameManager.instance.UIManager.BigMSG("보스가 플레이어의 공격력을 4턴간 30% 감소시켰습니다!");
        }
        else
        {
            base.Attack();
        }

    }

    private void OnDestroy() // 자동으로 호출. 4턴전에 죽이면 ㅇㅇ 원상 복구
    {
        if (DownTurn > 0)
        {
            GameManager.instance.player.attack /= 0.7f;
        }
    }
}
