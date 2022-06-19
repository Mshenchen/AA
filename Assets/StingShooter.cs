using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingShooter : MonoBehaviour
{
    public GameObject stringPrefab;
    public float stringShootSpeed;
    public bool canShoot;

    // Update is called once per frame
    void Update()
    {
        if (!canShoot)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            ShootString();
        }
    }
    void ShootString()
    {
        GameObject stringObj = Instantiate(stringPrefab);
        stringObj.transform.position = transform.position;
        stringObj.GetComponent<Rigidbody2D>().velocity = Vector2.up * stringShootSpeed;
    }
}
