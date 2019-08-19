using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodWindow : MonoBehaviour
{
    private const int CATEGORY_COUNT = 3;

    public GameObject categoryPrefab;
    public Transform categoryParent;    
    public BigRodBox bigRodBox;
    public RodRenderer rodRenderer;
    public ScrollController scrollController;
    public CanvasGroup canvasGroup;
    public InitWindow initWindow;
    public Animation animation;

    private List<RodCategory> categoryList;
    private RodInfoManager manager;
    private int currentRodId;

    private void Awake()
    {
        manager = new RodInfoManager();
        categoryList = new List<RodCategory>();
        Hide();
    }

    private void Start()
    {
        bigRodBox.SetRotateAction(rodRenderer.RotateRod);
    }

    public void Hide()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
        initWindow.Show();
    }

    public void Show(int rodCount)
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
        manager.CreateNewRods(rodCount);
        ResetCategory();
        animation.Play();
        for(int i=0; i<= CATEGORY_COUNT; i++)
        {
            List<RodInfo> catList = manager.rodInfoList.FindAll(x => x.category == i);
            categoryList[i].CreateRodList(catList, i, ChangeRod);
        }
        ChangeRod(manager.GetRod(1));
        scrollController.RefreshList();
    }

    private void ResetCategory()
    {
        while(categoryParent.childCount > 1)
        {
            Transform child = categoryParent.GetChild(1);
            DestroyImmediate(child.gameObject);
        }
        for (int i = 0; i <= CATEGORY_COUNT; i++)
        {
            GameObject item = Instantiate(categoryPrefab);
            item.transform.SetParent(categoryParent);
            item.transform.localScale = Vector3.one;
            RodCategory category = item.GetComponent<RodCategory>();
            categoryList.Add(category);
        }
    }

    public void ChangeRod(RodInfo rodInfo)
    {
        if(currentRodId == rodInfo.rodId)
        {
            return;
        }
        for (int i = 0; i <= CATEGORY_COUNT; i++)
        {
            categoryList[i].SetCurrentRod(rodInfo.rodId);
        }
        bigRodBox.SetCurrentRodInfo(rodInfo);
        rodRenderer.ChangeRod();
        currentRodId = rodInfo.rodId;
    }
}
