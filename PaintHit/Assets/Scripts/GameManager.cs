using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static float rotationSpeed = 100.0f;
    public static float rotationTime = 3;

    private int circleNumber;

    private Color[] changingColors;
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

        GameObject circle = Instantiate(Resources.Load("Round" + UnityEngine.Random.Range(1, 5))) as GameObject;
        circle.transform.position = new Vector3(0.0f, 0.0f, 23);
        circle.name = "Circle" + circleNumber;

        BallHandler.instance.UpdateBallsCount();
    }

    public void MakeNewCircle()
    {
        GameObject[] circles = GameObject.FindGameObjectsWithTag("circle");
        GameObject gameObject = GameObject.Find("Circle" + circleNumber); //???
        for (int i = 0; i < 24; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        gameObject.transform.GetChild(24).gameObject.GetComponent<MeshRenderer>().material.color = BallHandler.ballColor;

        if(gameObject.GetComponent<iTween>())
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

        GameObject circle = Instantiate(Resources.Load("Round" + UnityEngine.Random.Range(1,5))) as GameObject;
        circle.transform.position = new Vector3(0.0f, 0.0f, 23);
        circle.name = "Circle" + circleNumber;


        BallHandler.instance.UpdateBallsCount();

        BallHandler.instance.UpdateColor(changingColors[circleNumber]);
        BallHandler.instance.ChangeColor();
    }
}
