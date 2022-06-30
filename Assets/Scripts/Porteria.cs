using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porteria : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Detectar si la bola atraviesa la porteria
    void OnTriggerEnter2D(Collider2D bola)
    {
        if (bola.name == "Bola")
        {
            // Si es la porteria izquierda
            if (this.name == "Izquierda")
            {
                print(this.name);

                // contar el gol y reinicial la bola
                bola.GetComponent<Bola>().reiniciarBola("Derecha");

            }

            // Si es la porteria derecha
            else if (this.name == "Derecha")
            {
                print(this.name);
                // contar el gol y reinicio la bola
                bola.GetComponent<Bola>().reiniciarBola("Izquierda");
            }

        }
    }
}
