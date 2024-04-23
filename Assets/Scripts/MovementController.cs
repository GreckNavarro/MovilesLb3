using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    private bool gyroEnabled;
    private Gyroscope gyro;
    public float moveSpeed;
    private SpriteRenderer spriteRenderer;
    [SerializeField] ScoreManager scoreManager;


    

    float startvalueY;


    [Header("Player Stats")]
    [SerializeField] int health;


    [Header("ObjectPooling")]
    [SerializeField] ObjectPoolDinamic objectPoling;
    [SerializeField] float timeShoot;
    [SerializeField] private bool isShooting = false;

    [SerializeField] EffectsSO shoot;
    [SerializeField] EffectsSO collisionclip;




    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        gyroEnabled = SystemInfo.supportsGyroscope;

        startvalueY = Input.acceleration.y;

        if (gyroEnabled)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
        else
        {
            Debug.Log("Gyroscope not supported");
        }

        moveSpeed = GameStats.Instance.GetSO().SpeedY;
        health = GameStats.Instance.GetSO().Health;
        spriteRenderer.sprite = GameStats.Instance.GetSO().ShipSprite;




    }

    private void FixedUpdate()
    {
        if (gyroEnabled)
        {
            MovementGyroscope();
        }
     
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            {
                if(touch.phase == TouchPhase.Began && isShooting == false)
                {
                    isShooting = true;
                    StartCoroutine(SpawnObjects());
                }
                else if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    isShooting = false;
                }
            }
        }
    }


    IEnumerator SpawnObjects()
    {
        while (isShooting)
        {
            objectPoling.GetObject();
            shoot.StartSoundSelection();
            yield return new WaitForSeconds(timeShoot);
        }
    }

    /*private void MovementAcelerometro()
    {
        float accelerationY = Input.acceleration.y;
        float valuecurrent = accelerationY - sta;
        Debug.Log(accelerationY);
        Debug.Log(valuecurrent);
        Vector2 newposition = transform.position + Vector3.up * startvalueY * moveSpeed * Time.deltaTime;
        newposition.y = Mathf.Clamp(newposition.y, -4.0f, 4.0f);
        transform.position = newposition;
    }*/

    private void MovementGyroscope()
    {
        Quaternion deviceRotation = gyro.attitude;
        float tiltY = -Mathf.Clamp(deviceRotation.eulerAngles.y, 0f, 180f) / 90f + 1f;

        Vector2 newposition = transform.position + Vector3.up * tiltY * moveSpeed * Time.deltaTime;
        newposition.y = Mathf.Clamp(newposition.y, -4.0f, 4.0f);
        transform.position = newposition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            TakeDamage(1);
            collisionclip.StartSoundSelection();
        }
        if(collision.gameObject.tag == "Alien")
        {
            TakeDamage(2);
            collisionclip.StartSoundSelection();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        scoreManager.GetComponent<ScoreManager>().ChangeTextHealth(health);
        if (health <= 0f)
        {
            Destroy(gameObject);
            scoreManager.GetComponent<ScoreManager>().UpdateScore(true);

        }
    }
}
