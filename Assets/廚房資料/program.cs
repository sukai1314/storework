using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Linq;
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
    public TextMeshProUGUI timeLimit;
    public TextMeshProUGUI custormerTimeLimit;
    public TextMeshProUGUI menu;
    string resText="";
    public TextMeshProUGUI orderText;

    public int scare=0;
    public TextMeshProUGUI scareText;

    private Coroutine custCoroutine;
    [Header("所有便當配方")]
    public List<BentoRecip> allrecipes;

    //新增菜點
    [Header("取得AddItem")]
    public AddItem addItemComponent;

    //客戶訂單
    string orderName;
    int riceNeeded;
    int eggNeeded;
    int meatNeeded;

    private void Awake()
    {

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(GameTime(120,timeLimit,()=>SceneManager.LoadScene("gameover")));
        if (allrecipes == null)
        {
            Debug.Log("菜單為空");
        }
        foreach (var recipe in allrecipes) {
         
                resText += $"{recipe.bentoName}benton \nNeed:rice×{recipe.riceNeeded} egg×{recipe.eggNeeded} meat×{recipe.meatNeeded}\n";

        }
        if (menu != null)
        {
            menu.text = resText;
        }
       ShowOrder(); 
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
    public void ShowOrder()
    {
        if (scareText != null)
        {
            scareText.text = "scare : " + scare.ToString();
        }

        List<int> allkeys=customer.custo.customerInfo.Keys.ToList();
        if (allkeys.Count > 0)
        {
            int randKey = allkeys[Random.Range(0, allkeys.Count)];
            customer.custo.showCus(randKey);
            CustomerOrder();
            custCoroutine = StartCoroutine(GameTime(10, custormerTimeLimit, () =>
            { 
            customer.custo.disCus(randKey);
            ShowOrder();
            }));
        }
        else {             Debug.Log("客戶字典沒資料"); }



    }
    public void CheckOrder()
    {
        Debug.Log("開始比對");
        int riceCount = addItemComponent.playerPlate.currentRice;
        int eggCount = addItemComponent.playerPlate.currentEgg;
        int meatCount = addItemComponent.playerPlate.currentMeat;
        Debug.Log($"{riceNeeded}{eggNeeded}{meatNeeded}");
        Debug.Log($"飯{riceCount}蛋{eggCount}肉{meatCount}");
            //Debug.Log($"{checkOrder.bentoName}{checkOrder.riceNeeded}{checkOrder.meatNeeded}{checkOrder.eggNeeded}");
            //Debug.Log($"{ riceCount}{meatCount}{eggCount}");
            if(riceNeeded==riceCount &&
                eggNeeded==eggCount &&
                meatNeeded==meatCount)
            {
                Debug.Log("餐點正確");
            scare++;
            StopCoroutine(custCoroutine);
            custCoroutine=null;
        }
            Debug.Log("失敗");

    }

    public void CustomerOrder()
    {
        int randOrder = Random.Range(0, allrecipes.Count);
        orderName = allrecipes[randOrder].bentoName;
        orderText.text =orderName;
        riceNeeded = allrecipes[randOrder].riceNeeded;
        eggNeeded = allrecipes[randOrder].eggNeeded;
        meatNeeded = allrecipes[randOrder].meatNeeded;
    }
    IEnumerator GameTime(float duration,TextMeshProUGUI targetText,System.Action action)
    {
        float timer = duration;

        while (timer>0f)
        {
            timer -= Time.deltaTime;
            if(targetText!=null)
            {
                targetText.text = timer.ToString("F0");
            }
            yield return null;
        }
        action?.Invoke();
    }

}


