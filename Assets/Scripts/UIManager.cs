using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text inputText, BestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        BestScoreText.text = "BestScoer : " + DataSaver.Instance.Bestname
        + " : " + DataSaver.Instance.BestScore;
        //inputText.text = DataSaver.Instance.userName;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        DataSaver.Instance.SaveName(inputText.text);
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        DataSaver.Instance.SaveBestData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ResetData()
    {
        DataSaver.Instance.Bestname = "";
        DataSaver.Instance.BestScore = 0;
        DataSaver.Instance.SaveBestData();
        BestScoreText.text = "BestScoer : " + DataSaver.Instance.Bestname
        + " : " + DataSaver.Instance.BestScore;
    }
}
