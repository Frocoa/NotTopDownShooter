using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    public int maxBullets;
    public float reloadDelay;

    public  bool isReloading { get; private set; }
    public bool tryingToReload = false;
    private int bulletAmount;

    void Awake() {
        bulletAmount = maxBullets;
 
    }
    void Update()
    {
        if (Input.GetKeyDown("r")) {
            Reload();
        }
        if (Input.GetMouseButtonDown(0) && bulletAmount == 0) {
            Reload();
        }
        
        
    }
    
    public int GetBullets() {
        return bulletAmount;
    }

    public void ReduceBulletAmount(int amount) {
        bulletAmount -= amount;
    }

    public IEnumerator AddBullet() {
        float startBulletAmount = bulletAmount;
        for (int i = 0; i < (maxBullets - startBulletAmount); i++) {
            yield return new WaitForSeconds(reloadDelay);
            AddBullet();
            bulletAmount++;
            MagazineHUD.instance.addBullet(bulletAmount - 1);
            
        }
        isReloading = false;
    }

    public void Reload() {
        if(bulletAmount < maxBullets && isReloading == false) {
            isReloading = true;
            StartCoroutine("AddBullet");
        }
    }

    public void FullyReload() {
        bulletAmount = maxBullets;
    }

}
