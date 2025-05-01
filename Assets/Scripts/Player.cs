using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; set; }

    private int _hp;
    public float speed = 5f;
    [SerializeField] private float pushForce = 1200f;
    [HideInInspector] public bool isNoteOpened = false;
    [SerializeField] private TextMeshProUGUI healthAmountText;
    [SerializeField] private FixedJoystick joystick;
    private Animator anim;
    private Rigidbody _rb;

    private void Awake()
    {
        Instance = this;
        _hp = 5;
        healthAmountText.text = _hp.ToString();
        anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        if (!isNoteOpened)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal") + joystick.Horizontal;
            float verticalInput = Input.GetAxisRaw("Vertical") + joystick.Vertical;

            Vector3 input = new Vector3(horizontalInput, 0, verticalInput).normalized;
            _rb.velocity = new Vector3(input.x * speed,_rb.velocity.y, input.z * speed);


            if (Mathf.Abs(transform.position.x) >= 12f)
                transform.position += new Vector3(-Mathf.Sign(transform.position.x) * pushForce * Time.deltaTime, 0, 0);

            else if (Mathf.Abs(transform.position.z) >= 12f)
                transform.position += new Vector3(0, 0, -Mathf.Sign(transform.position.z) * pushForce * Time.deltaTime);


            if (_rb.velocity.magnitude > 0.1f)
            {
                transform.rotation = Quaternion.LookRotation(_rb.velocity);
                anim.SetBool("isRunning", true);
            }
            else
                anim.SetBool("isRunning", false);
        }
        else
        {
            _rb.velocity = Vector3.zero;
            anim.SetBool("isRunning", false);
        }
    }

    [SerializeField] private GameObject gameOverMenu;
    public void GetDamage()
    {
        _hp--;
        Debug.Log("Осталось " + _hp + " жизней");
        healthAmountText.text = _hp.ToString();
        if (_hp < 1)
        {
            Debug.Log("Game Over");
            gameOverMenu.SetActive(true);
            Destroy(gameObject);
        }
    }
}