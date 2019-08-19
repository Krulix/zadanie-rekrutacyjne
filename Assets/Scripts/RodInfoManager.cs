using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodInfoManager
{
    public List<RodInfo> rodInfoList;

    public void CreateNewRods(int count)
    {
        rodInfoList = new List<RodInfo>();
        for(int i=0; i<count; i++)
        {
            rodInfoList.Add(CreateRod(i));
        }
    }

    public RodInfo GetRod(int id)
    {
        return rodInfoList.Find(x => x.rodId == id);
    }

    private RodInfo CreateRod(int id)
    {
        System.Random random = new System.Random();
        RodInfo rod = new RodInfo {
            rodId = id,
            quality = id%3,
            level = id%5+1,
            cardsAmount = id%15,
            rodName = "ROD "+id,
            category = id%4
        };
        return rod;
    }
}
