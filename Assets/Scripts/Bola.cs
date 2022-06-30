using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bola : MonoBehaviour
{
    public float Velocity = 30.0f;

    //Contadores de goles
    public int golesIzquierda = 0;
    public int golesDerecha = 0;
    //Cajas de texto de los contadores
    public Text contadorIzquierda;
    public Text contadorDerecha;

    // Audios
    AudioSource fuenteDeAudio;

    // Clips
    public AudioClip audioGol, audioRaqueta, audioRebote;

    // Start is called before the first frame update
    void Start()
    {
        //Velocidad inicial hacia la dercha
        GetComponent<Rigidbody2D>().velocity = Vector2.right * Velocity;

        // Recuperar el componente audio source;
        fuenteDeAudio = GetComponent<AudioSource>();

        // Poner contadores en 0
        contadorDerecha.text = golesIzquierda.ToString();
        contadorIzquierda.text = golesDerecha.ToString();

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
        if (miColission.gameObject.name == "RaquetaIzquierda")
        {
            //Valor de x
            int x = 1;

            //Valor de y
            int y = direccionY(transform.position, miColission.transform.position);

            // Calculo direccion de la bola
            Vector2 direccion = new Vector2(x, y);

            // Aplico velocidad a la bola
            GetComponent<Rigidbody2D>().velocity = direccion * Velocity;

            // Reproducir audio
            fuenteDeAudio.clip = audioRaqueta;
            fuenteDeAudio.Play();
        }

        //Si choca con la raqueta derecha
        if (miColission.gameObject.name == "RaquetaDerecha")
        {
            //Valor de x
            int x = -1;

            //Valor de y
            int y = direccionY(transform.position, miColission.transform.position);

            // Calculo direccion de la bola (normalizada para que de 1 o -1)
            Vector2 direccion = new Vector2(x, y);

            // Aplico velocidad a la bola
            GetComponent<Rigidbody2D>().velocity = direccion * Velocity;

            // Reproducir audio
            fuenteDeAudio.clip = audioRaqueta;
            fuenteDeAudio.Play();
        }

        // Para el sonido de rebote
        if (miColission.gameObject.name == "Arriba" || miColission.gameObject.name == "Abajo")
        {
            // Reproducir audio del rebote
            fuenteDeAudio.clip = audioRebote;
            fuenteDeAudio.Play();
        }
    }

    // Reiniciar la bola
    public void reiniciarBola(string direccion)
    {
        // posicion 0 de la bola
        transform.position = Vector2.zero;
        //Vector2.zero es lo mismo que new Vector2(0,0);

        // velocidad inicial de la bola 
        Velocity += 5f;

        // velocidad y direccion
        if (direccion == "Derecha")
        {
            // incrementar goles a la de la derecha
            golesDerecha++;
            // marcarlo en el marcador
            contadorDerecha.text = golesDerecha.ToString();

            // reinicio la bola
            GetComponent<Rigidbody2D>().velocity = Vector2.right * Velocity;
            //Vector2.right es lo mismo que new Vector2(1,0)
        }
        else if (direccion == "Izquierda")
        {
            // incrementar goles a la de la izquierda
            golesIzquierda++;

            // marcarlo en el marcador
            contadorIzquierda.text = golesIzquierda.ToString();

            // reinicio la bola
            GetComponent<Rigidbody2D>().velocity = Vector2.left * Velocity;

            //Vector2.left es lo mismo que new Vector2(-1,0)
        }
        fuenteDeAudio.clip = audioGol;
        fuenteDeAudio.Play();
    }
}
