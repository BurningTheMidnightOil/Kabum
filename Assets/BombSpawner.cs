using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    [SerializeField] float timeBetweenBombs = 1f;

    [SerializeField] AudioSource audio;
    void Start()
    {
        StartCoroutine(SpawnBomb());
    }

    IEnumerator SpawnBomb (){
        while(true){
            yield return new WaitForSeconds(timeBetweenBombs);
            audio.Play();
            Instantiate(bomb, gameObject.transform.position, Quaternion.identity);
        }
    }
}
