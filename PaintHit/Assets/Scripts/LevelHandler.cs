using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public static int currentLevel;

    public static int ballsCount;

    public static int totalCircles;

    public static Color currentColor;

    void Awake()
    {
        if (PlayerPrefs.GetInt("firstTime12", 0) == 0)
        {
            PlayerPrefs.SetInt("firstTime12", 1);
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
}
