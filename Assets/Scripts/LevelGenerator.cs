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

    [SerializeField] private Transform Part1;
    [SerializeField] private Transform Part2;
    [SerializeField] private Transform Part3;
    [SerializeField] private Transform Part4;
    [SerializeField] private Transform Part5;


    [SerializeField] private Transform CoinGrid;
    



    // 0 = bottom, 1 = middle, 2 = top

    private int exitPosition = 0;

    public Transform target;

    private List<Transform> bottomstart = new List<Transform>();
    private List<Transform> middlestart = new List<Transform>();
    private List<Transform> topstart = new List<Transform>();
    private List<Transform> levelPartList = new List<Transform>();


    private int count = 0;
    private void Awake() {

        levelPartList.Add(Part1);
        levelPartList.Add(Part2);
        levelPartList.Add(Part3);
        levelPartList.Add(Part4);
        levelPartList.Add(Part5);


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
        LevelFiller(new Vector3(count, 0));
        SpawnLevelPart(new Vector3(count, 0));
        count += 14;
        SpawnLevelPart(new Vector3(count, 0));
        LevelFiller(new Vector3(count, 0));
        count += 14;
        SpawnLevelPart(new Vector3(count, 0));
        LevelFiller(new Vector3(count, 0));
        count += 14;
        SpawnLevelPart(new Vector3(count, 0));
        LevelFiller(new Vector3(count, 0));
        count += 14;
        SpawnLevelPart(new Vector3(count, 0));
        LevelFiller(new Vector3(count, 0));
    }
    
    private void Update() {
        if ((count - target.transform.position.x) < PLAYER_DISTANCE_SPAWN) {
            count += 14;
            SpawnLevelPart(new Vector3(count, 0));
            LevelFiller(new Vector3(count, 0));
        }
    }

    private void SpawnLevelPart(Vector3 spawnPosition){
        if (exitPosition == 0) {
            int randomChoice = Random.Range(0, 3);
            Instantiate(CoinGrid, spawnPosition, Quaternion.identity);
            Instantiate(bottomstart[randomChoice], spawnPosition, Quaternion.identity);
            exitPosition = randomChoice; //position of chosen in list
        }
        else if (exitPosition == 1) {
            int randomChoice = Random.Range(0, 3);
            Instantiate(CoinGrid, spawnPosition, Quaternion.identity);
            Instantiate(middlestart[randomChoice], spawnPosition, Quaternion.identity);
            exitPosition = randomChoice; //position of chosen
        }
        else if (exitPosition == 2) {
            int randomChoice = Random.Range(0, 3);
            Instantiate(CoinGrid, spawnPosition, Quaternion.identity);
            Instantiate(topstart[randomChoice], spawnPosition, Quaternion.identity);
            exitPosition = randomChoice; //position of chosen
        }
    }

    // the below code fills the level with obstacles randomly
    // probably need to update it so there's no duplicates
    private void LevelFiller(Vector3 spawnPosition){
        int listCount = 0;
        for (listCount = 0; listCount < 5; listCount++)
        {
        float randomChoice2 = Random.Range(0.0f, 1.0f);
        int randomChoice3 = Random.Range(0, 5);
        if (randomChoice2 > 0.33) {
            Instantiate(levelPartList[randomChoice3], spawnPosition, Quaternion.identity);
        }
        }

    }
}
