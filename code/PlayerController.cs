using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour{

    // 動畫
    Animator animator;

    // 物理
    Rigidbody2D rigid2D;
    float jumpForce = 680.0f;
    float walkForce = 6.0f;
    float maxWalkSpeed = 0.9f;
    // float threshold = 0.2f;

    void Start(){
        this.rigid2D = GetComponent<Rigidbody2D>(); // 物理
        this.animator = GetComponent<Animator>(); // 動畫
    }

    void Update(){
        // 跳躍
        if(Input.GetKey(KeyCode.Space) && this.rigid2D.velocity.y == 0){
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        // 左右移動
        int key = 0;
        if(Input.GetKey(KeyCode.RightArrow)) key = 1;
        if(Input.GetKey(KeyCode.LeftArrow)) key = -1;
        // 遊戲角色的速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // 速度限制
        if(speedx < this.maxWalkSpeed){
            this.rigid2D.AddForce(transform.right * key * this.walkForce); // 根據按鍵 * 相應正負(方向) * 給予力量
        }

        // 追加物體旋轉，因為有時候往左有時候往右，圖片不變的話會看起來很奇怪
        if(key != 0){
            transform.localScale = new Vector3(key,1,1); // 翻轉方式->往-x軸方向擴大
        }


        // 依角色變化改變動畫的速度
        this.animator.speed = speedx / 2.0f; // 動畫速度會是移動速度的0.5倍(real time with the current speed)

        // 依照遊戲角色速度改變動畫速度
        if(this.rigid2D.velocity.y == 0){
            this.animator.speed = speedx / 2.0f;
        } else {
            this.animator.speed = 1.0f;
        }


        // 跑出畫面時回到初始畫面
        if(transform.position.y < -10 ){
            SceneManager.LoadScene("GameScene");
        }
        
    }
    // 抵達終點
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("終點");
        SceneManager.LoadScene("ClearScene");
    }
}