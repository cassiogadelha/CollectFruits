using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] items;
    private GameManager gameManager;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("CreateObject", 1f, 1f);
    }

    void Update()
    {
        
    }

    public void CreateObject()
    {
        if(player != null && gameManager.startGame)
        {
            Instantiate(items[Random.Range(0, 3)], new Vector3(Random.Range(-8f, 8f), 10f, 0), Quaternion.identity);
        }
    }
}
