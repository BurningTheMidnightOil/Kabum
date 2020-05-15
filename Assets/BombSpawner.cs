using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    [SerializeField] float timeBetweenBombs = 1f;
    void Start()
    {
        StartCoroutine(SpawnBomb());
    }

    IEnumerator SpawnBomb (){
        while(true){
            yield return new WaitForSeconds(timeBetweenBombs);
            Instantiate(bomb, gameObject.transform.position, Quaternion.identity);
        }
    }
}
