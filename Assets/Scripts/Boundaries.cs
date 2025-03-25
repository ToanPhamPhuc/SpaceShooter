using UnityEngine;

public class Boundaries : MonoBehaviour
{
    Vector2 screenBounds;
    float objWidth;
    float objHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width, Screen.height, Camera.main.transform.position.z));
        objWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objWidth, screenBounds.x*-1 - objWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objHeight, screenBounds.y*-1 - objHeight);
        transform.position = viewPos;
    }
}
