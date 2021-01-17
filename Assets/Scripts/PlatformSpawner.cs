using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject PlatformPref;
    public float spawn_delay;

    [Header("X POS")]
    public float random_x;

    [Header("Y POS")]
    public float random_max_y;
    public float random_min_y;
    private Vector2 last_spawn_pos;

    private void Awake()
    {
        // Player'ın başlangıç pozisyonunu al.
        last_spawn_pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        StartCoroutine(Spawner());
    }
    private IEnumerator Spawner()
    {
        // Belirli aralıklarda rastgele bir pozisyon ver.
        // Bu pozisyona en son oluşturulan platformun y değerini ekle
        Vector2 spawn_pos = new Vector3(Random.Range(-random_x, random_x), Random.Range(random_min_y, random_max_y) + last_spawn_pos.y);

        // Belirlenen pozisyonda bir platform oluştur.
        Instantiate(PlatformPref, spawn_pos, Quaternion.identity).transform.SetParent(transform);
        last_spawn_pos = spawn_pos;

        // Belirlenen süre kadar bekle.
        yield return new WaitForSeconds(spawn_delay);
        StartCoroutine(Spawner());
    }
}
