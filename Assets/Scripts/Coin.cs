using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // increase score once score is implemented
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            //don't increase score
            Destroy(gameObject);
        }
        else
        {
           // Destroy(gameObject);
        }
    }
}
