using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform myTarget;

    // Update is called once per frame
    void Update()
    {
        if(myTarget != null)
        {
            Vector3 targPos = myTarget.position;
            targPos.z = transform.position.z;
            transform.position = targPos;   
        }
    }
}
