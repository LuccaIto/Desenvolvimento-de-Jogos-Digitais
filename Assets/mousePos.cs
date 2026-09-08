using UnityEngine;
using System.Collections;


public class mousePos : MonoBehaviour
{

    private float speed = 5f;
    private Rigidbody2D rb2d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var pos = transform.position;
        pos.x = mousePos.x;
        pos.y = mousePos.y;
        transform.position = pos;

        Vector3 playerPos = transform.position;
        Vector3 dir = mousePos - playerPos;
        dir.Normalize();
        Vector3 speedVec = dir * speed;

        var vel = rb2d.linearVelocity;
        vel.x = speedVec.x;
        vel.y = speedVec.y;
        rb2d.linearVelocity = vel; 

    }
}
