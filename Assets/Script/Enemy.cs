using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public string Name;
    public int EnemyLv;

    public virtual float EnemyMaxHp { get; }
    public float EnemyHp;
    public virtual float EnemyAttack { get; }
    public virtual float EnemyDef { get; }
    public virtual float EnemySpeed { get; }
    public virtual int EnemyExp { get; }

    public int Turn;

    public bool IsDefing = false;
    public bool IsDie = false;

    [Header("약점격파")]
    public int SkillTurn = 0;

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
        LvNameText.text = "Lv. " + EnemyLv + " " + Name;
        EnemyHpBar.fillAmount = EnemyHp / EnemyMaxHp;
        EnemyHpText.text = EnemyHp + "/" + EnemyMaxHp;
        EnemyAttackText.text = EnemyAttack.ToString();
        EnemyDefText.text = GetDef().ToString();
        EnemySpeedText.text = EnemySpeed.ToString();
    }

    private void OnMouseDown()
    {
        GameManager.instance.BattleManager.SelectEnemy(this);
    }

    // 몬스터 공격
    public virtual void Attack()
    {
        EnemyAnimator.Play("attack");
        GameManager.instance.player.Damage(EnemyAttack);
    }


    // 몬스터가 피해 받기
    public void Damage(float damage)
    {
        // 방어력만큼 피해 감소
        float damagePercent = 1f - (GetDef() / 100f);
        // 최소 10% 피해
        damagePercent = Mathf.Max(damagePercent, 0.1f);

        damage *= damagePercent;

        if (IsDefing)
        {
            float defPercent = 1f - ((50f + EnemyLv * 3f) / 100f);

            damage *= defPercent;
        }

        EnemyHp -= damage;


        if (EnemyHp <= 0)
        {
            EnemyHp = 0;
            IsDie = true;

            GameManager.instance.player.SetExp(EnemyExp); // 경험치
            GameManager.instance.player.Money += EnemyExp / 2; // 돈
            EnemyAnimator.Play("die");
            Destroy(gameObject, 3f);
        }
        else
        {
            EnemyAnimator.Play("damage");
        }
    }

    public void DefenseCheck()
    {
        int random = Random.Range(0, 100);

        if (random < 10)
        {
            IsDefing = true;
            DefImage.gameObject.SetActive(true);

            GameManager.instance.UIManager.BigMSG(Name + " 방어!");
        }
        else
        {
            IsDefing = false;
            DefImage.gameObject.SetActive(false);
        }
    }

    public float GetDef()
    {
        // 약점격파
        if (SkillTurn > 0)
        {
            return EnemyDef * 0.7f;
        }

        return EnemyDef;
    }

    public void TurnDown()
    {
        if (SkillTurn > 0)
        {
            SkillTurn--;
        }
    }
}
