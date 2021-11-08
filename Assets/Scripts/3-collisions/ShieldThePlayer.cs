using System;
using System.Collections;
using UnityEngine;

public class ShieldThePlayer : MonoBehaviour {
    [Tooltip("The number of seconds that the shield remains active")] [SerializeField] float duration;
    private readonly int  ShieldPlayer = 2; //child 2 of player
    private static int _takeAnother; // for indicate if player take another shield
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Debug.Log("Shield triggered by player");
            var gameOver = other.GetComponent<GameOverOnTrigger2D>();
            
            var destroyComponent = other.GetComponent<DestroyOnTrigger2D>();
            if (destroyComponent) {
                destroyComponent.StartCoroutine(ShieldTemporarily(destroyComponent,gameOver));
                // NOTE: If you just call "StartCoroutine", then it will not work, 
                //       since the present object is destroyed!
                Destroy(gameObject);  // Destroy the shield itself - prevent double-use
            }
        } else {
            Debug.Log("Shield triggered by "+other.name);
        }
    }
    
    private IEnumerator ShieldTemporarily(DestroyOnTrigger2D destroyComponent, GameOverOnTrigger2D gameOver)
    {
        _takeAnother++;
        int stat = _takeAnother; //save current take
        destroyComponent.enabled = false;
        gameOver.enabled = false;
        Renderer[] renderers = destroyComponent.GetComponentsInChildren<Renderer>();
        renderers[ShieldPlayer].enabled = true;
        float fadeSub = 1 / duration; //faded in time duration.
        float fade =1;
        for (float i = duration; i > 0; i--)
        {
            renderers[ShieldPlayer].material.color = new Color(1, 1, 1, fade); //fade defines transparency
            fade -= fadeSub;
            Debug.Log("Shield: " + i + " seconds remaining!");
            yield return new WaitForSeconds(1);
            if (stat != _takeAnother) //if player take another jet
            {
                yield break;
            }
        }
        
        Debug.Log("Shield gone!");
        renderers[ShieldPlayer].enabled = false;
         destroyComponent.enabled = true;
         gameOver.enabled = true;
    }
}
