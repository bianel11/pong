using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raqueta : MonoBehaviour
{
  public float Velocity = 30.0f;

  public string eje;

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
    float v = Input.GetAxisRaw(eje);
    // Modifico la velocidad de la raqueta
    GetComponent<Rigidbody2D>().velocity = new Vector2(0, v * Velocity);
  }
}
