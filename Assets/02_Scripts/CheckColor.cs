using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColor : MonoBehaviour
{
    public SpriteRenderer color;
    public Color objectColor;
    private void Start()
    {
        color = GetComponent<SpriteRenderer>();
        objectColor = color.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<SpriteRenderer>().color != color.color)
        {
            Manager.instance.lose = true;
        }
    }
}
