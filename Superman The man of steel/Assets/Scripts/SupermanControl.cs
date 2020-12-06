using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SupermanControl : MonoBehaviour
{
    //Control del Superheroe
    public float rocketPower = 1.0f;
    public ParticleSystem rocketParticles;

    //Distancia 
    public Text distanceText;
    public float mySpeed = 5.0f;

    //Energia inicial: 100
    public Text energyText;
    public int impactEnergy = 10;
    public int initialEnergy = 100;

  

    //Fin de juego
    public GameObject gameOverText;
    public float gameOverTime = 2.0f;


    //Variables privadas
    private float myDistance = 0.0f;
    private int myEnergy;
    private bool gameOver = false;
    private float gameOverCounter = 0.0f;
    private float hiScore;

    // Start is called before the first frame update
    void Start()
    {
        //Aqui se ejecutarán cosas cuando se cree el gameobject
        myEnergy = initialEnergy;

        //Actualizar el texto de la energía
        energyText.text = "Energy: " + myEnergy;

        gameOverText.SetActive(false);

        //si existe un record, lo apuntamos. Si no el record es 0
        if (PlayerPrefs.HasKey("hiScore"))
        {
            hiScore = PlayerPrefs.GetFloat("hiScore");
        }
        else
        {
            hiScore = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        var rocketEmission = rocketParticles.emission;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (myEnergy > 0)
            {
                //El usuario está pulsando la flecha de arriba
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * rocketPower);

                //Activar el sistema de partículas
                rocketEmission.enabled = true;
            }
        }
        else
        {
            // El usuario NO está pulsando la flecha de arriba

            //Desactivar el sistema de partículas
            rocketEmission.enabled = false;
        }

        myDistance += Time.deltaTime * mySpeed;
        distanceText.text = "Distance: " + myDistance.ToString("F1");

        if (gameOver)
        {
            //Incrementamos el contador de tiempo 
            gameOverCounter += Time.deltaTime;

            //Cuando el contador de tiempo sea mayor que el limite volvemos al menu principal 
            if (gameOverCounter > gameOverTime)
            {
                SceneManager.LoadScene(0);
            }

        }
    }     
       private void OnCollisionEnter2D(Collision2D collision)
      {
        if(collision.transform.tag == "Obstaculos")
        {
            //Hemos chocado con un obstaculo. Vamos a reducir la energia
            myEnergy -= impactEnergy;

            //Ahora vamos a actualizar la interfaz
            energyText.text = "Energy: " + myEnergy;
        }  
        else if (collision.transform.tag == "BottomLimit")
        {
            //Hemos chocado con el suelo. Fin de la partida
            gameOverText.SetActive(true);
            mySpeed = 0.0f;
            myEnergy = 0;
            gameOver = true;

            //Si la distancia recorrida es superior al record, actualizamos el record
            if(myDistance>hiScore)
            {
                hiScore = myDistance;
                PlayerPrefs.SetFloat("hiScore", hiScore);
            }
        }
    }
}
