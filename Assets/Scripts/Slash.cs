using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public GameObject slashPrefab; 

    void Start()
    {
        
    }

    void Update()
    {
        summonSlash();

    }
    private void summonSlash() {
        if (Input.GetMouseButtonDown(1)) {
            Instantiate(slashPrefab, transform.position, transform.rotation);
        }
    }

    
}
