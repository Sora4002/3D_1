using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft: MonoBehaviour
{
    [SerializeField] float speed = 30;
    PlayerController playerContllerScript;
    float leftBound = -15;
    // Start is called before the first frame update

    private void Start()
    {
        playerContllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //まず左辺は頭で宣言しただけなので、実感が不明
        //そこで代入が必要
        //PlayerControllerを持っているのは、player本人なのでまず見つける(find)する必要がある
        //それがGameObjectFindですただしFindの引数には、「一文字、一句」同じ名前を入れる必要があります
        //なので("Play")とかだとバグる
        //GameObject.Find("Play")がプレイヤー自身を表していると思いましょう
        //そうするとそいつが持っているPlayerControllerが欲しい
        //それは、GameComppnet<型名>（）という方法で取っています
    }

    // Update is called once per frame
    void Update()
    {
        if (playerContllerScript.gameOver == false) 
        { 
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
