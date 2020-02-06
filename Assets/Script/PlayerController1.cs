using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController1 : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float jumpSpeed;
    private bool isJumping = false;
    const int DefaultLife = 3;

    public GameObject WIN2PLabelObject;
    public GameObject LOSE1PLabelObject;
    public GameObject RetryBottonObject;
    public GameObject TitleBottonObject;


    int life = DefaultLife;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //移動処理
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal1");
        float moveV = Input.GetAxis("Vertical1");

        Vector3 move = new Vector3(moveH, 0, moveV);
        rb.AddForce(move * speed);

        //ジャンプ処理
        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.velocity = Vector3.up * jumpSpeed;
            isJumping = true;
        }
    }

    //床についたらジャンプができるようになる処理
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        //落下判定処理
        if (other.gameObject.CompareTag("Bottom"))
        {
            //速さを0にする
            rb.velocity = Vector3.zero;

            //ライフを減らす
            life--;

            //ライフが0になったとき
            if(life == 0)
            {
                WIN2PLabelObject.SetActive(true);
                LOSE1PLabelObject.SetActive(true);

                //物理演算を止める
                GameObject.Find("player1").GetComponent<Rigidbody>().isKinematic = true;
                GameObject.Find("player2").GetComponent<Rigidbody>().isKinematic = true;

                //ボタンを出す
                RetryBottonObject.SetActive(true);
                TitleBottonObject.SetActive(true);
            }
            
        }
        
        //加速アイテムをとったとき速さを上げる処理
        else if (other.gameObject.CompareTag("Accel"))
        {
            other.gameObject.SetActive(false);
            speed = speed * 3;
            Invoke("Sd", 5);
        }
        //巨大化アイテムをとったとき
        else if (other.gameObject.CompareTag("Item"))
        {
            rb.mass = 100;
            Invoke("Md", 5);
        }
    }
    //速さを元に戻す
    void Sd()
    {
        speed = speed / 3;
        GameObject.Find("AccelItem222").transform.Find("AccelItem").gameObject.SetActive(true);
    }

    void Md()
    {
        rb.mass = 50;
    }

    public int Life()
    {
        return life;
    }
}
