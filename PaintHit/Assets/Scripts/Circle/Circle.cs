using UnityEngine;

public class Circle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
        {
            "y", 0,
            "easetype", iTween.EaseType.easeInCirc,
            "time", 0.2,
            "OnComplete", "RotateCircle"
        }));
    }

    void RotateCircle()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * GameManager.rotationSpeed);
    }
}
