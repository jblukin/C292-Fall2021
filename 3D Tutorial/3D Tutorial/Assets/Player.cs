using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] RuntimeData _runtimeData;
    float _mSense = 10f;

    float _friction = 3f;

    float _tilt = 0f;

    public Camera _camera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Aim();

        if (_runtimeData.currentState == GameplayState.FreeWalk)
        {

            Movement();

        }


    }

    void Aim()
    {

        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, mx * _mSense);

        _tilt -= my * _mSense;
        _tilt = Mathf.Clamp(_tilt, -90, 90);

        _camera.transform.localEulerAngles = new Vector3(_tilt, 0, 0);

    }

    void Movement()
    {

        Vector3 mH = transform.right * Input.GetAxis("Horizontal");
        Vector3 mV = transform.forward * Input.GetAxis("Vertical");

        Vector3 move = mH + mV;


        GetComponent<CharacterController>().Move(move * _friction * Time.deltaTime);

    }
}
