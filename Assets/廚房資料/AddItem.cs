using UnityEngine;
using UnityEngine.UI;
public class BentoPlate
    {
        public int currentRice=0;
    private int egg;
    public int currentEgg;
    
        public int currentMeat=0;
    }
public class AddItem : MonoBehaviour
{
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
        }

        public void AddRice()
        {
            playerPlate.currentRice++;
        if (playerPlate.currentRice > 1)
            {
                playerPlate.currentRice = 1;

            }
                Debug.Log($"ヘ玡フ逗计秖{playerPlate.currentRice}");
        }
        public void AddEgg(string btnName)
        {
        playerPlate.currentEgg++;
        Debug.Log($"[砆эン] {gameObject.name} -> ヘ玡矹计秖{playerPlate.currentEgg}");

            if (playerPlate.currentEgg > 1)
            {
            playerPlate.currentEgg = 1;
            }
            newpotitem.potItem.RemoveBtnClick(btnName);
            
                Debug.Log($"ヘ玡矹计秖{playerPlate.currentEgg}{btnName}");
        }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
