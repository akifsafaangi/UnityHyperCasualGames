using System.Collections;
using TMPro;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public TextMeshProUGUI levelNo;
    public TextMeshProUGUI TargetText;
    void OnEnable()
    {
        levelNo.text = LevelHandler.currentLevel + string.Empty;
        TargetText.text = LevelHandler.totalCircles + string.Empty;
        StartCoroutine(DelayedRemoval());
    }
    IEnumerator DelayedRemoval()
    {
        yield return new WaitForSeconds(1);
        base.gameObject.SetActive(false);
    }
}
