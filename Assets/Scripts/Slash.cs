using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public GameObject slashPrefab;
    public Transform slashSpawn;

    void Start()
    {
        
    }

    void Update()
    {
        summonSlash();

    }
    private void summonSlash() {
        if (Input.GetMouseButtonDown(1)) {
            Instantiate(slashPrefab, slashSpawn.position, slashSpawn.rotation);
        }
    }

    
}
