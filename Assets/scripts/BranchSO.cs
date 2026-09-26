using UnityEngine;

[CreateAssetMenu(fileName = "BranchSO", menuName = "Scriptable Objects/BranchSO")]
public class BranchSO : ScriptableObject
{
    public Sprite[] pages;
    public BranchSO[] branches;
    public string buttonText;

    public int GetLength()
    {
        return pages.Length;
    }

    public int GetBranchCount()
    {
        return branches.Length;
    }

    public Sprite GetPage(int index)
    {
        return pages[index];
    }

    public BranchSO GetBranch(int index)
    {
        return branches[index];
    }
}
