using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
	public static Manager instance;
	public GameObject titleScreen;
	public BranchSO branch;
	//public Image[] layers;
	public Image firstPanel;
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
		
		pageNumber++;
        firstPanel.sprite = branch.GetPage(pageNumber);
    }
}
