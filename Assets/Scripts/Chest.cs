using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    private Text interactUI;
    private bool isInRange;

    public Animator animator;
    public int coinsToAdd;
    public int lifeToAdd;
    public AudioClip soundToPlayOnCoins;
    public AudioClip soundToPlayOnLife;

    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            OpenChest();
        }
    }

    private void OpenChest()
    {
        animator.SetTrigger("OpenChest");
        if(PlayerHealth.instance.currentHealth == 100)
        {
            Inventory.instance.AddCoins(coinsToAdd);
            AudioManager.instance.PlayClipAt(soundToPlayOnCoins, transform.position);
        }
        else
        {
            PlayerHealth.instance.HealtPlayer(lifeToAdd);
            AudioManager.instance.PlayClipAt(soundToPlayOnLife, transform.position);
        }
        GetComponent<BoxCollider2D>().enabled = false;
        interactUI.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}
