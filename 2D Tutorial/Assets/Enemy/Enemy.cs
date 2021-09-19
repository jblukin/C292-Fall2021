using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed = 1.25f;
    [SerializeField] GameObject _gameState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, Time.deltaTime * _speed, 0);
        
        if(transform.position.y < -5.15f) {

            GameState.Instance.InititateGameOver();
            Destroy(gameObject);

        }
    }

    void OnTriggerEnter2D(Collider2D collider) {

        if(collider.gameObject.name == "Laser(Clone)") {

            Destroy(gameObject);
            Destroy(collider.gameObject);
            GameState.Instance.IncreaseScore(10);

        }
        

        if(collider.gameObject.name == "Player") {

            GameState.Instance.InititateGameOver();
            Destroy(gameObject);
            Destroy(collider.gameObject);

        }

    }

}
