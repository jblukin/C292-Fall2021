using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{

    [SerializeField] GameObject _scoreText;

    [SerializeField] GameObject _gameOverText;
    int _score = 0;

    bool _isGameOver = false;

    public static GameState Instance;

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButtonDown("Submit") && _isGameOver) {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

    }

    void Awake() {

        Instance = this;

    }


    public void IncreaseScore(int amount) {

        _score += amount;
        _scoreText.GetComponent<Text>().text = "Score: " + _score;
    }

    public void InititateGameOver() {

        _isGameOver = true;
        _gameOverText.SetActive(true);


    }

}
