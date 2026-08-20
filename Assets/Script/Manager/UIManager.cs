using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Animator UIAnimator;
    public Animator BigMsgAnimator;
    public Animator SmallMsgAnimator;
    public Animator SkillAnimator;

    public GameObject ½Â¸®Ã¢;

    public Text BigMsgText;
    public Text SmallMsgText;

    public void BigMSG(string msg)
    {
        BigMsgText.text = msg;
        BigMsgAnimator.Play("MsgEnter", 0, 0f);
    }

    public void SmallMSG(string msg)
    {
        SmallMsgText.text = msg;
        SmallMsgAnimator.Play("EnterSmallMSG", 0, 0f);
    }
}
