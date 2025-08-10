using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static float rotateSpeed = 100.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MakeNewCircle();
    }

    void MakeNewCircle()
    {
        GameObject circle = Instantiate(Resources.Load("Round" + Random.Range(1,5))) as GameObject;
        circle.transform.position = new Vector3(0.0f, 0.0f, 23);
        circle.name = "Circle";
    }

    public static float GetRotateSpeed() {  return rotateSpeed; }
}
