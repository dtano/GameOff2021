using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScreen : MonoBehaviour
{
    [SerializeField] GameObject pageParent;
    [SerializeField] GameObject coverPanel;
    private Transform[] pages;

    private int currPage;
    private int lastPage;
    
    // Start is called before the first frame update
    void Awake()
    {
        pages = new Transform[pageParent.transform.childCount];
        for(int i = 0; i < pageParent.transform.childCount; i++){
            pages[i] = pageParent.transform.GetChild(i);
            HidePage(i);
        }

        lastPage = pageParent.transform.childCount - 1;

        // Turn off all pages except current
        ShowPage(currPage);
    }

    private void HidePage(int index)
    {
        pages[index].gameObject.SetActive(false);
    }

    private void ShowPage(int index)
    {
        pages[index].gameObject.SetActive(true);
    }

    public void NextPage()
    {
        HidePage(currPage);
        currPage++;
        ShowPage(currPage);
    }

    public void Back()
    {
        HidePage(currPage);
        currPage--;
        ShowPage(currPage);
    }

    public void EndTutorial()
    {
        coverPanel.SetActive(false);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
