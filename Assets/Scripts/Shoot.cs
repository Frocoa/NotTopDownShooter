using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float cooldown = 0;

    private float deltaTime = 0;
    private float shootMoment = 0;
    private Magazine magazine;
    void Awake()
    {
        if(gameObject.GetComponent<Magazine>() != null) {
            magazine = gameObject.GetComponent<Magazine>();
        }
        
    }

 
    void Update()
    {
        if (deltaTime >= cooldown) {
            SummonBullet();  
        }
        deltaTime = Time.time - shootMoment;
    }

    private void SummonBullet() { 
        if (Input.GetMouseButtonDown(0) && magazine.GetBullets() > 0 && magazine.isReloading == false) {

            MagazineHUD.instance.removeBullet(magazine.GetBullets());
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Bullet>().fatherTag = transform.tag;
            magazine.ReduceBulletAmount(1);
            shootMoment = Time.time;
        }

    }
}
