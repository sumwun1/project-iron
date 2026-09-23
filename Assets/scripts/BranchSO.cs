using UnityEngine;

[CreateAssetMenu(fileName = "BranchSO", menuName = "Scriptable Objects/BranchSO")]
public class BranchSO : ScriptableObject
{
    public Sprite[] pages;
    public BranchSO[] branches;

    public int GetLength()
    {
        return pages.Length;
    }

    public Sprite GetPage(int index)
    {
        return pages[index];
    }
}
