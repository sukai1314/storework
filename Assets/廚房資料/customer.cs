using System.Collections.Generic;
using UnityEngine;

public class customer : MonoBehaviour
{
    public Transform canvaTrs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        customerList cust = new customerList();
        cust.customerPreb = Resources.Load<GameObject>("boy");
        cust.customerImage=Instantiate(cust.customerPreb,canvaTrs);
        customerInfo[1]=cust;
        customerInfo[1].rectTransform.anchoredPosition = new Vector2(57, 300);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //«Ø¥ß«È¤á
    struct customerList
    {
        public GameObject customerPreb;
        public GameObject customerImage;
        public RectTransform rectTransform;
    }
    Dictionary<int,customerList> customerInfo=new Dictionary<int,customerList>();
}
