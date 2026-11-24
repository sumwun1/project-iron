using UnityEngine;

[CreateAssetMenu(fileName = "BranchSO", menuName = "Scriptable Objects/BranchSO")]
public class BranchSO : ScriptableObject
{
    public Sprite[] pages;
    public BranchSO[] branches;
    public Sprite buttonSprite;
    public string buttonText;
    public int type;
    //0: one next branch
    //1: buttons
    //2: least points
    public int aPoints;
    public int bPoints;
    public int cPoints;
    public int buttonType;
    //0: row on bottom
    //1: column on bottom right
    //2: sprites

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
