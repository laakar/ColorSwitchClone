using System;
using System.Collections;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerateManager : MonoBehaviour
{
    public GameObject[] obstacleSets;
    public GameObject lastSet;
    public GameObject levelParent;
    public float offset;
    
    public Transform currentSpawnPosition;
    public Transform checkDis;

    private void Update()
    {
        if (lastSet != null)
        {
            if (lastSet.transform.position.y < checkDis.position.y)
            {
                Spawn();
            }
        }
    }
    void Spawn()
    {
        Debug.Log(offset);
        var selectedFloor = obstacleSets[Random.Range(0, obstacleSets.Length)];
        lastSet = Instantiate(selectedFloor, currentSpawnPosition.position, Quaternion.identity);
        currentSpawnPosition.position += new Vector3(0, offset, 0);
    }
}
