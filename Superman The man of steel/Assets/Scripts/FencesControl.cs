using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FencesControl : MonoBehaviour
{
    public Vector2 initialVelocity;
    public float initialRotation;
    
    //Tiempo de Vida
    public float lifeTime = 10.0f;  

    private Rigidbody2D myRigidBody;  

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        //Asignar la velocidad inical de la valla 
        myRigidBody.velocity = initialVelocity;
        myRigidBody.angularVelocity = initialRotation;

        //Eliminaremos la valla en 10 segundos 
        Destroy(gameObject, lifeTime); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Cuando detectemos una colisión
        //Crear sistema de particulas 
        //Instatiat...

        //Destruir el asteroide  
        Destroy(gameObject);
    }
      

}

         
