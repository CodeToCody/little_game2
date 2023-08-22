using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour{
    GameObject player;

    void Start(){
        this.player = GameObject.Find("cat"); // player represent the "cat" object
    }
    void Update(){
        Vector3 playerPos = this.player.transform.position; // player 中 transform 裡面的 position 方法 
        transform.position = new Vector3(transform.position.x,playerPos.y,transform.position.z);
    }
}
