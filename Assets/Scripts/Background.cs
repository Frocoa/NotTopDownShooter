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

    private Vector3 size;
    private Vector3 initialPos;
    
    void Awake()
    {
        sky = gameObject.transform.GetChild(0).gameObject;
        mountains = gameObject.transform.GetChild(1).gameObject;
        grass = gameObject.transform.GetChild(2).gameObject;
        ground = gameObject.transform.GetChild(3).gameObject;

        initialPos = sky.transform.position;
        size = sky.GetComponent<Renderer>().bounds.size;
        
    }

    void Update()
    {
        sky.transform.position -= skySpeed * speedMultiplier*transform.right * Time.deltaTime;
        mountains.transform.position -= mountainsSpeed * speedMultiplier * transform.right * Time.deltaTime;
        grass.transform.position -= grassSpeed * speedMultiplier * transform.right * Time.deltaTime;
        ground.transform.position -= groundSpeed * speedMultiplier * transform.right * Time.deltaTime;

        tpComponent(sky);
        tpComponent(mountains);
        tpComponent(grass);
        tpComponent(ground);
    }

    private void tpComponent(GameObject component) {
        if(component.transform.position.x <= (initialPos.x - size.x)) {
            component.transform.position = initialPos;
        }
    }
}
