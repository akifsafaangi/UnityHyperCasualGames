using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Media;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int currentCircleNumber;

    public static float rotationSpeed = 100.0f;
    public static float rotationTime = 3;

    private int circleNumber;
    private int heartNo;

    private Color[] changingColors;

    [SerializeField]
    private GameObject[] hearts;
    [SerializeField]
    private GameObject hitButton;

    private bool gameFail;

    public GameObject levelComplete;
    public GameObject failScreen;
    public GameObject startGameScreen;
    public GameObject circleEffect;

    public TextMeshProUGUI levelCompleteText;

    public AudioSource completeSound;
    public AudioSource gameFailSound;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetGame();
    }

    void ResetGame()
    {
        changingColors = Colors.colorArray;
        BallHandler.instance.UpdateColor(changingColors[0]);
        BallHandler.instance.ChangeColor();

        BallHandler.instance.ChangeBallsCount();

        GameObject circle = Instantiate(Resources.Load("Round" + UnityEngine.Random.Range(1, 5))) as GameObject;
        circle.transform.position = new Vector3(0.0f, 0.0f, 23);
        circle.name = "Circle" + circleNumber;

        BallHandler.instance.UpdateBallsCount();
        currentCircleNumber = circleNumber;

        LevelHandler.currentColor = BallHandler.ballColor;

        if (heartNo == 0)
            PlayerPrefs.SetInt("hearts", 1);
        heartNo = PlayerPrefs.GetInt("hearts");
        for(int i = 0; i < heartNo; i++)
        {
            hearts[i].SetActive(true);
        }

        MakeHurdles();
    }

    public void DecreaseHeart()
    {
        heartNo--;
        PlayerPrefs.SetInt("hearts", heartNo);
        hearts[heartNo].SetActive(false);
    }

    public void MakeNewCircle()
    {
        if(circleNumber >= LevelHandler.totalCircles && !gameFail)
        {
            completeSound.Play();
            StartCoroutine(LevelCompleteScreen());
        }
        else
        {
            StartCoroutine(CircleEffect());
            GameObject[] circles = GameObject.FindGameObjectsWithTag("circle");
            GameObject gameObject = GameObject.Find("Circle" + circleNumber); //???
            for (int i = 0; i < 24; i++)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
            gameObject.transform.GetChild(24).gameObject.GetComponent<MeshRenderer>().material.color = BallHandler.ballColor;

            if (gameObject.GetComponent<iTween>())
            {
                gameObject.GetComponent<iTween>().enabled = false;
            }

            foreach (GameObject target in circles)
            {
                iTween.MoveBy(target, iTween.Hash(new object[]
                {
                "y", -2.98f,
                "easetype", iTween.EaseType.spring,
                "time", 0.5
                }));
            }

            circleNumber++;
            currentCircleNumber = circleNumber;

            GameObject circle = Instantiate(Resources.Load("Round" + UnityEngine.Random.Range(1, 5))) as GameObject;
            circle.transform.position = new Vector3(0.0f, 0.0f, 23);
            circle.name = "Circle" + circleNumber;


            BallHandler.instance.UpdateBallsCount();

            BallHandler.instance.UpdateColor(changingColors[circleNumber]);
            BallHandler.instance.ChangeColor();
            LevelHandler.currentColor = BallHandler.ballColor;

            MakeHurdles();
            BallHandler.instance.ChangeBallsCount();
        }
    }

    void MakeHurdles()
    {
        if (circleNumber == 1)
            FindFirstObjectByType<LevelHandler>().MakeHurdles1();

        if (circleNumber == 2)
            FindFirstObjectByType<LevelHandler>().MakeHurdles2();

        if (circleNumber == 3)
            FindFirstObjectByType<LevelHandler>().MakeHurdles3();

        if (circleNumber == 4)
            FindFirstObjectByType<LevelHandler>().MakeHurdles4();

        if (circleNumber == 5)
            FindFirstObjectByType<LevelHandler>().MakeHurdles5();
    }

    public int GetCircleNumber ()
    {
        return circleNumber;
    }

    public IEnumerator HideHitButton()
    {
        if (!gameFail)
        {
            hitButton.SetActive(false);
            yield return new WaitForSeconds(1);
            hitButton.SetActive(true);
        }
    }

    IEnumerator LevelCompleteScreen()
    {
        gameFail = true;

        GameObject oldCircle = GameObject.Find("Circle" + circleNumber);
        for (int i = 0; i < 24; i++)
        {
            oldCircle.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
        }
        oldCircle.transform.GetChild(24).gameObject.GetComponent<MeshRenderer>().material.color = BallHandler.ballColor;
        oldCircle.transform.GetComponent<MonoBehaviour>().enabled = false;
        if (oldCircle.GetComponent<iTween>())
            oldCircle.GetComponent<iTween>().enabled = false;
        hitButton.SetActive(false);
        yield return new WaitForSeconds(2);
        levelComplete.SetActive(true);
        levelCompleteText.text = string.Empty + LevelHandler.currentLevel;
        yield return new WaitForSeconds(1);
        GameObject[] oldCircles = GameObject.FindGameObjectsWithTag("circle");
        foreach (GameObject gameObject in oldCircles)
        {
            Destroy(gameObject.gameObject);
        }
        yield return new WaitForSeconds(1);
        int currentLevel = PlayerPrefs.GetInt("C_Level");
        currentLevel++;
        PlayerPrefs.SetInt("C_Level", currentLevel);
        GameObject.FindFirstObjectByType<LevelHandler>().UpgradeLevel();
        ResetGame();
        levelComplete.SetActive(false);
        startGameScreen.SetActive(true);
        gameFail = false;
    }
    public void FailGame()
    {
        gameFailSound.Play();
        gameFail = true;
        Invoke("FailScreen", 1);
        hitButton.SetActive(false);
        StopCircle();
    }

    void StopCircle()
    {
        GameObject gameObject = GameObject.Find("Circle" + circleNumber);
        gameObject.transform.GetComponent<MonoBehaviour>().enabled = false;
        if (gameObject.GetComponent<iTween>())
            gameObject.GetComponent<iTween>().enabled = false;
    }

    void FailScreen()
    {
        failScreen.SetActive(true);
    }

    public void DeleteAllCircles()
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag("circle");
        foreach (GameObject gameObject in array)
        {
            Destroy(gameObject.gameObject);
        }
        gameFail = false;
        FindFirstObjectByType<LevelHandler>().UpgradeLevel();
        ResetGame();
    }
    IEnumerator CircleEffect()
    {
        yield return new WaitForSeconds(.4f);
        circleEffect.SetActive(true);
        yield return new WaitForSeconds(.8f);
        circleEffect.SetActive(false);
    }
}
