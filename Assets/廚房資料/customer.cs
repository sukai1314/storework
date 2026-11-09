using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class customer : MonoBehaviour
{
    public Transform canvaTrs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static customer custo {  get; private set; }
    private void Awake()
    {
        if (custo != null && custo != this)
        {
            Debug.Log("已有客人");
        }
        custo=this;
    }
    void Start()
    {
        //boy
        CreatCustomer(1, "boy", new Vector2(57, 300));
        CreatCustomer(2, "man", new Vector2(80, 268));
        CreatCustomer(3, "woman", new Vector2(77, 280));
        showCus(1);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void CreatCustomer(int id,string resouceName,Vector2 position)
    {
        customerList cust = new customerList();
        cust.customerPreb = Resources.Load<GameObject>(resouceName);
        cust.customerImage=Instantiate(cust.customerPreb,canvaTrs);
        cust.rectTransform=cust.customerImage.GetComponent<RectTransform>();
        cust.rectTransform.anchoredPosition = position;
        cust.image=cust.customerImage.GetComponent<UnityEngine.UI.Image>();
        if (cust.image != null)
        {
            Color newColor=cust.image.color;
            newColor.a = 0f;
            cust.image.color=newColor;
        }
        customerInfo[id]=cust;
    }
    public void showCus(int id)
    {
        Color newColor = customerInfo[id].image.color;
        newColor.a = 1f;
        customerInfo[id].image.color =newColor;
    }
    public void disCus(int id)
    {
        Color newColor = customerInfo[id].image.color;
        newColor.a = 0f;
        customerInfo[id].image.color = newColor;
    }
    //建立客戶
    struct customerList
    {
        public GameObject customerPreb;
        public GameObject customerImage;
        public RectTransform rectTransform;
        public UnityEngine.UI.Image image;
    }
    Dictionary<int,customerList> customerInfo=new Dictionary<int,customerList>();
}
