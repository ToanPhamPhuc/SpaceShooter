using UnityEngine;

public class DamageByCollision : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private float invulnPeriod = 0;
    float invulnTimer = 0;
    int correntLayer;

    SpriteRenderer spriteRend;

    private void Start()
    {
        correntLayer = gameObject.layer; //player 6, enemy 7

        spriteRend = GetComponent<SpriteRenderer>();

        if (spriteRend == null ) {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();
            if (spriteRend == null) {
                Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        health--;
        if (invulnPeriod > 0)
        {
            invulnTimer = invulnPeriod;
            gameObject.layer = 8; //invulnerable in 2s

        }
    }

    void Update()
    {
        if(invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;

            if(invulnTimer <= 0)
            {
                gameObject.layer = correntLayer;
                if (spriteRend != null) {
                    spriteRend.enabled = true;
                }
            }
            else
            {
                if (spriteRend != null)
                {
                    spriteRend.enabled = !spriteRend.enabled;
                }
            }
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        } 
    }

    private void OnGUI()
    {
        if(CompareTag("Player"))
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 50;
            style.normal.textColor = Color.white;
            GUI.Label(new Rect(0, 50, 100, 50), "Health: " + health, style);
        }
    }
}
