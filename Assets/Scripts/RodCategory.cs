using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RodCategory : MonoBehaviour
{
    public int categoryId;
    public TextMeshProUGUI categoryName;

    public GameObject rodItemPrefab;
    public Transform rodParent;

    private GameObject parentPrefab;
    private List<RodItem> rodItemList;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void SetVisieble(bool isVisible)
    {
        if(isVisible)
        {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void CreateRodList(List<RodInfo> rodList, int category, Action<RodInfo> buttonAction)
    {
        rodItemList = new List<RodItem>();
        parentPrefab = rodParent.gameObject;
        categoryId = category;
        categoryName.text = "Category " + categoryId;
        ClearChildren();
        for(int i=0; i< rodList.Count; i++)
        {
            GameObject item = Instantiate(rodItemPrefab);
            RodItem rodItem = item.GetComponent<RodItem>();
            rodItem.SetInfo(rodList[i]);
            rodItem.SetOnClickAction(buttonAction);
            if(rodParent.childCount >= 4)
            {
                CreateNewParent();
            }
            item.transform.SetParent(rodParent);
            item.transform.localScale = Vector3.one;
            rodItemList.Add(rodItem);
        }
    }

    public void SetCurrentRod(int rodId)
    {
        foreach(RodItem rodItem in rodItemList)
        {
            rodItem.SetCurrentRod(rodId);
        }
    }

    private void CreateNewParent()
    {
        GameObject newParent = Instantiate(parentPrefab);
        ((RectTransform)newParent.transform).sizeDelta = new Vector2(0,240);
        newParent.transform.SetParent(transform);
        newParent.transform.localScale = Vector3.one;
        rodParent = newParent.transform;
        ClearChildren();
    }

    private void ClearChildren()
    {
        while(rodParent.childCount > 0)
        {
            Transform child = rodParent.GetChild(0);
            DestroyImmediate(child.gameObject);
        }
    }
}
