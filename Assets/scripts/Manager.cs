using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
	public static Manager instance;
	public GameObject buttonPrefab;
	public GameObject titleScreen;
	public Transform canvas;
	public BranchSO branch;
	//public Image[] layers;
	public Image firstPanel;
	GameObject[] buttons;
	int pageNumber;
	//int layerNumber;
	//int mode;
	int aPoints;
	int bPoints;
	int cPoints;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pageNumber = 0;
		//layerNumber = 0;
		instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	/*public void Next()
	{
	    if(2 == mode)
		{
			NextPage();
		}
	}*/

	public void StartGame()
	{
		titleScreen.SetActive(false);
        firstPanel.sprite = branch.GetPage(pageNumber);
    }

    public void NextPage()
	{
        /*for(int a = 0; layers.Length > a; a++)
		{
			layers[a].sprite = null;
		}*/
        if (branch.GetLength() <= pageNumber + 1)
        {
			return;
        }

        pageNumber++;
        firstPanel.sprite = branch.GetPage(pageNumber);

		if(branch.GetLength() <= pageNumber + 1)
		{
			buttons = new GameObject[branch.GetBranchCount()];

			for(int a = 0; branch.GetBranchCount() > a; a++)
			{
				Transform button = Instantiate(buttonPrefab).transform;
				button.SetParent(canvas);
				button.GetChild(0).GetComponent<TMP_Text>().text = branch.GetBranch(a).buttonText;
				RectTransform buttonRect = button.GetComponent<RectTransform>();
				buttonRect.anchorMin = new Vector2(1f / 6f + (a * 2f + 1f) / (branch.GetBranchCount() * 3f), 0.25f);
                buttonRect.anchorMax = new Vector2(1f / 6f + (a * 2f + 1f) / (branch.GetBranchCount() * 3f), 0.25f);
                buttonRect.anchoredPosition = Vector2.zero;
				button.GetComponent<BranchButton>().SetBranch(branch.GetBranch(a));
				buttons[a] = button.gameObject;
            }
		}
    }

    public void ChooseBranch(BranchSO inBranch)
	{
		branch = inBranch;
		pageNumber = 0;
        firstPanel.sprite = branch.GetPage(pageNumber);

		for(int a = 0; buttons.Length > a; a++)
		{
			Destroy(buttons[a]);
		}
    }
}
