using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    float cooldownTimer = 0;
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    float fireDelay = 0.25f;
    public GameObject bulletPrefab;

    int bulletLayer;

    private void Start()
    {

        bulletLayer = gameObject.layer;
    }
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if(Input.GetButton("Fire1") && cooldownTimer <= 0) //button held down instead of spammed
        {
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGO.layer = bulletLayer;
        }
    }
}
