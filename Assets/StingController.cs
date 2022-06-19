using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Rotator"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transform.parent = coll.transform;
            coll.GetComponent<Rotator>().GetHit();          
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("String"))
        {
            FindObjectOfType<Rotator>().GameOver();
        }
    }
    
}
