using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        // Temporizador de spawn de inimigos
        InvokeRepeating("SpawnEnemies", 0.5f, 1.5f);
    }

    void SpawnEnemies() 
    {
        // Definir onde inimigo irá surgir
        int index = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[index].position, Quaternion.identity);
    }
}
