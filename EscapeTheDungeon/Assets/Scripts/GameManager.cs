using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool isGameOver = false;
    
    public void GameOver(){
        isGameOver = true;

    }

    void Update()
    {
        if(isGameOver == true){
            SceneManager.LoadScene("GameOver");
        }

        if(SceneManager.GetActiveScene().name == "GameOver" && Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("MainScene");
        }

    }
}
