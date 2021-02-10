using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float hp = 3;
    public float despawnTime = 4;
    [Header ("Death Animation Values")]
    public Vector2 deathJumpMinMax = new Vector2(300,400);
    public Vector2 deathSpinMinMax = new Vector2(100,300);
    public Vector2 deathKnockbackMinMax = new Vector2(100,250);
    public float fallSpeed = 1f;
    public float flashTime = 0.05f;

    public bool alive { get; private set; }
    private Renderer rend;
    private Rigidbody2D rb;
    private Animator monsterAnimation;
    private BoxCollider2D col;
    private Color originalColor;

    private void Awake() {
        alive = true;
        rb = gameObject.GetComponent<Rigidbody2D>();
        rend = gameObject.GetComponent<Renderer>();
        monsterAnimation = gameObject.GetComponent<Animator>();
        col = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Start() {
        originalColor = rend.material.color;
    }

    void Update() {
        CheckDeath();
    }

    public void TakeDamage(float damage) {
        FlashRed();
        hp -= damage;
    }

    private void CheckDeath() {
        if (hp <= 0 && alive) {
            Die();
            alive = false;
        }
    }

    private void Die() {

        rb.AddForce(transform.up * Random.Range(deathJumpMinMax.x, deathJumpMinMax.y));
        rb.AddTorque(Random.Range(deathSpinMinMax.x,deathSpinMinMax.y)*-1f);
        rb.AddForce(transform.right * Random.Range(deathKnockbackMinMax.x, deathKnockbackMinMax.y));
        rb.gravityScale = fallSpeed;
        monsterAnimation.enabled = false;
        Destroy(col);
        Destroy(gameObject, despawnTime);
    }
    
    private void FlashRed() {
        rend.material.color = Color.red;
        Invoke("ResetColor", flashTime);
    }

    private void ResetColor() {
        rend.material.color = originalColor;
    }

}
