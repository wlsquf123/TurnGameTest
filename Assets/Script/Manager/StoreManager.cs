using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public SkillBook[] SkillBooks;

    public void ResetStore()
    {
        foreach (SkillBook book in SkillBooks)
        {
            book.ResetBook();
        }
    }
}
