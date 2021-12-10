using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    float _rSpeed = 180f;

    [SerializeField] RuntimeData _runtimeData;

    [SerializeField] GameObject _quiz;

    void OnMouseEnter()
    {

        transform.Find("Spot Light").gameObject.SetActive(true);
        _runtimeData.currentFood = name;

    }

    void OnMouseOver()
    {

        transform.Find("FoodMesh").RotateAround(transform.position, Vector3.up, _rSpeed * Time.deltaTime);

    }

    void OnMouseExit()
    {

        transform.Find("Spot Light").gameObject.SetActive(false);
        _runtimeData.currentFood = "";

    }

    void OnMouseDown()
    {
        if (_runtimeData.currentState == GameplayState.FreeWalk)
        {

            _quiz.GetComponent<Quiz>().Selected(gameObject);

            _runtimeData.currentFood = "";

        }


    }

}
