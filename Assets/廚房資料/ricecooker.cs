using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ricecooker : MonoBehaviour
{
    //倒計時
    public Image fillImage;
    private float time = 3.0f;
    private float timer = 0f;
    private bool isCooking=false;

    public Image riceCook;
    private float glowspeed=3f;
    public void IsCooking()
    {
        timer = 0;
        isCooking = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooking)
        {
            timer += Time.deltaTime;
            fillImage.fillAmount = timer / time;

            if (timer >= time)
            {

                if (riceCook != null)
                {
                    
                    //產生0~2的連環數字
                    float alpha = (float)(Math.Sin(Time.time * glowspeed) + 1) / 2;
                    riceCook.color = new Color(1f, 1f, 1f,alpha);
                }

                Debug.Log("完成");
            }
        }
    }
}
