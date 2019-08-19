using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    private const int GAP = 150;
    public ScrollRect scroll;

    private List<RectTransform> contentItems;
    private float lastY;
    private float viewportHeigth;

    private void Awake()
    {
        contentItems = new List<RectTransform>();
    }

    public void RefreshList()
    {
        contentItems = new List<RectTransform>();
        for(int i=0; i<scroll.content.childCount; i++)
        {
            contentItems.Add(scroll.content.GetChild(i).GetComponent<RectTransform>());
        }
        viewportHeigth = scroll.viewport.rect.height;
    }

    public void OnScrollChange(Vector2 v)
    {
        if(contentItems.Count < 1)
        {
            return;
        }
        float currentY = scroll.content.localPosition.y;
        float previousItemsHeigth = 0;
        for (int i=0; i<contentItems.Count; i++)
        {
            float itemHeigth = contentItems[i].sizeDelta.y;
            if (CanShowItem(currentY, itemHeigth, previousItemsHeigth))
            {
                contentItems[i].GetComponent<CanvasGroup>().alpha = 1;
            }
            else
            {
                contentItems[i].GetComponent<CanvasGroup>().alpha = 0;
            }
            previousItemsHeigth += itemHeigth;
        }
        lastY = currentY;
    }

    public bool CanShowItem(float currentY, float itemHeigth, float previousItemsHeigth)
    {
        if(currentY > previousItemsHeigth + itemHeigth + GAP)
        {
            return false;
        }
        if(currentY < previousItemsHeigth + GAP - viewportHeigth)
        {
            return false;
        }
        return true;
    }
}
