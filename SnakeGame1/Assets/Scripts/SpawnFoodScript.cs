using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFoodScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Spawn food in every 4 seconds, starting in 3 seconds
        InvokeRepeating("Spawn", 3, 4);
        InvokeRepeating("SpawnEnergy", 10, 15);
        InvokeRepeating("SpawnPoison", 15, 20);
        InvokeRepeating("SpawnLife", 0, 25);
	}
    //Food Prefab
    public GameObject foodPrefab;
    public GameObject energyFoodPrefab;
    public GameObject poisonPrefab;
    public GameObject lifePrefab;

    //Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    void Spawn()
    {
        int x = (int) Random.Range(borderLeft.position.x+1, borderRight.position.x-1);
        int y = (int) Random.Range(borderBottom.position.y+1, borderTop.position.y-1);
        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }

    void SpawnEnergy()
    {
        int x = (int) Random.Range(borderLeft.position.x+1, borderRight.position.x-1);
        int y = (int) Random.Range(borderBottom.position.y+1, borderTop.position.y-1);
        Instantiate(energyFoodPrefab, new Vector2(x, y), Quaternion.identity);
    }
    void SpawnPoison()
    {
        int x = (int)Random.Range(borderLeft.position.x + 1, borderRight.position.x - 1);
        int y = (int)Random.Range(borderBottom.position.y + 1, borderTop.position.y - 1);
        Instantiate(poisonPrefab, new Vector2(x, y), Quaternion.identity);
    }
    void SpawnLife()
    {
        int x = (int)Random.Range(borderLeft.position.x + 1, borderRight.position.x - 1);
        int y = (int)Random.Range(borderBottom.position.y + 1, borderTop.position.y - 1);
        Instantiate(lifePrefab, new Vector2(x, y), Quaternion.identity);
    }
}
