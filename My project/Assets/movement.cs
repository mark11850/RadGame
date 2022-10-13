using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Transform PlayerCamera;
    public Rigidbody PlayerBody;

    public float sprint = .75f;
    public float Speed = 0.1f;
    private float Jumpforce = 100f;
    public float smootheturn = 0.1f;
    float turnsmoothevelocity;
    // private float Sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        PlayerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward * 2 * Time.deltaTime;

        if (Input.GetKey(KeyCode.S))
            transform.position += Vector3.back * 2 * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
            transform.position += transform.forward * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
            transform.position += transform.forward * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
            PlayerBody.AddForce(Vector3.up * Jumpforce);

        if (Input.GetKey(KeyCode.LeftShift))
            transform.position += transform.forward * 4 * Time.deltaTime;


        //



        //upcoming code retrieved from "https://www.youtube.com/watch?v=b1uoLBp2I1w" rytech on youtube


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float facing = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + PlayerCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, facing, ref turnsmoothevelocity, smootheturn);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, facing, 0f) * Vector3.forward;
            PlayerBody.MovePosition(direction * Speed * Time.deltaTime);
        }

    }

}