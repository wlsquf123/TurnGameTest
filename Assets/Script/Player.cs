using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Animator PlayerAnimator;

    public int Lv = 1;

    public float MaxExp = 100f;
    public float Exp = 0f;

    public float MaxHp = 100f;
    public float Hp = 0;

    public float MaxMp = 50f;
    public float Mp = 0;

    public float attack = 20f;
    public float Def = 10f;
    public int speed = 10;

    public float crit = 10f;
    public float eva = 15f;

    public int bag = 6;

    public bool IsDid = false;
    public bool isDamage = false;

    [Header("돈&타이머")]
    public int Money = 0;
    public float Timer = 0;
    public Text TimerText;

    [Header("상태UI")]
    public Text LvText;
    public Image ExpImage;
    public Image HpImage;
    public Image MpImage;
    public Text ExpText;
    public Text HpText;
    public Text MpText;
    public Text attackText;
    public Text DefText;
    public Text speedText;
    public Text CritText;
    public Text evaText;
    public Text MoneyText;

    [Header("장비")]
    public Equipment 무기;
    public Equipment 갑옷;

    private void Start()
    {
        Hp = MaxHp;
        Mp = MaxMp;

        attack += 무기.AddAttack;
        crit += 무기.AddCrit;
        Def += 갑옷.AddDef;
    }

    private void Update()
    {
        Timer += Time.deltaTime;

        LvText.text = "Lv. " + Lv + " 플레이어";
        ExpImage.fillAmount = Exp / MaxExp;
        HpImage.fillAmount = Hp / MaxHp;
        MpImage.fillAmount = Mp / MaxMp;
        HpText.text = Hp.ToString("F1") + " / " + MaxHp;
        MpText.text = Mp + " / " + MaxMp;
        ExpText.text = Exp + " / " + MaxExp;
        attackText.text = "공격력: " + attack;
        DefText.text = "방어력: " + Def;
        speedText.text = "속도: " + speed;
        CritText.text = "크리티컬: " + crit;
        evaText.text = "회피율: " + eva;

        MoneyText.text = "돈: " + Money;
        TimerText.text = "타이머: " + Timer.ToString("F1");

        if (Lv >= 10) return;
        if (MaxExp <= Exp)
        {
            Exp -= MaxExp;
            ChatExp();
        }
        if (Lv >= 2)
        {
            // 스킬
        }
        if (Lv >= 4)
        {
            // 스킬
        }
        if (Lv >= 6)
        {
            // 스킬
        }
    }

    // 플레이어 피해
    public void Damage(float damage)
    {
        // 회피
        int evaRandom = Random.Range(0, 100);

        if (evaRandom < eva)
        {
            PlayerAnimator.Play("Eva");
            Debug.Log("플레이어 회피!");
            return;
        }

        // 방어력
        float damagePercent = 1f - (Def / 100f);

        // 최소 10% 피해
        damagePercent = Mathf.Max(damagePercent, 0.1f);

        damage *= damagePercent;

        if (isDamage) return;

        PlayerAnimator.Play("Damage");
        Hp -= damage;

        if (Hp <= 0)
        {
            Hp = 0;
            IsDid = true;

            Debug.Log("플레이어 사망");
            PlayerAnimator.Play("Die", 0, 0f);
        }
    }

    public bool SetMP(int index)
    {
        if (Mp < index)
        {
            return false;
        }
        Mp -= index;
        return true;
    }

    public void SetExp(int add)
    {
        Exp += add;
    }

    public void ChatExp()
    {
        Lv++;
        MaxExp += 100;
        MaxHp += 20;
        MaxMp += 10;
        attack += 10;
    }
}
