using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject target;
    public GameObject bulletPrefab;

    private Vector3 targetPosition;
    private EnemyHP hpClass;
    private float cooldown = 1;
    private float timePassed = 0;
    private float startTime = 0;

    private void Awake() {
        hpClass = gameObject.GetComponentInParent<EnemyHP>();
    }
    void Update()
    {
        if (hpClass.alive == true) {
            if (timePassed >= cooldown) {
                Shoot();
                timePassed = 0;
                startTime = Time.time;
            }
        }

        timePassed = Time.time - startTime;
    }

    private void Shoot() {

        targetPosition = target.transform.position;
        Vector3 playerPos = targetPosition;
        float angle = Mathf.Atan2((playerPos.y- transform.position.y), (playerPos.x- transform.position.x));
        Quaternion quaterion = Quaternion.Euler(new Vector3(0, 0, angle * Mathf.Rad2Deg)); 
        GameObject bullet = Instantiate(bulletPrefab, transform.position,quaterion);
        bullet.GetComponent<Bullet>().fatherTag = transform.tag;

    }
}
