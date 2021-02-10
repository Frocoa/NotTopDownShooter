using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speedMultiplier;
    public float skySpeed;
    public float mountainsSpeed;
    public float grassSpeed;
    public float groundSpeed;

    private GameObject sky;
    private GameObject mountains;
    private GameObject grass;
    private GameObject ground;
    
    void Awake()
    {
        sky = gameObject.transform.GetChild(0).gameObject;
        mountains = gameObject.transform.GetChild(1).gameObject;
        grass = gameObject.transform.GetChild(2).gameObject;
        ground = gameObject.transform.GetChild(3).gameObject;
        
    }

    void Update()
    {
        sky.transform.position += -transform.right * skySpeed * speedMultiplier * Time.deltaTime;
        mountains.transform.position += -transform.right * mountainsSpeed * speedMultiplier * Time.deltaTime;
        grass.transform.position += -transform.right * grassSpeed * speedMultiplier * Time.deltaTime;
        ground.transform.position += -transform.right * groundSpeed * speedMultiplier * Time.deltaTime;

    }
}
