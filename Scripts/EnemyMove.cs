using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public GameObject[] enemies;
    private Transform target;
    public AudioSource Enemy;
    HealthBar healthScript;

    public GameObject explosionPrefab;
    // Start is called before the first frame update
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
         if(collision.gameObject.tag=="Player")
         {
             healthScript.health -= 15;
             Destroy(gameObject);
         }
         if(collision.gameObject.tag=="Bullet")
         {
             Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Collider2D m_collider = GetComponent<Collider2D>();
                SpriteRenderer m_renderer = GetComponent<SpriteRenderer>();
                m_renderer.enabled = false;
                m_collider.enabled = false;
                enemies[0].SetActive(true);
                enemies[1].SetActive(true);
                Enemy.Play();
            }
     }
}
