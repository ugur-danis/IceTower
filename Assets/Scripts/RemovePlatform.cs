using UnityEngine;
using System.Collections;
public class RemovePlatform : MonoBehaviour
{
    private GameManager GameManager;
    private Transform Player;
    public bool visible = true;
    public float removeTime;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnBecameInvisible()
    {
        // Bu obje ve Player var ise
        if (transform && Player)
            // Bu platform player dan daha aşağıda ise ve görünür ise.
            if (visible && Player.transform.position.y > transform.position.y)
            {
                visible = false;
                StartCoroutine(Remove());
            }
    }

    private IEnumerator Remove()
    {
        // Döngüyü kır.
        StopCoroutine(Remove());

        // Bu platform görünmez ise.
        if (!visible)
        {
            // Belirtilen süre kadar bekle
            yield return new WaitForSeconds(removeTime);
            // Objeyi yok et.
            Destroy(gameObject);
        }
    }
}
