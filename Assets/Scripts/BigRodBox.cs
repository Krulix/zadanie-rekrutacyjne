using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BigRodBox : MonoBehaviour
{
    public TextMeshProUGUI rodName;
    public TextMeshProUGUI rodCategory;
    public Image levelBG;
    public TextMeshProUGUI rodLevel;
    public TextMeshProUGUI cardsAmount;
    public GameObject arrowUp;
    public Image levelBar;
    public Image statBar1;
    public Image statBar2;
    public Image statBar3;
    public Image statBar4;
    public Image statBar5;
    public List<Image> starList;

    private int maxStatBarWidth;
    private int maxLevelBarWidth;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        maxStatBarWidth = Mathf.FloorToInt(statBar1.rectTransform.sizeDelta.x);
        maxLevelBarWidth = Mathf.FloorToInt(levelBar.rectTransform.sizeDelta.x);
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void SetVisieble(bool isVisible)
    {
        if (isVisible)
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

    public void SetCurrentRodInfo(RodInfo info)
    {
        rodName.text = info.rodName;
        rodCategory.text = "CATEGORY "+info.category;
        rodLevel.text = info.level.ToString();
        levelBG.sprite = SpriteHolder.Instance.GetLevelBG(info.quality);
        cardsAmount.text = info.cardsAmount + "/" + info.nextLevelCards;
        float precentFill = 1.0f * info.cardsAmount / info.nextLevelCards;
        arrowUp.SetActive(info.cardsAmount >= info.nextLevelCards);
        if(precentFill >= 1)
        {
            levelBar.rectTransform.sizeDelta = new Vector2(maxLevelBarWidth, levelBar.rectTransform.sizeDelta.y);
        }
        else
        {
            levelBar.rectTransform.sizeDelta = new Vector2(precentFill * maxLevelBarWidth, levelBar.rectTransform.sizeDelta.y);
        }        
        System.Random random = new System.Random();
        float randomNum = (float)random.NextDouble();
        statBar1.rectTransform.sizeDelta = new Vector2(randomNum * maxStatBarWidth, statBar1.rectTransform.sizeDelta.y);
        randomNum = (float)random.NextDouble();
        if(randomNum < 0.2f)
        {
            randomNum += 0.2f;
        }
        statBar2.rectTransform.sizeDelta = new Vector2(randomNum * maxStatBarWidth, statBar2.rectTransform.sizeDelta.y);
        randomNum = (float)random.NextDouble();
        if (randomNum < 0.2f)
        {
            randomNum += 0.2f;
        }
        statBar3.rectTransform.sizeDelta = new Vector2(randomNum * maxStatBarWidth, statBar3.rectTransform.sizeDelta.y);
        randomNum = (float)random.NextDouble();
        if (randomNum < 0.2f)
        {
            randomNum += 0.2f;
        }
        statBar4.rectTransform.sizeDelta = new Vector2(randomNum * maxStatBarWidth, statBar4.rectTransform.sizeDelta.y);
        randomNum = (float)random.NextDouble();
        if (randomNum < 0.2f)
        {
            randomNum += 0.2f;
        }
        statBar5.rectTransform.sizeDelta = new Vector2(randomNum * maxStatBarWidth, statBar5.rectTransform.sizeDelta.y);
        randomNum = random.Next(0,10)+1;
        SetStars(randomNum/2);
    }

    private void SetStars(float stars)
    {
        for(int i =0; i<5; i++)
        {
            if(stars>=(i+1))
            {
                starList[i].fillAmount = 1;
            }
            else if(stars > i)
            {
                starList[i].fillAmount = stars - i;
            }
            else
            {
                starList[i].fillAmount = 0;
            }

        }
    }
}
