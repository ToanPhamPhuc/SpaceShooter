using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject playerInstance;

    public int numLives = 4;

    float respawnTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        numLives--;
        respawnTimer = 1;
        playerInstance = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

    }
    // Update is called once per frame
    void Update()
    {
        if (playerInstance == null && numLives > 0)
        {
            respawnTimer -= Time.deltaTime;
            if (respawnTimer <= 0)
            {
                SpawnPlayer();
            }

        }
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.white;
        style.fontSize = 50;

        GUIStyle style2 = new GUIStyle();
        style2.normal.textColor = Color.red;
        style2.alignment = TextAnchor.MiddleCenter;
        style2.fontSize = 100;

        if (numLives > 0 || playerInstance != null)
        {
            GUI.Label(new Rect(0, 0, 100, 50), "Lives Left: " + numLives, style);
        }
        else
        {
            GUI.Label(new Rect(Screen.width/2, Screen.height/2, 100, 50), "Game Over!", style2);

        }
    }
}
