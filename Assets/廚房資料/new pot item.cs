using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System.ComponentModel;
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
    public bool itemType = true;
    //用名稱製作字典
    public void MakeDic(string btnName)
    {
        if (itemType)
        {
            foreach (var key in new List<string>(potItemData.Keys))
            {
                if (potItemData[key].newpotItem != null)
                {
                    RemoveBtnClick(key);
                }
            }
            potItemInfo info = new potItemInfo();
            info.potItem = Resources.Load<GameObject>(btnName);
            info.newpotItem = Instantiate(info.potItem, rec);
            info.rectTransform = info.newpotItem.GetComponent<RectTransform>();

            if (info.rectTransform != null)
            {

                switch (btnName)
                {
                    case "add egg(Clone)":
                        info.rectTransform.anchoredPosition = new Vector2(590f, -38f);
                        break;
                    case "add meat(Clone)":
                        info.rectTransform.anchoredPosition = new Vector2(693f, -614f);
                        break;
                    default:
                        Debug.Log($"沒有對應的按鈕名稱:{btnName}");
                        break;
                }
                StartCoroutine(CookTime(info.newpotItem, btnName));
            }
            potItemData[btnName] = info;
            //鎖定物件
            itemType = false;
        }
        else { Debug.Log("有其他物件"); }
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
                itemType = true;
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
    public TextMeshProUGUI cookTime;
     IEnumerator CookTime(GameObject newPotItem, string btnName)
    {
        float targetTime = 0f;
        switch (btnName.Replace("(Clone)", ""))
        {
            case "add egg":
                targetTime = 2f;
                break;
            case "add meat":
                targetTime = 5f;
                break;
            default:
                Debug.Log($"沒有對應的按鈕名稱:{btnName}");
                break;
        }

        while (0f < targetTime)
        {
            cookTime.text = targetTime.ToString("F0");
            targetTime -= Time.deltaTime;
            yield return null;
        }
        cookTime.text = "";
        if (newPotItem != null)
        {
            CreatBtn(newPotItem);
        }
    }
}