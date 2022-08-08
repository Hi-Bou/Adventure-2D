using System.Linq;
using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("Il y aplus d'une instance de LoadAndSaveData dans la scène");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsCount", 0);
        Inventory.instance.UpdateCoinsTextUI();

        int currentHealth = PlayerPrefs.GetInt("playerHealth", PlayerHealth.instance.maxHealth);
        PlayerHealth.instance.currentHealth = currentHealth;
        PlayerHealth.instance.healthBar.SetHealth(currentHealth);

        string[] itemSaved = PlayerPrefs.GetString("inventoryItem", "").Split('-');

        for (int i = 0; i < itemSaved.Length; i++)
        {
            if(itemSaved[i] != "")
            {
                int id = int.Parse(itemSaved[i]);
                Item currentItem = ItemsDataBase.instance.allItems.Single(x => x.id == id);
                Inventory.instance.content.Add(currentItem);
            }
        }

        Inventory.instance.UpdateInventoryUI();
    }

    public void SaveData()
    {
        //Sauvegarde des piece
        PlayerPrefs.SetInt("coinsCount", Inventory.instance.coinsCount);

        //sauvegarde des niveaux passé
        if(CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock);
        }

        //sauvegarde de la vie
        PlayerPrefs.SetInt("playerHealth", PlayerHealth.instance.currentHealth);

        //sauvegarde des items
        string itemInInventory = string.Join("-", Inventory.instance.content.Select(x => x.id));
        PlayerPrefs.SetString("inventoryItem", itemInInventory);
    }
}
