using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerContllor : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float GravityModifier;
    [SerializeField] float jumpForce;
    [SerializeField] bool is0nGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics. gravity *= GravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーが押されて、かつ、地面にいたら
        if (Input.GetKeyDown(KeyCode.Space) && is0nGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode. Impulse );
            is0nGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
          is0nGround = true;
        }
    }
}
