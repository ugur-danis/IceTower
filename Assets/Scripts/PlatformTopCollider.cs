using UnityEngine;

public class PlatformTopCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Player platforma yukarıdan geliyor ise platform tetiklenmez.
        if (other.transform.tag == "Player") transform.parent.GetComponent<Collider2D>().isTrigger = false;
    }
}
