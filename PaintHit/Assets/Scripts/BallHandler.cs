using UnityEditor.Toolbars;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    public static BallHandler instance;

    public static Color ballColor;
    public GameObject ball;

    private float speed = 100.0f;

    private int ballsCount;

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
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            HitBall();
        }
    }

    void HitBall()
    {
        if(ballsCount <= 1)
        {
            Invoke("MakeNewCircle", 0.4f);
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
}
