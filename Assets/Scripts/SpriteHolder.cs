using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHolder : MonoBehaviour
{
    public Sprite blueCard;
    public Sprite goldCard;
    public Sprite purpleCard;

    public Sprite blueLevelBG;
    public Sprite goldLevelBG;
    public Sprite puprleLevelBG;

    public List<Sprite> rodList;

    private static SpriteHolder instance = null;

    public static SpriteHolder Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public Sprite GetCard(int quality)
    {
        switch(quality)
        {
            case 0:
                return blueCard;
            case 1:
                return goldCard;
            case 2:
                return purpleCard;
            default:
                return blueCard;
        }
    }

    public Sprite GetLevelBG(int quality)
    {
        switch (quality)
        {
            case 0:
                return blueLevelBG;
            case 1:
                return goldLevelBG;
            case 2:
                return puprleLevelBG;
            default:
                return blueLevelBG;
        }
    }

    public Sprite GetRod(int id)
    {
        return rodList[id % rodList.Count];
    }
}
