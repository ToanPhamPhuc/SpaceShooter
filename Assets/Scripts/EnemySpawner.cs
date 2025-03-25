using Unity.Hierarchy;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    float spawnDistance = 12f;

    float enemyRate = 5f;

    float nextEnemy = 1;

    // Update is called once per frame
    void Update()
    {
        nextEnemy -= Time.deltaTime;
        if (nextEnemy <= 0)
        {
            nextEnemy = enemyRate;
            enemyRate *= 0.9f;

            if(enemyRate < 2)
            {
                enemyRate = 2;
            }

            float screenRatio = (float) Screen.width / (float )Screen.height;
            float widthOrtho = Camera.main.orthographicSize * screenRatio;

            float spawnX = Random.Range(-widthOrtho, widthOrtho);
            float spawnY = Camera.main.orthographicSize + spawnDistance;

            Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}
