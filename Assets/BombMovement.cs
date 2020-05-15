using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 0.03f;
    [SerializeField] float limit = 0.1f;
    [SerializeField] Sprite explosion;
    [SerializeField] AudioSource audio;
    bool exploding = false;
    void Update()
    {
        if(ReachedEnd()){
            if(!exploding) {
                exploding = true;
                StartCoroutine(BombExplosion());
            }
        } else {
            gameObject.transform.position += new Vector3(0, -movementSpeed, 0);
        }
    }

    bool ReachedEnd(){
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.y = Mathf.Clamp01(pos.y);        
        return pos.y <= limit;
    }

    IEnumerator BombExplosion(){
        GameManager.Instance.LoseLife();
        GetComponent<SpriteRenderer>().sprite = explosion;
        audio.Play();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
