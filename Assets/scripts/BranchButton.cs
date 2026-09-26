using UnityEngine;

public class BranchButton : MonoBehaviour
{
    BranchSO branch;
    Manager manager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBranch(BranchSO inBranch)
    {
        branch = inBranch;
        manager = Manager.instance;
    }

    public void OnClick()
    {
        manager.ChooseBranch(branch);
    }
}
