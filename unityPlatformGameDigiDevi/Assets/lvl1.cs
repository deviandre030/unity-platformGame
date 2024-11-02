using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lvl1 : MonoBehaviour
{
    public Rigidbody2D rb;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "lvl1")
        {
            
            rb.transform.position = new Vector3(-170f, 35f, 0);
        }
    }
    
}
