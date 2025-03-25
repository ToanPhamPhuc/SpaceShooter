using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    float timer = 5f;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) Destroy(gameObject);
    }
}
