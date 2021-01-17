using UnityEngine;

public class PlatformBottomCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Player platforma aşağıdan geliyor ise platform tetiklenmez.
        if (other.transform.tag == "Player") transform.parent.GetComponent<Collider2D>().isTrigger = true;
    }
}
