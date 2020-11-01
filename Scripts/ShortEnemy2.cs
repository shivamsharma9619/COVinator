using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortEnemy2 : MonoBehaviour
{
    public float speed;
    private Transform target;
    public GameObject refill;
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
            Collider2D m_collider = GetComponent<Collider2D>();
            SpriteRenderer m_renderer = GetComponent<SpriteRenderer>();
            m_renderer.enabled = false;
            m_collider.enabled = false;
            refill.SetActive(true);
        }
        if(collision.gameObject.tag=="Player")
        {
            healthScript.health -= 5;
            Destroy(gameObject);
        }
    }
}
