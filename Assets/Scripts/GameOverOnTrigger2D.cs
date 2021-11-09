using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger game over")]
    [SerializeField] string triggeringTag;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && enabled) {
            Debug.Log("Game over!");
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
            //Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    private void Update() {
        /* Just to show the enabled checkbox in Editor */
    }

}
