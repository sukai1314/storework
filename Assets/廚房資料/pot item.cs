using UnityEngine;

public class potitem : MonoBehaviour
{
    public static potitem potEgg {  get; private set; }
    public GameObject Egg;
    public Transform canvasTrans;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Egg != null && Egg != this)
        {
            Debug.Log("¤w¦³Âû³J");
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
        if (Egg != null)
        {
            GameObject newEgg = Instantiate(Egg, canvasTrans);
            RectTransform rectTransform = newEgg.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.anchoredPosition = new Vector2(590f, -38f);
            }

        }
    }
}
