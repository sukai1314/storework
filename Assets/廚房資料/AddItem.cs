using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BentoPlate
    {
        public int currentRice=0;
    private int egg;
    public int currentEgg=0;
    
        public int currentMeat=0;
    }
public class AddItem : MonoBehaviour
{
    public program myprogram;
        public static AddItem Instance { get; private set; }
        public BentoPlate playerPlate = new BentoPlate();
        private void Awake()
        {
            Instance= this;
    }
    public void AddMeat(string btnName)
        {
            playerPlate.currentMeat++;
        if (playerPlate.currentMeat > 1) { playerPlate.currentMeat = 1; }
        newpotitem.potItem.RemoveBtnClick(btnName);
        Debug.Log($"ヘ玡ψ计秖{playerPlate.currentMeat}");
        UpPlate();
    }

        public void AddRice()
        {
            playerPlate.currentRice++;

        UpPlate();
        if (playerPlate.currentRice > 1)
            {
                playerPlate.currentRice = 1;

            }
                Debug.Log($"ヘ玡フ逗计秖{playerPlate.currentRice}");

    }
    int newegg = 0;
        public void AddEgg(string btnName)
        {
        newegg = 1;
        playerPlate.currentEgg++;
        Debug.Log($"[砆эン] {gameObject.name} -> ヘ玡矹计秖{playerPlate.currentEgg}");
         UpPlate();
            if (playerPlate.currentEgg > 1)
            {
            playerPlate.currentEgg = 1;
            }
        if (newpotitem.potItem != null)
        {
            newpotitem.potItem.RemoveBtnClick(btnName);
        }
               
                Debug.Log($"ヘ玡矹计秖{playerPlate.currentEgg}{btnName}");
        }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       myprogram = GetComponent<program>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
    public void UpPlate()
    {
    if (myprogram != null)
        {
            Debug.Log($"肚{playerPlate.currentRice}");
            myprogram.PlateFood(playerPlate.currentRice,newegg,playerPlate.currentMeat);
        }
    }

}
