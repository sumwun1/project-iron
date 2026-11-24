using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
	public static Manager instance;
	public GameObject textButtonPrefab;
	public GameObject imageButtonPrefab;
	public GameObject titleScreen;
	public Transform canvas;
	public BranchSO branch;
	//public Image[] layers;
	public Image firstPanel;
	GameObject[] buttons;
	int[] points;
	int pageNumber;
	//int layerNumber;
	//int mode;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pageNumber = 0;
		buttons = new GameObject[0];
		points = new int[3];
		points[0] = 0;
        points[1] = 0;
        points[2] = 0;
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
		ChooseBranch(branch);
    }

	public void SetPage()
	{
        firstPanel.sprite = branch.GetPage(pageNumber);
        Debug.Log(branch.GetLength() + " " + pageNumber + " " + branch.type);

        if (branch.GetLength() <= pageNumber + 1 && (1 == branch.type))
        {
            //Debug.Log("ending branch");
            buttons = new GameObject[branch.GetBranchCount()];

            for (int a = 0; branch.GetBranchCount() > a; a++)
            {
                Transform button = null;
                //Debug.Log("button type: " + branch.buttonType);

                if (2 == branch.buttonType)
                {
                    //Debug.Log("instantiating image buttons");
                    button = Instantiate(imageButtonPrefab).transform;
                    button.GetChild(0).GetComponent<Image>().sprite = branch.GetBranch(a).buttonSprite;
                }
                else
                {
                    //Debug.Log("instantiating text buttons");
                    button = Instantiate(textButtonPrefab).transform;
                    button.GetChild(0).GetComponent<TMP_Text>().text = branch.GetBranch(a).buttonText;
                }

                button.SetParent(canvas);
                RectTransform buttonRect = button.GetComponent<RectTransform>();

                if (1 == branch.buttonType)
                {
                    buttonRect.anchorMin = new Vector2(2f / 3f, (a + 1f) / (branch.GetBranchCount() * 2f + 2f));
                    buttonRect.anchorMax = new Vector2(2f / 3f, (a + 1f) / (branch.GetBranchCount() * 2f + 2f));
                }
                else
                {
                    buttonRect.anchorMin = new Vector2(1f / 6f + (a * 2f + 1f) / (branch.GetBranchCount() * 3f), 0.25f);
                    buttonRect.anchorMax = new Vector2(1f / 6f + (a * 2f + 1f) / (branch.GetBranchCount() * 3f), 0.25f);
                }

                buttonRect.anchoredPosition = Vector2.zero;
                button.GetComponent<BranchButton>().SetBranch(branch.GetBranch(a));
                buttons[a] = button.gameObject;
            }
        }
    }

    public void NextPage()
	{
		//Debug.Log("calling NextPage");
        Debug.Log(branch.GetLength() + " " + pageNumber);

        if (titleScreen.activeSelf)
		{
			return;
		}
		/*for(int a = 0; layers.Length > a; a++)
		{
			layers[a].sprite = null;
		}*/
        if (branch.GetLength() <= pageNumber + 1)
        {
			//Debug.Log("not instantiating buttons");
			if(0 == branch.type)
			{
				ChooseBranch(branch.GetBranch(0));
			}
			else if(2 == branch.type)
			{
				int index = 0;

				for(int a = 1; a < 3; a++)
				{
					if (points[a] < points[index])
					{
						index = a;
					}
				}

				ChooseBranch(branch.GetBranch(index));
			}

			return;
        }

        pageNumber++;
        SetPage();
    }

    public void ChooseBranch(BranchSO nextBranch)
	{
		for(int a = 0; buttons.Length > a; a++)
		{
			Destroy(buttons[a]);
		}

        branch = nextBranch;
        pageNumber = 0;
        SetPage();
		points[0] += branch.aPoints;
		points[1] += branch.bPoints;
		points[2] += branch.cPoints;
    }
}
