using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChangeColor : MonoBehaviour
{
    public Color[] colors;
    public Color currentColor;
    public int customOffset;
    private void Start()
    {
        currentColor = colors[Random.Range(0, colors.Length)];
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<SpriteRenderer>().color = currentColor;
            gameObject.SetActive(false);   
        }
    }
}
