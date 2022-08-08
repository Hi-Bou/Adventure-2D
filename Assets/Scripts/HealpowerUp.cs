using UnityEngine;

public class HealpowerUp : MonoBehaviour
{
    public int healthPoint;
    public AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(PlayerHealth.instance.currentHealth != PlayerHealth.instance.maxHealth)
            {
                AudioManager.instance.PlayClipAt(pickupSound, transform.position);
                PlayerHealth.instance.HealtPlayer(healthPoint);
                Destroy(gameObject);
            }
        }
    }
}
