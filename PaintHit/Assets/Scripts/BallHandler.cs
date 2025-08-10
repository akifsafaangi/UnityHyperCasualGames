using UnityEditor.Toolbars;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    public static Color ballColor = Color.blue;
    public GameObject ball;

    private float speed = 100.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        GameObject ballObject = Instantiate<GameObject>(ball, new Vector3(0.0f, 0.0f, -8.0f), Quaternion.identity);
        ballObject.GetComponent<MeshRenderer>().material.color = ballColor;
        ballObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.Impulse);
    }
}
