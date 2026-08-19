using UnityEngine;
using UnityEngine.UI;

public  class Enemy : MonoBehaviour
{
    public string Name;
    public int EnemyLv;

    public virtual float EnemyMaxHp { get; }
    public float EnemyHp;
    public virtual float EnemyAttack { get; }
    public virtual float EnemyDef {  get; }
    public virtual float EnemySpeed { get; }
    public virtual int EnemyExp { get; }

    public int Turn;

    public bool IsDefing = false;
    public bool IsDie = false;

    [Header("상태 턴")]
    public int[] SkillTurn = new int[5];

    [Header("UI")]
    public Text LvNameText;
    public Image EnemyHpBar;
    public Text EnemyHpText;
    public Text EnemyAttackText;
    public Text EnemyDefText;
    public Text EnemySpeedText;
    public Image DefImage;

    [Header("애니메이션")]
    public Animator EnemyAnimator;

    private void Update()
    {
        // UI
        LvNameText.text = "Lv. " + EnemyLv + " "+ Name;
        EnemyHpBar.fillAmount = EnemyHp / EnemyMaxHp;
        EnemyHpText.text = EnemyHp + "/" + EnemyMaxHp;
        EnemyAttackText.text = EnemyAttack.ToString();
        EnemyDefText.text = EnemyDef.ToString();
        EnemySpeedText.text = EnemySpeed.ToString();
    }

    private void OnMouseDown()
    {
        GameManager.instance.BattleManager.SelectEnemy(this);
    }

    // 몬스터 공격
    public virtual void Attack(Player pl)
    {
        if (IsDie)
        {
            return;
        }

        pl.Damage(EnemyAttack);

        EnemyAnimator.Play("attack");
    }


    // 몬스터가 피해 받기
    public void Damage(float damage)
    {
        if (IsDie)
        {
            return;
        }

        // 방어력만큼 피해 감소
        float damagePercent = 1f - (GetDef() / 100f);

        // 최소 10% 피해
        damagePercent = Mathf.Max(damagePercent, 0.1f);

        damage *= damagePercent;

        EnemyHp -= damage;


        if (EnemyHp <= 0)
        {
            EnemyHp = 0;
            IsDie = true;

            EnemyAnimator.Play("die");
            Destroy(gameObject, 3f);
        }
        else
        {
            EnemyAnimator.Play("damage");
        }
    }

    public float GetDef()
    {
        // 약점격파
        if (SkillTurn[0] > 0)
        {
            return EnemyDef * 0.7f;
        }

        return EnemyDef;
    }

    public void TurnDown()
    {
        for (int i = 0; i < SkillTurn.Length; i++)
        {
            if (SkillTurn[i] > 0)
            {
                SkillTurn[i]--;
            }
        }
    }
}
