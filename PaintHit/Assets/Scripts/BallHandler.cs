using TMPro;
using Unity.VisualScripting;
using UnityEditor.Toolbars;
using UnityEngine;
using UnityEngine.UI;

public class BallHandler : MonoBehaviour
{
    public static BallHandler instance;

    public static Color ballColor;
    public GameObject ball;
    public GameObject dummyBall;

    //Texts
    public TextMeshProUGUI total_balls_text;
    public TextMeshProUGUI count_balls_text;

    private float speed = 100.0f;

    private int ballsCount;
    [SerializeField]
    private Image[] balls;

    public SpriteRenderer spriteRend;
    public Material splashMat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void HitBall()
    {
        if(ballsCount <= 1)
        {
            StartCoroutine(GameManager.instance.HideHitButton());
            Invoke("MakeNewCircle", 0.4f);
        }

        if (ballsCount >= 0)
        {
            balls[ballsCount].enabled = false;
        }

        ballsCount--;

        GameObject ballObject = Instantiate<GameObject>(ball, new Vector3(0.0f, 0.0f, -8.0f), Quaternion.identity);
        ballObject.GetComponent<MeshRenderer>().material.color = ballColor;
        ballObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.Impulse);
    }

    void MakeNewCircle()
    {
        GameManager.instance.MakeNewCircle();
    }

    public void UpdateBallsCount () { ballsCount = LevelHandler.ballsCount; }
    public void UpdateColor(Color newColor) { ballColor = newColor; }
    
    public void ChangeColor()
    {
        spriteRend.color = ballColor;
        splashMat.color = ballColor;
    }

    public void ChangeBallsCount()
    {
        ballsCount = LevelHandler.ballsCount;
        dummyBall.GetComponent<MeshRenderer>().material.color = ballColor;

        total_balls_text.text = string.Empty + LevelHandler.totalCircles;
        count_balls_text.text = string.Empty + GameManager.instance.GetCircleNumber();

        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].enabled = false;
        }

        for (int j = 0; j < ballsCount; j++)
        {
            balls[j].enabled = true;
            balls[j].color = ballColor;
        }
    }
}