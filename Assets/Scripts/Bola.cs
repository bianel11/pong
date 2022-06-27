using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
  public float Velocity = 30.0f;
  // Start is called before the first frame update
  void Start()
  {
    //Velocidad inicial hacia la dercha
    GetComponent<Rigidbody2D>().velocity = Vector2.right * Velocity;
  }

  // Update is called once per frame
  void Update()
  {

  }
  int direccionY(Vector2 posicionBola, Vector2 posicionRaqueta)
  {
    if
       (posicionBola.y > posicionRaqueta.y)
    {
      return 1;
    }
    else if (posicionBola.y < posicionRaqueta.y)
    {
      return -1;
    }
    return 0;
  }
  void OnCollisionEnter2D(Collision2D miColission)
  {
    //Col contiene toda la información de la colisión
    //Si la bola colisiona con la raqueta:
    // micolision.gameObject es la raqueta
    // micolision.transform.position es la posición de la raqueta

    //Si choca con la raqueta izquierda
    if (miColission.gameObject.name == "Raqueta Izquierda")
    {
      //Valor de x
      int x = 1;

      //Valor de y
      int y = direccionY(transform.position, miColission.transform.position);

      // Calculo direccion de la bola
      Vector2 direccion = new Vector2(x, y);

      // Aplico velocidad a la bola
      GetComponent<Rigidbody2D>().velocity = direccion * Velocity;
    }

    //Si choca con la raqueta derecha
    if (miColission.gameObject.name == "Raqueta Derecha")
    {
      //Valor de x
      int x = -1;

      //Valor de y
      int y = direccionY(transform.position, miColission.transform.position);

      // Calculo direccion de la bola (normalizada para que de 1 o -1)
      Vector2 direccion = new Vector2(x, y);

      // Aplico velocidad a la bola
      GetComponent<Rigidbody2D>().velocity = direccion * Velocity;
    }
  }
}
