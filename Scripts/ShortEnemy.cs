using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortEnemy : MonoBehaviour
{
    public float speed;
    private Transform target;
    HealthBar healthScript;
    void Start()
    {
        healthScript = GameObject.FindObjectOfType<HealthBar>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, 
            target.position, speed * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Bullet")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag=="Player")
        {
            healthScript.health -= 10;
            Destroy(gameObject);
        }
    }
}
