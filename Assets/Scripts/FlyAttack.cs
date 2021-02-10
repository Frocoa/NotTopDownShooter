using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAttack : MonoBehaviour
{
    public float speed;
    public float attackFlashTime;
    public int attackOdds;
    public GameObject playerObject;
    public Vector2 minMaxAttackDistance;

    private bool attacking = false;
    private Renderer rend;
    private Color originalColor;
    private float originalSpeed;
    private float horizontalDistance;
    private EnemyHP hpClass;

    private void Awake() {
        rend = gameObject.GetComponent<Renderer>();
        hpClass = gameObject.GetComponent<EnemyHP>();
    }
    void Start()
    {
        originalSpeed = speed;
        originalColor = rend.material.color;
    }

    private void FixedUpdate()
    {
        ManageAttack();
 
    }

    private void Hover() {
        horizontalDistance = (transform.position.x- playerObject.transform.position.x);
        transform.position += (-transform.right * speed * Time.deltaTime);
    }

    private void Attack() {
        speed = originalSpeed * 2f;
        Vector3 playerPos= playerObject.transform.position;
        float angle = Mathf.Atan2((transform.position.y - playerPos.y), (transform.position.x - playerPos.x));
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle * Mathf.Rad2Deg));
    }

    private void ManageAttack() {
        if (hpClass.alive == true) {
            Hover();
            if ((Random.Range(0, 1000) < attackOdds && horizontalDistance <= minMaxAttackDistance.x) || horizontalDistance <= minMaxAttackDistance.y) {
                if (attacking == false) {
                    SetGrey();
                    speed = 0f;
                    Invoke("ResetColor", attackFlashTime);
                    Invoke("Attack", attackFlashTime);
                    attacking = true;
                }
            }
        }
        else { speed = 0f; }
    }

    private void SetGrey() {
        rend.material.color = Color.grey;
    }

    private void ResetColor() {
        rend.material.color = originalColor;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.GetComponent<PlayerHP>() != null) {
            PlayerHP player = collision.gameObject.GetComponent<PlayerHP>();
            player.TakeDamage(2);
            Destroy(gameObject);
        }
    }
}
