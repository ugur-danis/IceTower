using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Main Camera")]
    public CameraFollow CameraFollow;

    [Header("Player")]
    public GameObject Player;

    [Header("Platform")]
    public GameObject PlatformSpawner;

    public void GameOver()
    {
        CameraFollow.enabled = false;
        Destroy(PlatformSpawner);
        Destroy(Player);

        SceneManager.LoadScene(0);
    }
}