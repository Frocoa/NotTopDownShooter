using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    public int maxBullets;

    private int bulletAmount;

    void Awake() {
        bulletAmount = maxBullets;
 
    }
    void Update()
    {

        if (Input.GetKeyDown("r")) {
            Reload();
            MagazineHUD.instance.addBullet(bulletAmount-1);
        }
        
    }
    
    public int GetBullets() {
        return bulletAmount;
    }

    public void ReduceBulletAmount(int amount) {
        bulletAmount -= amount;
    }

    public void Reload() {
        if(bulletAmount < maxBullets) {
            bulletAmount += 1;
        }
    }

    public void FullyReload() {
        bulletAmount = maxBullets;
    }

}
