using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    Vector3 startPos;//リピートの開始位置
    float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;//ゲーム開始時の場所を記憶
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; 
        //背景のコライダーの長さの半分をピート幅にする
    }

    // Update is called once per frame
    void Update()
    {
        if(startPos.x - transform.position.x> repeatWidth) { 
        transform.position = startPos;//場所をリセット
        }
    }
}
