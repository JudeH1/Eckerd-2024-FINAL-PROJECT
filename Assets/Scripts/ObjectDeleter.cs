using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectDeleter : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player =  GameObject.FindGameObjectWithTag("Player"); //makes it so the player is set for prefabs
        // might want to change the above to the wall of death later, if backtracking is allowed.
        
    }

    // Update is called once per frame
    void Update()
    {
     if ((player.transform.position.x - transform.position.x) > 30)
     {
        Destroy(gameObject);
     }

    }
}
