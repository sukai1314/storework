using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class newpotitem : AddItem
{
    public static newpotitem potItem { get; private set; }

    public Transform rec;
    private void Awake()
    {
     if(potItem != null && potItem != this)
     {
        Debug.Log("已有鍋子物件");
        Destroy(potItem);
        return;
        }
        potItem = this;
    }
    void Start()
    {
     eventDic.Add("add egg(Clone)", (string btnName) => { AddEgg(btnName); });
     eventDic.Add("add meat(Clone)", (string btnName) => { AddMeat(btnName); });

        GetButtonName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Button[] button;
    //取得按鈕名稱
    public void GetButtonName()
    {
        foreach(Button btn in button)
        {
            if (btn != null)
            {
                string currentBtnName=btn.name;
                btn.onClick.AddListener(() => 
                MakeDic(currentBtnName));
            }
        }
    }

    //用名稱製作字典
    public void MakeDic(string btnName)
    {
        foreach(var key in new List<string>(potItemData.Keys))
        {
            if(potItemData[key].newpotItem != null)
            {
                RemoveBtnClick(key);
            }
        }
        potItemInfo info = new potItemInfo();
        info.potItem =Resources.Load<GameObject>(btnName);
        info.newpotItem = Instantiate(info.potItem,rec);
        info.rectTransform = info.newpotItem.GetComponent<RectTransform>();
        if(info.rectTransform != null)
        {
            CreatBtn(info.newpotItem);
            switch(btnName)
            {
                case "add egg(Clone)":
                    info.rectTransform.anchoredPosition= new Vector2(590f, -38f);
                    break;
                case "add meat(Clone)":
                    info.rectTransform.anchoredPosition= new Vector2(693f, -614f);
                    break;
                default:
                    Debug.Log($"沒有對應的按鈕名稱:{btnName}");
                    break;
            }
        }
        potItemData[btnName]= info;
    }

    struct potItemInfo
    {
        public GameObject potItem;
        public GameObject newpotItem;

        public RectTransform rectTransform;
    }
    Dictionary<string, potItemInfo> potItemData= new Dictionary<string, potItemInfo>();
    //用字典取得prefab
    //用prefab製作元件
    //事件字典
    Dictionary<string, Action<string>> eventDic = new Dictionary<string, Action<string>>();
    public void EventDic(string btn)
    {
        if (eventDic.ContainsKey(btn))
        {
            eventDic[btn].Invoke(btn);
        }
    }
    //動態產生按鈕
    public void CreatBtn(GameObject newpotItem)
    {
        if (newpotItem != null)
        {
            Button btn = newpotItem.GetComponent<Button>();
            if (btn != null)
            {
                Debug.Log($"按鈕名稱:{btn.name}");
                btn.onClick.AddListener(() => { EventDic(btn.name); });
            }
        }
    }
    //移除事件及摧毀物件
    public void RemoveBtnClick(string btnName)
    {
        string cleanName = btnName.Replace("(Clone)", "");
        if (potItemData.ContainsKey(cleanName))
        {
            if(potItemData[cleanName].newpotItem != null)
            {
            Debug.Log($"移除按鈕事件:{cleanName}");
            potItemData[cleanName].newpotItem.GetComponent<Button>().onClick.RemoveAllListeners();
            Destroy(potItemData[cleanName].newpotItem);
            }
            potItemData.Remove(cleanName);
        }
        else
        {
            Debug.Log($"字典中沒有{cleanName}");
        }
    }
}