using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float rotSpeed = 180f;

    float shipBoundaryRadius = 0.5f;

    private void Update()
    {
        //Rotating
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        //Moving
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity; //Quaternion comes first

        //Camera Boundaries (REMEMBER THE DAMN "-")
        if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        }
        if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        }

        
        float widthOrtho = Camera.main.orthographicSize * Camera.main.aspect;

        if (pos.x + shipBoundaryRadius > widthOrtho)
        {
            pos.x = widthOrtho - shipBoundaryRadius;
        }
        if (pos.x - shipBoundaryRadius < -widthOrtho)
        {
            pos.x = -widthOrtho + shipBoundaryRadius;
        }

        transform.position = pos;
        //transform.Translate(new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        
        


    }
}
