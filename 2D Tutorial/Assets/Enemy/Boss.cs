using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] float _speed = 1.0f;
    [SerializeField] GameObject _gameState;
    [SerializeField] GameObject _enemyPrefab;

    int _bossHP = 3;
	float _xMin;
	float _xMax;

    // Start is called before the first frame update
    void Start()
    {
    	_xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
    	_xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, Time.deltaTime * _speed, 0);
		
		if(transform.position.y < -5.25f) {

			GameState.Instance.InititateGameOver();
			Destroy(gameObject);

		}
    }

    void spawn(float leftX, float rightX, float behindY) {

        Instantiate(_enemyPrefab, new Vector3(leftX, behindY, 0), Quaternion.identity);
        Instantiate(_enemyPrefab, new Vector3(rightX, behindY, 0), Quaternion.identity);

    }

    void OnTriggerEnter2D(Collider2D collider) {

		float xLeft = transform.position.x - 1.0f;
        float xRight =  transform.position.x + 1.0f;
	
		if(collider.gameObject.name == "Laser(Clone)") {

        	_bossHP--;
			Destroy(collider.gameObject);

		}
        
        if (_bossHP == 0) {

            if(xLeft < _xMin) {

               xLeft = _xMin;

            }

            if(xRight > _xMax) {

                xRight = _xMax;

            }

            GameState.Instance.IncreaseScore(30);
            spawn(xLeft, xRight, (transform.position.y + 3.25f));
            Destroy(gameObject);


        }
        
        if(collider.gameObject.name == "Player") {

            GameState.Instance.InititateGameOver();
			Destroy(collider.gameObject);
			Destroy(gameObject);

        }
        
    }

}