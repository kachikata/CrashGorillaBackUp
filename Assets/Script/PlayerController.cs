using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float jumpSpeed;
    private bool isJumping = false;

    const int DefaultLife = 3;
    public GameObject LOSE2PLabelObject;
    public GameObject WIN1PLabelObject;
    public GameObject RetryBottonObject;
    public GameObject TitleBottonObject;


    int life = DefaultLife;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //移動処理
    private void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal2");
        float moveV = Input.GetAxis("Vertical2");

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
            rb.velocity = Vector3.zero;
            //ライフを減らす
            life--;
            if (life == 0)
            {
                LOSE2PLabelObject.SetActive(true);
                WIN1PLabelObject.SetActive(true);


                //物理演算を止める
                GameObject.Find("player1").GetComponent<Rigidbody>().isKinematic = true;
                GameObject.Find("player2").GetComponent<Rigidbody>().isKinematic = true;


                RetryBottonObject.SetActive(true);
                TitleBottonObject.SetActive(true);



            }
        }

        //加速アイテムをとったとき速さを上げる処理
        else if (other.gameObject.CompareTag("Accel"))
        {
            other.gameObject.SetActive(false);
            speed = speed * 3;
            Invoke("Sd", 3);
        }
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
