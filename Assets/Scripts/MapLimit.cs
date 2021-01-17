using UnityEngine;

public class MapLimit : MonoBehaviour
{
    public Vector3 limit;
    public float limit_margin;
    void Start()
    {
        // Ekran boyutunun limit_margin kadar eksiğini al.
        limit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - limit_margin, Screen.height - limit_margin), 0);
    }
    private void Update()
    {
        // Player'ı ekran içinde tut.
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -limit.x, limit.x), transform.position.y, transform.position.z);
    }
}