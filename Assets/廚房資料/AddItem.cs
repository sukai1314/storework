using UnityEngine;
    public class BentoPlate
    {
        public int currentRice;
        public int currentEgg;
        public int currentMeat;
    }
public class AddItem : MonoBehaviour
{
   
    
        public BentoPlate playerPlate = new BentoPlate();
        public void AddMeat()
        {
            playerPlate.currentMeat++;
            if (playerPlate.currentMeat > 1) { playerPlate.currentMeat = 1; }
            Debug.Log($"目前肉數量{playerPlate.currentMeat}");
        }

        public void AddRice()
        {
            playerPlate.currentRice++;

            if (playerPlate.currentRice > 1)
            {
                playerPlate.currentRice = 1;

            }
                Debug.Log($"目前白飯數量{playerPlate.currentRice}");
        }
        public void AddEgg()
        {
        playerPlate.currentEgg++;

            if (playerPlate.currentEgg > 1)
            {
            playerPlate.currentEgg = 1;

            }
                Debug.Log($"目前蛋數量{playerPlate.currentEgg}");
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
