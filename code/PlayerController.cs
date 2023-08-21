using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    Rigidbody2D rigid2D;
    float jumpForce = 340.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    
    void Start(){
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    void Update(){
        // 跳躍
        if(Input.GetKeyDown(KeyCode.Space)){
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
    }
}