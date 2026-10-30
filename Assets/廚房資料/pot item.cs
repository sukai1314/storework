using UnityEngine;
using UnityEngine.UI;

public class potitem : AddItem
{
    public static potitem potEgg {  get; private set; }
    public GameObject Egg;
    public GameObject newEgg;
    public Transform canvasTrans;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Egg != null && Egg != this)
        {
            Debug.Log("已有雞蛋");
            Destroy(Egg);
            return;
        }
        potEgg = this;
    }
    void Start()
    {
        Egg = Resources.Load<GameObject>("Egg");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CookEgg()
    {
        if (newEgg != null)
        {
            Debug.Log("已有雞蛋");
            return;
        }
        if (Egg != null)
        {
            newEgg = Instantiate(Egg, canvasTrans);
            RectTransform rectTransform = newEgg.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                CreatBotton();
                rectTransform.anchoredPosition = new Vector2(590f, -38f);
            }

        }
    }
    public void CreatBotton()
    {
        if (newEgg != null)
        {
            Button btn=newEgg.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(() => { 
                    AddEgg(); 
                });
            }
        }
    }
}
