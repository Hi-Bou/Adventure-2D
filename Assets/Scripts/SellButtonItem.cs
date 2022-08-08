using UnityEngine;
using UnityEngine.UI;

public class SellButtonItem : MonoBehaviour
{
    public Text itemName;
    public Image itemImage;
    public Text itemPrice;

    private Text notEnoughMoneyUI;

    public Item item;

    public void BuyItem()
    {
        Inventory inventory = Inventory.instance;

        if (inventory.coinsCount >= item.price)
        {
            inventory.content.Add(item);
            inventory.UpdateInventoryUI();
            inventory.coinsCount -= item.price;
            inventory.UpdateCoinsTextUI();
        }
        else
        {
            notEnoughMoneyUI.enabled = true;
        }
    }
}
