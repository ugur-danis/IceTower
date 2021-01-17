using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float ofset_y;
    public float speed;

    private void Update()
    {
        if (transform.position.y - ofset_y < Target.position.y)
            transform.position = Vector3.Lerp(transform.position,
            new Vector3(transform.position.x, Target.position.y, transform.position.z), speed);
    }
}
