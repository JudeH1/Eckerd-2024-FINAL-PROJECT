using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletLaunchPos;
    private float timer;
    void Start()
    {
        
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;
            shoot();
        }
    }
    void shoot()
    {
        Instantiate(bullet, bulletLaunchPos.position, Quaternion.identity);
    }
}   

