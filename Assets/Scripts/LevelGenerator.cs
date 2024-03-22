using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    // this variable is used for determining when to spawn new terrain
    private const float PLAYER_DISTANCE_SPAWN = 56;

    [SerializeField] private Transform Grid;
    public Transform target;


    private int count = 0;
    private void Awake() {
        count += 14;
        SpawnLevelPart(new Vector3(count, 0));
        count += 14;
        SpawnLevelPart(new Vector3(count, 0));
        count += 14;
        SpawnLevelPart(new Vector3(count, 0));
        count += 14;
        SpawnLevelPart(new Vector3(count, 0));
        count += 14;
        SpawnLevelPart(new Vector3(count, 0));
    }
    
    private void Update() {
        if ((count - target.transform.position.x) < PLAYER_DISTANCE_SPAWN) {
            count += 14;
            SpawnLevelPart(new Vector3(count, 0));
        }
    }

    private void SpawnLevelPart(Vector3 spawnPosition){
        Instantiate(Grid, spawnPosition, Quaternion.identity);
    }
}
