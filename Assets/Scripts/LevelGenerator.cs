using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private ScoreManager score;
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

    [SerializeField] private Transform Enemy1;
    [SerializeField] private Transform Enemy2;


    [SerializeField] private Transform CoinGrid;
    

    private GameObject player;

    // 0 = bottom, 1 = middle, 2 = top

    private int exitPosition = 0;

    public Transform target;

    private List<Transform> bottomstart = new List<Transform>();
    private List<Transform> middlestart = new List<Transform>();
    private List<Transform> topstart = new List<Transform>();
    private List<Transform> levelPartList = new List<Transform>();
    private List<Transform> enemyList = new List<Transform>();
    private List<Vector3> enemyPlacementList = new List<Vector3>() {new Vector3(-5, 2), new Vector3(-5, -2), new Vector3(-2, 3), 
    new Vector3(-2, -3), new Vector3(2, 3), new Vector3(2, -3), new Vector3(5, 2), new Vector3(5, -2)};
    // below spawns enemies, maximum of 8, all in predetermined places as shown in the maxgrid
        // valid locations relative to spawn: (x then y)
        // -5, 2    -2, 3       2, 3,   5, 2 
        // -5,-2    -2, -3      2, -3   5, -2



    private int count = 0;
    private void Awake() {
       // GameObject.Find("ScoreDisplay").GetComponent<ScoreManager>().currentScore;
        player =  GameObject.FindGameObjectWithTag("Player");
        score = player.GetComponent<ScoreManager>();

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

        enemyList.Add(Enemy1);
        enemyList.Add(Enemy2);

        count += 14;
        SpawnLevelPart(new Vector3(count, 0));
        LevelFiller(new Vector3(count, 0));
        enemyFiller(new Vector3(count, 0));
        count += 14;
        SpawnLevelPart(new Vector3(count, 0));
        LevelFiller(new Vector3(count, 0));
        enemyFiller(new Vector3(count, 0));
        count += 14;
        SpawnLevelPart(new Vector3(count, 0));
        LevelFiller(new Vector3(count, 0));
        enemyFiller(new Vector3(count, 0));
        count += 14;
        SpawnLevelPart(new Vector3(count, 0));
        LevelFiller(new Vector3(count, 0));
        enemyFiller(new Vector3(count, 0));
        count += 14;
        SpawnLevelPart(new Vector3(count, 0));
        LevelFiller(new Vector3(count, 0));
        enemyFiller(new Vector3(count, 0));
    }
    
    private void Update() {
        if ((count - target.transform.position.x) < PLAYER_DISTANCE_SPAWN) {
            count += 14;
            SpawnLevelPart(new Vector3(count, 0));
            LevelFiller(new Vector3(count, 0));
            enemyFiller(new Vector3(count, 0));
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
    // both of these will scale with score once score is implemented
    private void LevelFiller(Vector3 spawnPosition){
        int listCount = 0;
        for (listCount = 0; listCount < 5; listCount++)
        {
        float randomChoice2 = Random.Range(0.0f, 1.0f);
       // int randomChoice3 = Random.Range(0, 5);
        
        if (randomChoice2 > (0.33 + 0.5 * (score.currentScore/999))) {
            Instantiate(levelPartList[listCount], spawnPosition, Quaternion.identity);
            Debug.Log(0.33 + 0.5 * (score.currentScore/999));
        }
        }
    }
    
    private void enemyFiller(Vector3 spawnPosition){

        // below spawns enemies, maximum of 8, all in predetermined places as shown in the maxgrid
        // valid locations relative to spawn: (x then y)
        // -5, 2    -2, 3       2, 3,   5, 2 
        // -5,-2    -2, -3      2, -3   5, -2


        int listCount2 = 0;
        for (listCount2 = 0; listCount2 < 8; listCount2++)
        {
        float randomChoice2 = Random.Range(0.0f, 1.0f);
        int randomChoice3 = Random.Range(0, 2);
        if (randomChoice2 > (0.33 + 0.5 * (score.currentScore/999))) {
            Instantiate(enemyList[randomChoice3], (spawnPosition + enemyPlacementList[listCount2]), Quaternion.identity);
        }
        }

    }
}
