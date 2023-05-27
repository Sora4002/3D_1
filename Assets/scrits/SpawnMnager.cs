using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMnager : MonoBehaviour
{
    //面倒なのprivateは省略しています
    [SerializeField]GameObject obstaclePrefab;//障害物プレハブ
    Vector3 spawnPos = new Vector3(25,0,0);//スポーンする場所
    float elapsedTime;//経過時間
    PlayerController playerControllerScript;
    // Start is called before the first frame update
    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       elapsedTime += Time.deltaTime;//毎Fの時間を足していく
        //経過時間が２秒を超えかつゲームオーバーではない
        if (elapsedTime > 2.0f && !playerControllerScript.gameOver)
        {
         Instantiate(obstaclePrefab,spawnPos,obstaclePrefab.transform.rotation);
            elapsedTime = 0.0f;
        }
    }
}
