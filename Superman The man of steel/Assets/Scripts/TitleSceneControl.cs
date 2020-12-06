using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TitleSceneControl : MonoBehaviour
{
    public Text hiScoreText;

    private float hiScore;

    // Start is called before the first frame update
    void Start()
    {
        //Si existe un record, lo apuntamos. Si no el record es 0
        if(PlayerPrefs.HasKey("hiScore"))
        {
            hiScore = PlayerPrefs.GetFloat("hiScore");
        }
        else
        {
            hiScore = 0;
        }

        //Actualizamos el texto del record
        hiScoreText.text = "hiScore:" + hiScore.ToString("F1");
    }

    // Update is called once per frame
    void Update()
    {
        //Cuando el usaurio pulse cualquier tecla, vamos al juego
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void Exit()
    {

        Application.Quit();
        Debug.Log("Exit");
    }
}
        