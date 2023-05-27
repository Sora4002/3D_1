using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float GravityModifier;
    [SerializeField] float jumpForce;
    [SerializeField] bool is0nGround;
    public bool gameOver;
    Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics. gravity *= GravityModifier;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーが押されて、かつ、地面にいたらかつ、ゲームオーバーでないならば
        if (Input.GetKeyDown(KeyCode.Space) && is0nGround　&& !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode. Impulse );
            is0nGround = false;//ジャンプした＝地面にいない
            playerAnim.SetTrigger("Jump_trig");//ジャンプアニメ発動準備
        }
    }
    //衝突が起きたら実行
    private void OnCollisionEnter(Collision collision) 
        { 
        if (collision.gameObject.CompareTag("Ground")) 
            { 
            //ぶつかった相手、（collision)のタグがGroundなら
            is0nGround = true;//地面がついている状態に変更
            }
        if (collision.gameObject.CompareTag("Obstacle"))
            { 
            gameOver = true;//ゲームオーバーにする
            playerAnim.SetBool("Death_b",true);//ここで死亡状態ｂにする
            playerAnim.SetInteger("DeathType_int",2);//intrigerは整数の意味。
        }
    }
}
