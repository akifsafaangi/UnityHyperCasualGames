using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Image bg;

    [SerializeField]
    private Sprite[] bgSprites;

    public GameObject pauseScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bg.sprite = bgSprites[Random.Range(0, 4)];
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void unPauseGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
}
