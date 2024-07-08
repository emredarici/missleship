using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleScript : MonoBehaviour
{
    private Rigidbody2D missleRb;
    [SerializeField] private GameObject misslesPrefab;
    [SerializeField] private float missleSpeed;
    [SerializeField] private float missleRotateSpeed;
    [SerializeField] ParticleSystem explosion;
    void Awake()
    {
        missleRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var direction = PlayerScript.Instance.transform.position - this.transform.position;

        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        missleRb.velocity = transform.up * (missleSpeed * Time.deltaTime);
        missleRb.angularVelocity = -rotateAmount * (missleRotateSpeed * Time.deltaTime);
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Explosion();
            PlayerDetect();
            StartCoroutine(GameManager.Instance.Lose());
        }
    }
    public void Explosion()
    {
        this.missleSpeed = 0;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.explosion.Play();
    }
    void PlayerDetect()
    {
        PlayerScript.Instance.gameObject.SetActive(false);
    }
}
