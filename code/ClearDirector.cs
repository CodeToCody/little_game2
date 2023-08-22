using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 使用loadscene必要的引用
public class ClearDirector : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene("GameScene");
        }
    }
}
