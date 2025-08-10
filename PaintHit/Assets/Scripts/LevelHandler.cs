using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public static int currentLevel;

    public static int ballsCount;

    public static int totalCircles;

    public static Color currentColor;

    void Awake()
    {
        if (PlayerPrefs.GetInt("firstTime1", 0) == 0)
        {
            PlayerPrefs.SetInt("firstTime1", 1);
            PlayerPrefs.SetInt("C_Level", 1);
        }
        UpgradeLevel();
    }


    public void UpgradeLevel()
    {
        currentLevel = PlayerPrefs.GetInt("C_Level", 1);

        if (currentLevel >= 1 && currentLevel < 3)
        {
            ballsCount = 3;
            totalCircles = 2;
        }

        if (currentLevel >= 3 && currentLevel < 6)
        {
            ballsCount = 3;
            totalCircles = 3;
        }

        if (currentLevel >= 6 && currentLevel < 12)
        {
            ballsCount = 3;
            totalCircles = 4;
        }

        if (currentLevel >= 12 && currentLevel < 18)
        {
            ballsCount = 3;
            totalCircles = 5;
        }

        if (currentLevel >= 18 && currentLevel < 24)
        {
            ballsCount = 4;
            totalCircles = 5;
        }

        if (currentLevel >= 24 && currentLevel < 30)
        {
            ballsCount = 4;
            totalCircles = 6;
            GameManager.rotationSpeed = 120;
            GameManager.rotationTime = 2;
        }

        if (currentLevel >= 30)
        {
            ballsCount = 5;
            totalCircles = 7;
            GameManager.rotationSpeed = 140;
            GameManager.rotationTime = 1;
        }
    }

    public void MakeHurdles1()
    {
        GameObject circleObject = GameObject.Find("Circle" + GameManager.currentCircleNumber);

        int index = Random.Range(1, 3);
        circleObject.transform.GetChild(index).gameObject.GetComponent<MeshRenderer>().enabled = true;
        circleObject.transform.GetChild(index).gameObject.GetComponent<MeshRenderer>().material.color = currentColor;
        circleObject.transform.GetChild(index).gameObject.tag = "red";
    }

    public void MakeHurdles2()
    {
        GameObject circleObject = GameObject.Find("Circle" + GameManager.currentCircleNumber);

        int[] array = new int[]
        {
            Random.Range(1,3),
            Random.Range(15,17)
        };

        for (int i = 0; i < array.Length; i++)
        {
            circleObject.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().enabled = true;
            circleObject.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().material.color = currentColor;
            circleObject.transform.GetChild(array[i]).gameObject.tag = "red";
        }

    }

    public void MakeHurdles3()
    {
        GameObject circleObject = GameObject.Find("Circle" + GameManager.currentCircleNumber);

        int[] array = new int[]
        {
            Random.Range(1,3),
            Random.Range(4,6),
            Random.Range(18, 20)
        };

        for (int i = 0; i < array.Length; i++)
        {
            circleObject.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().enabled = true;
            circleObject.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().material.color = currentColor;
            circleObject.transform.GetChild(array[i]).gameObject.tag = "red";
        }

    }
    public void MakeHurdles4()
    {
        GameObject circleObject = GameObject.Find("Circle" + GameManager.currentCircleNumber);

        int[] array = new int[]
        {
            Random.Range(1,3),
            Random.Range(4,6),
            Random.Range(15, 17),
            Random.Range(22, 24)
        };

        for (int i = 0; i < array.Length; i++)
        {
            circleObject.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().enabled = true;
            circleObject.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().material.color = currentColor;
            circleObject.transform.GetChild(array[i]).gameObject.tag = "red";
        }

    }
    public void MakeHurdles5()
    {
        GameObject circleObject = GameObject.Find("Circle" + GameManager.currentCircleNumber);

        int[] array = new int[]
        {
            Random.Range(1,3),
            Random.Range(4,6),
            Random.Range(11, 13),
            Random.Range(8, 10),
            Random.Range(15, 17)
        };

        for (int i = 0; i < array.Length; i++)
        {
            circleObject.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().enabled = true;
            circleObject.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().material.color = currentColor;
            circleObject.transform.GetChild(array[i]).gameObject.tag = "red";
        }

    }
}
