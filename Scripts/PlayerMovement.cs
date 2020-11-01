using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public float fieldofImpact;
    public LayerMask LayerToHit;
    public Camera cam;
    public GameObject energyBlast;
    public GameManager GM;
    private Vector2 movement;
    private Vector2 mousePos;
    public AudioSource Blast;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void BlastOff()
    {
        Instantiate(energyBlast, transform.position, Quaternion.identity);
        Blast.Play();
        Invoke("DestroyAlll", 0.5f);
    }

    public void DestroyAlll()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, LayerToHit);
        for(int i = 0; i<objects.Length; i++)
        {
            Destroy(objects[i].gameObject); 
        }

        GM.secBlast = 0f;
        GM.BombBlastBar.interactable = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,fieldofImpact);
    }
}
