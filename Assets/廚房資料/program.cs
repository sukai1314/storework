using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
[System.Serializable]

public class BentoRecip
{
    public string bentoName;
    public int riceNeeded;
    public int eggNeeded;
    public int meatNeeded;
}

public class program : MonoBehaviour
{    
    [Header("所有便當配方")]
    public List<BentoRecip> allrecipes;

    //新增菜點
    [Header("取得AddItem")]
    public AddItem addItemComponent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
  
    // Update is called once per frame
    void Update()
    {
        if(addItemComponent!=null) {
            int riceCount=addItemComponent.playerPlate.currentRice;
            int eggCount = addItemComponent.playerPlate.currentEgg;
            int meatCount = addItemComponent.playerPlate.currentMeat;

            //建立字典
            Dictionary<string, int> plateDic = new Dictionary<string, int>()
            {
                { "飯",riceCount},
                {"蛋", eggCount },
                {"肉",meatCount }
            };
        }
            //建立菜單
        
        //控制計時

        //現在手上的餐點

        //顯示滑鼠

    }
    public void CheckOrder()
    {
        Debug.Log("開始比對");
        int riceCount = addItemComponent.playerPlate.currentRice;
        int eggCount = addItemComponent.playerPlate.currentEgg;
        int meatCount = addItemComponent.playerPlate.currentMeat;
        foreach (BentoRecip checkOrder in allrecipes)
        {
            //Debug.Log($"{checkOrder.bentoName}{checkOrder.riceNeeded}{checkOrder.meatNeeded}{checkOrder.eggNeeded}");
            //Debug.Log($"{ riceCount}{meatCount}{eggCount}");
            if(checkOrder.riceNeeded==riceCount &&
                checkOrder.eggNeeded==eggCount &&
                checkOrder.meatNeeded==meatCount)
            {
                Debug.Log("餐點正確");
            }
            Debug.Log("失敗");
        }
    }

}


