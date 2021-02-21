using Cinemachine;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0;
    public RuntimeAnimatorController enemyBulletAnim;
    public GameObject flashPrefab;

    [Header ("Parry Shake")]
    public float shakingTime;
    public float amplitude;
    public float frequency;
    
    public string fatherTag { private get; set; }

    private Animator anim;
    private CinemachineVirtualCamera vcam;
    private CinemachineBasicMultiChannelPerlin noise;
    private RuntimeAnimatorController originalAnim;
    private GameObject flashSpawn;
    private Renderer rend;



    private void Awake() {
        flashSpawn = GameObject.Find("FlashSpawn");
        vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        anim = gameObject.GetComponent<Animator>();
        rend = gameObject.GetComponent<Renderer>();
        
    }

    private void Start() {
        originalAnim = anim.runtimeAnimatorController;

        if(fatherTag == "Enemy") {
            anim.runtimeAnimatorController = enemyBulletAnim;
        }
    }

    void Update() { 
        Move();
        
       if(rend.isVisible == false) {
            Destroy(gameObject);
        }
    }

    private void Move() {
        transform.position += (transform.right * speed * Time.deltaTime);
    }

    private void Ricochet(GameObject targetObject) {

        Instantiate(flashPrefab,flashSpawn.transform.position,targetObject.transform.rotation);
        Time.timeScale = 0.1f;
        transform.rotation = targetObject.transform.rotation;
        anim.runtimeAnimatorController = originalAnim;
        fatherTag = "Player";
        speed *= 1.5f;
        cameraShake(amplitude, frequency);
        Invoke("CameraReset", shakingTime);
        Invoke("TimeReset", shakingTime);

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject targetObject = collision.gameObject;

        if (collision.gameObject.tag != fatherTag) {

            if (collision.gameObject.transform.parent != null) { 

                if (collision.gameObject.transform.parent.gameObject.GetComponent<EnemyHP>() != null) {
                    EnemyHP target = collision.gameObject.transform.parent.gameObject.GetComponent<EnemyHP>();
                    target.TakeDamage(1);
                    Destroy(gameObject);
                }

                else if (collision.gameObject.GetComponent<EnemyHP>() != null) {
                    EnemyHP target = collision.gameObject.gameObject.GetComponent<EnemyHP>();
                    target.TakeDamage(1);
                    Destroy(gameObject);
                }
            }

            else if (collision.gameObject.GetComponent<PlayerHP>() != null) {
                PlayerHP player = collision.gameObject.GetComponent<PlayerHP>();
                player.TakeDamage(1);
                Destroy(gameObject);
                
            }

            else if (collision.gameObject.tag == "Slash") {

                if (fatherTag != "Player") { 
                    Ricochet(targetObject);
                }

            }
        }
    }

    private void cameraShake(float amplitude, float frequency) {
        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = frequency;
    }

    private void CameraReset() {
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;
    }

    private void TimeReset() {
        Time.timeScale = 1f;
    }
}

