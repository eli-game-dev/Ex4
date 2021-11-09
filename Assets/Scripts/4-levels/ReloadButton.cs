using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadButton : MonoBehaviour
{
    
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnMouseUp);
    }
    
    void OnMouseUp()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }


}
