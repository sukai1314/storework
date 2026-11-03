using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class newpotitem : AddItem
{

    private void Awake()
    {

    }
    void Start()
    {
     
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
            }
        }
    }

    //用名稱製作字典
    struct potItemInfo
    {
        public GameObject potItem;
        public GameObject newpotItem;
        public RectTransform rectTransform;
    }
    Dictionary<string, potItemInfo>
    //用字典取得prefab
    //用prefab製作元件
    //動態產生按鈕


}