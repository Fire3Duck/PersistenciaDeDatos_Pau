using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;
    public Vector3 playerPosition;
    public string playerName;
    public int playerMaxhealth;
    public int playerMaxMana;
    public int playerExp;


    /*void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }*/

    public void SaveData()
    {
        /*UserData.playerName = playerName;
        UserData.playerMaxhealth = playerMaxhealth;
        UserData.playerMaxMana = playerMaxMana;
        UserData.playerExp = playerExp;
        UserData.playerPosition = playerPosition;
        Debug.Log("Data Saved");*/

        Stats.userStats.playerName = playerName;
        Stats.userStats.playerPosition = playerPosition;
        Stats.userStats.playerHealth = playerMaxhealth;
        Stats.userStats.playerExp = playerExp;

        SavingDataSystem.Save();

        
    }

    public void LoadData()
    {
        /*playerName = UserData.playerName;
        playerMaxhealth = UserData.playerMaxhealth;
        playerMaxMana = UserData.playerMaxMana;
        playerExp = UserData.playerExp;
        playerPosition = UserData.playerPosition;
        Debug.Log("Data Loaded");*/

        SavingDataSystem.Load();
        
        playerName = Stats.userStats.playerName;
        playerPosition = Stats.userStats.playerPosition;
        playerMaxhealth = Stats.userStats.playerHealth;
        playerExp = Stats.userStats.playerExp;


        
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetString("Player Name", playerName);
        PlayerPrefs.SetInt("Player Health", playerMaxhealth);
        PlayerPrefs.SetInt("Player Mana", playerMaxMana);
        PlayerPrefs.SetInt("Player Exp", playerExp);
        PlayerPrefs.SetFloat("Player Position", playerPosition.x);
        PlayerPrefs.SetFloat("Player Position", playerPosition.y);
        PlayerPrefs.SetFloat("Player Position", playerPosition.z);
    }
    
    public void LoadPrefs()
    {
        playerName = PlayerPrefs.GetString("Player Name", "No Name");
        playerMaxhealth = PlayerPrefs.GetInt("Player Health", 1);
        playerMaxMana = PlayerPrefs.GetInt("Player Mana", 1);
        playerExp = PlayerPrefs.GetInt("Player Exp", 1);
        playerPosition.x = PlayerPrefs.GetFloat("Player Position", 0);
        playerPosition.y = PlayerPrefs.GetFloat("Player Position", 0);
        playerPosition.z = PlayerPrefs.GetFloat("Player Position", 0);
    }
}
