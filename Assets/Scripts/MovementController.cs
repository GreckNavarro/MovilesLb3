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


    [Header("Player Stats")]
    [SerializeField] int health;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        gyroEnabled = SystemInfo.supportsGyroscope;

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
            Destroy(collision.gameObject);
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
