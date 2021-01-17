using UnityEngine;
public class PlayerDeath : MonoBehaviour
{
    public GameManager GameManager;
    public Transform SpawnerObj;
    public float maxJumpDistance;
    private void OnBecameInvisible()
    {
        // Bu obje ve SpawnerObj var ise
        if (transform && SpawnerObj)
            // Eğer Player en yakın platformun altında ise.
            if (SpawnerObj.GetChild(0).transform.position.y > transform.position.y)
                GameManager.GameOver();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        // Eğer yerde bekliyorsa.
        if (other.transform.tag == "Ground")
        {
            // Eğer en yakın platformun uzaklığı zıplama mesafesinde fazla ise.
            if (SpawnerObj.GetChild(0).transform.position.y > transform.position.y + maxJumpDistance)
                GameManager.GameOver();
        }
    }
}