using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineHUD : MonoBehaviour
{
    public Magazine magazine;
    public GameObject bulletPrefab;
    public float distance = 1.5f;
    public Transform ammoTransform;

    private int maxAmmo;
    private List<GameObject> bulletList = new List<GameObject>();

    public static MagazineHUD instance;

    private void Awake() {
        if(instance != null && instance != this) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        maxAmmo = magazine.maxBullets;
    }
    private void Start() 
    {
        for(int i = 0; i < maxAmmo; i++) {
            GameObject bullet = Instantiate(bulletPrefab, bulletPosition(i), transform.rotation);
            bulletList.Add(bullet);
        }
    }

    private void Update()
    {   
    }

    private Vector3 bulletPosition(int number) {
        return(ammoTransform.position+(number*transform.up*distance));
    }
        
    public void removeBullet(int index) {
        bulletList[index - 1].SetActive(false);
       
    }

    public void addBullet(int index) {
        bulletList[index].SetActive(true);
    }
    
}
