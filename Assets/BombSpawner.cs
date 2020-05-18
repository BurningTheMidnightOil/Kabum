using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    [SerializeField] float timeBetweenBombs = 1f;
    [SerializeField] float timeDecrease = 0.01f;
    [SerializeField] float timeLimit = 0.1f;
    [SerializeField] AudioSource audio;

    void Start()
    {
        StartCoroutine(SpawnBomb());
    }

    IEnumerator SpawnBomb (){
        while(true){
            yield return new WaitForSeconds(timeBetweenBombs);
            if(timeBetweenBombs > timeLimit) timeBetweenBombs -= timeDecrease;
            audio.Play();
            Instantiate(bomb, gameObject.transform.position, Quaternion.identity);
        }
    }
}
