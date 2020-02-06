using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChange : MonoBehaviour
{
    // 大きさをInspector上で自由に設定できるようにする
    public Vector3 scale;
    

    private void OnTriggerEnter(Collider player)
    {
        //player1が触れたとき
        if (player.gameObject.tag == "player1")
        {
            //アイテムを消す
            GameObject.Find("Item").SetActive(false);

            //player1を大きくする
            GameObject.Find("player1").transform.localScale = new Vector3(8f, 8f, 8f);

            //一定時間後にp1smallメソッドが走る
            Invoke("p1small", 5f);
        }

        else if (player.gameObject.tag == "player2")
        {
            GameObject.Find("Item").SetActive(false);

            GameObject.Find("player2").transform.localScale = new Vector3(8f, 8f, 8f);

            Invoke("p2small", 5f);

        }
    }

    void p1small()
    {
        //player1を小さくする
        GameObject.Find("player1").transform.localScale = new Vector3(5f, 5f, 5f);
        //Itemを親オブジェクトを参照してリスポーンさせる
        GameObject.Find("Item222").transform.Find("Item").gameObject.SetActive(true);
    }

    void p2small()
    {

        GameObject.Find("player2").transform.localScale = new Vector3(5f, 5f, 5f);
        GameObject.Find("Item222").transform.Find("Item").gameObject.SetActive(true);
    }

}
