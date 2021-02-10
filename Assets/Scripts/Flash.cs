using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public float speed;

    private Renderer rend;
    private float startTime;
    private float passedTime;
    void Awake()
    {
        rend = transform.GetComponent<Renderer>();
        startTime = Time.time;
    }

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        passedTime = Time.time - startTime;

        if(rend.isVisible == false && passedTime >= 0.1) {
            Destroy(gameObject);
        }
    }
}
