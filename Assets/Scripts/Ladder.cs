using UnityEngine;
using UnityEngine.UI;


public class Ladder : MonoBehaviour
{
    private bool isInRange;
    private PlayerMovement playerMovement;
    public BoxCollider2D topCollider;
    private Text interactUI;


    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    private void Update()
    {
        if (isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E)|| isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.A)|| isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.D))
        {
            //Descendre de l'echelle
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            return;
        }

        if (isInRange && Input.GetKeyDown(KeyCode.W)||isInRange && Input.GetKeyDown(KeyCode.E)||isInRange && Input.GetKeyDown(KeyCode.S))
        {
            playerMovement.isClimbing = true;
            topCollider.isTrigger = true;
        }
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
            isInRange = false;
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            interactUI.enabled = false;
        }
    }
}
