using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnimManager : MonoBehaviour
{
    private Animator animator;
    private float startTime;
    private float passedTime;

     void Awake() {
        animator = gameObject.GetComponent<Animator>();
        
    }

    void Start() {
        startTime = Time.time;
        
    }

    void Update()
    {
        passedTime = Time.time - startTime;

        if (passedTime >= 0.1) {
            checkDespawn();
        }
    }

 private void checkDespawn() {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("slash_anim")) {
            Destroy(gameObject);
        } 
    }
}
