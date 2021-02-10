using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float cooldown = 0;
    private float deltaTime = 0;
    private float shootMoment = 0;

    void Start()
    {
        
    }

 
    void Update()
    {
        if (deltaTime >= cooldown) {
            summonBullet();  
        }
        deltaTime = Time.time - shootMoment;
    }

    private void summonBullet() { 
        if (Input.GetMouseButtonDown(0)) {

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Bullet>().fatherTag = transform.tag;
            shootMoment = Time.time;
        }

    }
}
