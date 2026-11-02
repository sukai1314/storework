using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newpotitem : AddItem
{
    public Button[] targetButton;
    public static potitem potEgg {  get; private set; }
    //public GameObject Egg;
    //public GameObject newEgg;
    public Transform canvasTrans;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        //if (Egg != null && Egg != this)
        //{
        //    Debug.Log("已有雞蛋");
        //    Destroy(Egg);
        //    return;
        //}
        foreach (Button btn in targetButton)
        {
            if(potItemDic.ContainsKey(btn.name))
            { 
                if (potItemDic[btn.name].newPotItem != null && potItemDic[btn.name].newPotItem != this)
                {
                  Debug.Log("已有雞蛋");
                  Destroy(potItemDic[btn.name].newPotItem);
                  continue;
                }
            }
        }
            
    }
    void Start()
    {
        //Egg = Resources.Load<GameObject>("Egg");


        foreach (Button btn in targetButton)
        {
            if (btn != null)
            {
                string currentBtnName ;
                currentBtnName= btn.name;
                Debug.Log($"{currentBtnName}");
                //設定新資料
                potInfo itemButton = new potInfo();
                itemButton.potItem = Resources.Load<GameObject>(currentBtnName);
                if (itemButton.potItem != null)
                {
                    itemButton.newPotItem = Instantiate(itemButton.potItem, canvasTrans);
                }
                if (itemButton.newPotItem != null)
                {
                    itemButton.rectTransform= itemButton.newPotItem.GetComponent<RectTransform>();
                }

                btn.onClick.AddListener(() =>
                {
                    //生成按鈕

                    //加入按鈕物件
                    potItemDic[currentBtnName]=itemButton;             
                   Cook(currentBtnName);
                    if (itemButton.rectTransform != null)
                    {
                        CreatBtn(currentBtnName);
                        itemButton.rectTransform.anchoredPosition = new Vector2(590f, -38f);
                    }

                });
            }

        }
        potAct.Add("add egg",AddEgg);
        potAct.Add("add meat", AddMeat);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void CookEgg()
    //{
    //    if (newEgg != null)
    //    {
    //        Debug.Log("已有雞蛋");
    //        return;
    //    }
    //    if (Egg != null)
    //    {
    //        newEgg = Instantiate(Egg, canvasTrans);
    //        RectTransform rectTransform = newEgg.GetComponent<RectTransform>();
    //        if (rectTransform != null)
    //        {
    //            CreatBotton();
    //            rectTransform.anchoredPosition = new Vector2(590f, -38f);
    //        }

    //    }
    //}
    //public void CreatBotton()
    //{
    //    if (newEgg != null)
    //    {
    //        Button btn=newEgg.GetComponent<Button>();
    //        if (btn != null)
    //        {
    //            btn.onClick.AddListener(() => { 
    //                AddEgg(); 
    //            });
    //        }
    //    }
    //}
    //取得餐點事件
    private void Cook(string currentBtnName)
    {
        if (potItemDic[currentBtnName].newPotItem != null)
        {
            Button btn = potItemDic[currentBtnName].newPotItem.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(() => {
                    if(potAct.ContainsKey(currentBtnName))
                    {
                        potAct[currentBtnName].Invoke();
                    }
                    
                });
            }
        }
    }
    public void CreatBtn(string currentBtnName)
    {
        if (potItemDic[currentBtnName].newPotItem != null)
        {
            Button btn = potItemDic[currentBtnName].newPotItem.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(() => {
                    potAct[currentBtnName].Invoke();
                });
            }
        }
    }
    
    public struct potInfo
    {

        public GameObject potItem;
        public GameObject newPotItem;
        public RectTransform rectTransform;
    }
    //字典
    public Dictionary<string, potInfo> potItemDic=new Dictionary<string, potInfo>();
    //事件字典
    private Dictionary<string, Action> potAct = new Dictionary<string, Action>();



}
