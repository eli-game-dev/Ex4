using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddJetPlayer : MonoBehaviour
{
    [Tooltip("The number of seconds that the shield remains active")] [SerializeField] float duration;
    [Tooltip("New speed of jet, for duration time")] [SerializeField] float newSpeed;
    private readonly int  JetPlayer = 3; //child 3 of player
    private static int _takeAnother; // for indicate if player take another jet

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Debug.Log("add Jet to player");
            var destroyComponent = other.GetComponent<DestroyOnTrigger2D>();
            if (destroyComponent) {
                destroyComponent.StartCoroutine(JetTemporarily(destroyComponent, other));
                // NOTE: If you just call "StartCoroutine", then it will not work, 
                //       since the present object is destroyed!
                Destroy(gameObject);  // Destroy the shield itself - prevent double-use
            }
        } else {
            Debug.Log("Jet triggered by "+other.name);
        }
    }
    private IEnumerator JetTemporarily(DestroyOnTrigger2D destroyComponent, Collider2D other) {
        _takeAnother++;
        int stat = _takeAnother; //save current take
        //first implement like this to get player KeyboardMover  https://answers.unity.com/questions/650983/how-to-get-variable-from-another-object.html
       // GameObject go = GameObject.Find("PlayerSpaceship");
        KeyboardMover km = other.GetComponent<KeyboardMover>();
        float oldSpeed = km.getSpeed();
        km.SetSpeed(newSpeed);
        
        Renderer[] renderers = destroyComponent.GetComponentsInChildren<Renderer>(); // return Renderer child
        renderers[JetPlayer].enabled = true;
        for (float i = duration; i > 0; i--)
        {
            Debug.Log("Jet: " + i + " seconds remaining!");
            yield return new WaitForSeconds(1);
            if (stat != _takeAnother) //if player take another jet
            {
                yield break;
            }
        }
        Debug.Log("Jet gone!");
 
        renderers[JetPlayer].enabled = false;
        km.SetSpeed(oldSpeed);
    }
}
