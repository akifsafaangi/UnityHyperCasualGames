using UnityEditor.Toolbars;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    public static Color ballColor = Color.blue;
    public GameObject ball;

    private float speed = 100.0f;

    private int ballsCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballsCount = 4;
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
}
