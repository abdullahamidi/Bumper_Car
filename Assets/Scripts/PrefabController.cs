using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabController : MonoBehaviour
{
    public static PrefabController instance;
    public GameObject car;
    GameObject spawnPoints;
    public int playerCount;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        SpawnCars();
    }


    public void SpawnCars()
    {
        switch (playerCount)
        {
            case 8:
                spawnPoints = GameObject.Find("SpawnPoints8");
                foreach (Transform spawnPoint in spawnPoints.transform)
                {
                    Instantiate(car, spawnPoint.position, Quaternion.LookRotation(new Vector3(0,0,0)));
                }
                break;
            default:
                break;
        }
    }

    public void DestroyCar(GameObject car)
    {
        Destroy(car);
    }
}
