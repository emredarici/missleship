using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance { get; private set; }

    private Rigidbody2D shipRb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private GameObject ground;
    private float input;

    void Awake()
    {
        Instance = this;
        shipRb = this.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        shipRb.velocity = transform.up * moveSpeed * Time.deltaTime;
        shipRb.angularVelocity = -input * rotateSpeed * Time.deltaTime;
    }
    void Update()
    {
        GroundUpdate();

        input = Input.GetAxis("Horizontal");
    }
    void GroundUpdate()
    {
        ground.transform.Translate(Vector2.down * 3 * Time.deltaTime, Space.Self);

        if (ground.transform.localPosition.y < -6)
        {
            ground.transform.localPosition = new Vector2(0, 9.963f);
        }
    }
}
