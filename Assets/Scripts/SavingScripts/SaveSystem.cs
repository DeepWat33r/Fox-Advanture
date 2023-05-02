using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SavingScripts
{
    public static class SaveSystem 
    {
        public static void SavePlayerData(PlayerController playerController, PlayerMovement2D playerMovement2D)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/player.bin";
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData(playerController, playerMovement2D);
        
            formatter.Serialize(stream, data);
            stream.Close();

        }

        public static PlayerData LoadPlayer()
        {
            string path = Application.persistentDataPath + "/player.bin";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
            
                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                stream.Close();
            
                return data;
            }
            else
            {
                Debug.Log("Save file not found " + path);
                return null;
            }
        }
        public static void SavePlayerSettings(SettingMenu settings)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/settings.bin";
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerSettings data = new PlayerSettings(settings);
        
            formatter.Serialize(stream, data);
            stream.Close();

        }

        public static PlayerSettings LoadPlayerSettings()
        {
            string path = Application.persistentDataPath + "/settings.bin";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
            
                PlayerSettings data = formatter.Deserialize(stream) as PlayerSettings;
                stream.Close();
            
                return data;
            }
            else
            {
                Debug.Log("Save file not found " + path);
                return null;
            }
        }
    }
}
