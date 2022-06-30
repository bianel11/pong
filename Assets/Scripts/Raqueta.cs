using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raqueta : MonoBehaviour
{
    public float Velocity = 30.0f;
    public string ejeV;
    public string ejeH;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // fixedUpdate es llamado antes de cada frame
    void FixedUpdate()
    {
        // vertical posicion de la raqueta
        float v = Input.GetAxisRaw(ejeV);
        // horizontal posicion de la raqueta
        float h = Input.GetAxisRaw(ejeH);

        // Get position
        Vector2 position = GetComponent<Rigidbody2D>().position;

        // Get name of the game object
        string name = GetComponent<Rigidbody2D>().name;

        if (position.x < 2 && name == "RaquetaDerecha")
        {
            h = 2;
        }

        if (position.x > -2 && name == "RaquetaIzquierda")
        {
            h = -2;
        }

        // Modifico la velocidad de la raqueta
        GetComponent<Rigidbody2D>().velocity = new Vector2(h * Velocity, v * Velocity);
    }
}
