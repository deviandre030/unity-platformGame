using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowing : MonoBehaviour
{
    // Start is called before the first frame update
    public float cameraSpeed = 2f;
    public float OffSetx = 2f;
    public float OffSety = 2f;
    public Transform followBody;
    
    void Update()
    {
        Vector3 newPos = new Vector3(followBody.position.x + OffSetx, followBody.position.y + OffSety, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, cameraSpeed*Time.deltaTime);
    }
}
