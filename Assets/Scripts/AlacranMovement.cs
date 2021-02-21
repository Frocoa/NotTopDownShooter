using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlacranMovement : MonoBehaviour
{
    public float jumpForce;
    public float jumpCooldown;

    private Rigidbody2D rb;
    private EnemyHP alacranHP;
    private float startTime = 0;
    private float passedTime;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        alacranHP = gameObject.GetComponent<EnemyHP>();
    }

    private void Update()
    {
        if(passedTime >= jumpCooldown && alacranHP.alive) {
            Jump();
            startTime = Time.time;
        }
        passedTime = Time.time - startTime;
    }

    private void Jump() {
        rb.AddForce(new Vector3(0, jumpForce));
    }
}
