using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    [SerializeField] private GameObject orbPrefab;
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private float spawnYOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            SpawnOrb();
        }
    }

    public void SpawnOrb()
    {
        GameObject orb = Instantiate(orbPrefab);
        orb.transform.position = transform.position;
        orb.transform.GetComponent<OrbMovement>().SpawnMovement(spawnYOffset);
    }
}
