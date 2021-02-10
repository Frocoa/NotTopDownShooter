using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int hp = 3;

    private bool isAlive = true;
    void Start()
    {
        
    }

    void Update()
    {
        if(checkAlive() == false) {
            Die();
        }
    }

    public void TakeDamage(int damage) {
        hp -= damage;
    }

    public void Heal(int amount) {
        hp += amount;
    }

    public bool checkAlive() {
        if (hp <= 0) {
            isAlive = false;
        }
        return isAlive;
    }

    private void Die() {
        Debug.Log("Dead");
    }
}
