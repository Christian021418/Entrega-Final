using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Cuando el usuario pulsa Press any Key, volvemos a jugar 
        if(Input.anyKeyDown) 
        {
            SceneManager.LoadScene(1);           
        }
    }
}
  

