using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RodItem : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI rodName;
    public Image rodImage;
    public Image cardImage;
    public Image levelBar;
    public Image levelBG;
    public TextMeshProUGUI levelNumber;
    public TextMeshProUGUI cardsCount;
    public Image arrowImage;
    public GameObject currentRod;

    private RodInfo info;

    public void SetInfo(RodInfo rodInfo)
    {
        info = rodInfo;
        int maxBarWidth = Mathf.FloorToInt(levelBar.rectTransform.sizeDelta.x);
        rodName.text = rodInfo.rodName;
        rodImage.sprite = SpriteHolder.Instance.GetRod(rodInfo.rodId);
        SetCardImage(rodInfo.quality);
        levelNumber.text = rodInfo.level.ToString();
        cardsCount.text = rodInfo.cardsAmount + "/" + rodInfo.nextLevelCards;
        float precentFill = 1.0f * rodInfo.cardsAmount / rodInfo.nextLevelCards;
        if (precentFill >= 1)
        {
            levelBar.rectTransform.sizeDelta = new Vector2(maxBarWidth, levelBar.rectTransform.sizeDelta.y);
        }
        else
        {
            levelBar.rectTransform.sizeDelta = new Vector2(precentFill * maxBarWidth, levelBar.rectTransform.sizeDelta.y);
        }
        arrowImage.gameObject.SetActive(rodInfo.cardsAmount >= rodInfo.nextLevelCards);
    }

    public void SetOnClickAction(Action<RodInfo> action)
    {
        button.onClick.AddListener(() => action(info));
    }

    private void SetCardImage(int quality)
    {
        cardImage.sprite = SpriteHolder.Instance.GetCard(quality);
        levelBG.sprite = SpriteHolder.Instance.GetLevelBG(quality);
    }

    public void SetCurrentRod(int rodId)
    {
        currentRod.SetActive(rodId == info.rodId);
    }
}
