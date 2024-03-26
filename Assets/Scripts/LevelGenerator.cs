using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    // this variable is used for determining when to spawn new terrain
    private const float PLAYER_DISTANCE_SPAWN = 56;

    [SerializeField] private Transform Grid1;
    [SerializeField] private Transform Grid2;
    [SerializeField] private Transform Grid3;
    [SerializeField] private Transform Grid4;
    [SerializeField] private Transform Grid5;
    [SerializeField] private Transform Grid6;
    [SerializeField] private Transform Grid7;
    [SerializeField] private Transform Grid8;
    [SerializeField] private Transform Grid9;

    



    // 0 = bottom, 1 = middle, 2 = top

    private int exitPosition = 0;

    public Transform target;

    private List<Transform> bottomstart = new List<Transform>();
    private List<Transform> middlestart = new List<Transform>();
    private List<Transform> topstart = new List<Transform>();


    private int count = 0;
    private void Awake() {



        bottomstart.Add(Grid2);
        bottomstart.Add(Grid3);
        bottomstart.Add(Grid1);


        middlestart.Add(Grid4);
        middlestart.Add(Grid5);
        middlestart.Add(Grid6);


        topstart.Add(Grid7);
        topstart.Add(Grid8);
        topstart.Add(Grid9);

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
        if (exitPosition == 0) {
            int randomChoice = Random.Range(0, 2);
            Instantiate(bottomstart[randomChoice], spawnPosition, Quaternion.identity);
            exitPosition = randomChoice; //position of chosen in list
        }
        else if (exitPosition == 1) {
            int randomChoice = Random.Range(0, 2);
            Instantiate(middlestart[randomChoice], spawnPosition, Quaternion.identity);
            exitPosition = randomChoice; //position of chosen
        }
        else if (exitPosition == 2) {
            int randomChoice = Random.Range(0, 2);
            Instantiate(topstart[randomChoice], spawnPosition, Quaternion.identity);
            exitPosition = randomChoice; //position of chosen
        }
    }
}
