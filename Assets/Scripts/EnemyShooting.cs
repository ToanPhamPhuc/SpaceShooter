using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    float cooldownTimer = 0;
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    float fireDelay = 1f;
    public GameObject bulletPrefab;

    Transform player;

    int bulletLayer;

    private void Start()
    {
        
        bulletLayer = gameObject.layer;
    }

    void Update()
    {
        if (player == null)
        {
            GameObject go = GameObject.FindWithTag("Player");


            if (go != null) { player = go.transform; }
        }

        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0 && player !=null && Vector3.Distance(transform.position, player.position) < 4) //button held down instead of spammed
        {
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGO.layer = bulletLayer;
        }
    }
}
