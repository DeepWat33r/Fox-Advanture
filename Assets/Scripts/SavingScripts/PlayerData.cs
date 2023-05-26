using Player;

namespace SavingScripts
{
    [System.Serializable]
    public class PlayerData
    {
        public int currentHealth;
        public int gemsCollected;
        public float[] position;

        public PlayerData(PlayerController playerController, PlayerMovement2D playerMovement2D)
        {
            currentHealth = playerController.currentHealth;
            gemsCollected = playerController.NumbersOfGems;
        
            position = new float[3];
            position[0] = playerMovement2D.transform.position.x;
            position[1] = playerMovement2D.transform.position.y;
            position[2] = playerMovement2D.transform.position.z;
        }
    }
}

