using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuHandler : MonoBehaviour
{

    public Text HighScoreText;
    public Text BestPlayerText;

    // Start is called before the first frame update
    void Start()
    {
        SavingThings.Instance.LoadScore();
        HighScoreText.text = SavingThings.Instance.HighScore.ToString();
        BestPlayerText.text = SavingThings.Instance.HighPlayerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();


#else
        
            Application.Quit(); // original code to quit Unity player
        
#endif
        SavingThings.Instance.SaveScore();
    }

    }
