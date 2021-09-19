using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _laserPrefab;

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
        if(Input.GetButtonDown("Fire1")) {
            Instantiate(_laserPrefab, transform.position, Quaternion.identity);
        }
        Vector3 convertedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if(convertedPos.x < _xMin) {

            convertedPos.x = _xMin;

        }

        if(convertedPos.x > _xMax) {

            convertedPos.x = _xMax;

        }

        transform.position = new Vector3(convertedPos.x, transform.position.y, 0);
    }

    void OnTriggerEnter2D(Collider2D collider) {

        

    }
}
