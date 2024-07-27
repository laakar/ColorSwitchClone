using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [Header("Player Properties")]
    [SerializeField] private float forceVal;
    [SerializeField] private Rigidbody2D _playerRb;
    
    [Header("Cam Properties")]
    public CinemachineVirtualCamera cam;
    private Transform _camTransform;
    public Transform disCheck;
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _camTransform = cam.transform;
        
        if (Input.GetButtonDown("Fire1") && !Manager.instance.lose)
        {
            _playerRb.velocity = new Vector2(_playerRb.velocity.x,  forceVal);  
        }
        
        if (_camTransform.position.y < gameObject.transform.position.y)
        {
            cam.transform.position = new Vector3(_camTransform.position.x, transform.position.y, _camTransform.position.z);
        }

        if (gameObject.transform.position.y < disCheck.transform.position.y)
        {
            Manager.instance.lose = true;
        }
    }
}
