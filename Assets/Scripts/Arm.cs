using UnityEngine;

public class Arm : MonoBehaviour
{
    private Camera cam;

    private bool isPaused = false;
    private float originalTime = 1f;
    void Start()
    {
        cam = Camera.main;
        
    }

    private void FixedUpdate()
    {
        pointMouse();
        
    }

    private void Update() {
        if (Input.GetKeyDown("p")) {
            TogglePause();
           
        }
    }

    private void pointMouse() {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(( mousePos.y- transform.position.y) , (mousePos.x- transform.position.x));
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle*Mathf.Rad2Deg));
        
    }

    private void TogglePause() {
        if(isPaused == true) {
            Time.timeScale = originalTime;
            isPaused = false;
        }

        else if(isPaused == false) {
            originalTime = Time.timeScale;
            Time.timeScale = 0;
            isPaused = true;
        }
    }
}
    