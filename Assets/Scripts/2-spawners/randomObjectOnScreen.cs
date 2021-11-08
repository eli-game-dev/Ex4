using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomObjectOnScreen : MonoBehaviour
{
    [Tooltip("The number of seconds that the object remains on screen")] [SerializeField] float durationOnScreen;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 3f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns = 10f;
    [SerializeField] GameObject prefabToSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        this.StartCoroutine(SpawnRoutine());
        Debug.Log("Start finished");
    }

    private IEnumerator SpawnRoutine() {
        float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
        yield return new WaitForSeconds(timeBetweenSpawns); //wait in the first time
        while (true)
        {
             timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            //random point https://forum.unity.com/threads/instantiating-gameobjects-at-random-screen-positions.417205/
            Vector2 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, randomPositionOnScreen, Quaternion.identity);
           // destroy with timer https://answers.unity.com/questions/809440/how-do-i-destroy-a-spawned-object-2.html
            Destroy(newObject,durationOnScreen);
            yield return new WaitForSeconds(timeBetweenSpawns);
            
        }
    }
}
