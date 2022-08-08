using UnityEngine;

public class WeakSpot : MonoBehaviour
{

    public GameObject objectToDestroy;
    public AudioClip Killsound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(Killsound, transform.position);
            Destroy(objectToDestroy);
        }
    }
}
