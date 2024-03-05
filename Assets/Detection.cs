using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Detection : MonoBehaviour
{
 public float speed = 3f;
 private Transform target;

private void Update() {
    if (target != null) {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.position, step);
    }
}
 private void OnTriggerEnter2D(Collider2D other){
    if (other.gameObject.tag == "Player"){
        target = other.transform;
    }
 }
 private void OnTriggerExit2D(Collider2D other){
    if (other.gameObject.tag == "Player"){
        target = null;
    }

}
}