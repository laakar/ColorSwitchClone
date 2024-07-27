using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Transform circlePivot;
    [SerializeField] private float rotationSpeed;

    public bool left;

    private void Start()
    {
        if (!left)
        {
            rotationSpeed *= -1;
        }
    }

    void Update()
    {
        circlePivot.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
    }
}
