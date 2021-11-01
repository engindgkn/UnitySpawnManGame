using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{

    public GameObject enemyPrefab;
    int enemyCount = 0;
    [SerializeField]
    int enemy = 0;

    private void OnTriggerEnter(Collider other)
    {
        enemy = Random.Range(20, 50);

        if (other.gameObject.tag == "MainCharacter")
        {
            while(true)
            {
                if(enemyCount <= enemy)
                {
                    Instantiate(enemyPrefab, new Vector3(Random.Range(6.5f, 25.0f), 6.97f, Random.Range(0.0f, 2.5f)), Quaternion.identity);
                    enemyCount++;
                }
                else
                {
                    break;
                }

            }
            Debug.Log("Spawn Çalıştı");
        }
    }
}
