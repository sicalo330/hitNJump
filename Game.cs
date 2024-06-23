using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game obj;
    public int maxLives = 3;

    public bool gamePaused = false;
    public int score = 0;

    void Awake(){
        obj = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;  
        UIManager.obj.StartGame();  
    }

    public void addScore(int scoreGive){
        score += scoreGive;
    }

    public void gameOver(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
