using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallofDeath : MonoBehaviour
{

    public float baseSpeed = 1.0f;
    public float speed = 0f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player =  GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        rubberBand();
        Debug.Log(speed);
        transform.Translate(Vector3.right * (baseSpeed + speed) * Time.deltaTime);
    }

    private void rubberBand() // speeds up wall of death if player is getting too far ahead
    // might even want to slow it down when wall is super close for balancing/fun reasons
    {
        if ((player.transform.position.x - transform.position.x) > 30)
        {
            speed += (1 * Time.deltaTime);
            // also might want to change this, shouldn't be faster than the player, but that's easy to tweak once we have a whole game ready
        }

        else
        {
            speed = 0;
        }

    }
}
