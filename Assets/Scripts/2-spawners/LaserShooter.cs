using System;
using System.Collections;
using UnityEngine;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the "scoreText" field of the new laser.
 */
public class LaserShooter: KeyboardSpawner {
    [SerializeField] NumberField scoreField;
    [SerializeField] float timeBetweenShoot = 0.5f;
    private Boolean shotDelay = true; //to check if not passed time Between Shoot 
    
    protected override GameObject spawnObject() {
        GameObject newObject = base.spawnObject();  // base = super

        // Modify the text field of the new object.
        ScoreAdder newObjectScoreAdder = newObject.GetComponent<ScoreAdder>();
        if (newObjectScoreAdder)
            newObjectScoreAdder.SetScoreField(scoreField);

        return newObject;
    }

    private  void Update() {
        if (Input.GetKeyDown(keyToPress)&&shotDelay)
        {
            this.StartCoroutine(ShotDelay());    
        }
    }
    private IEnumerator ShotDelay() {  //delay shooting laser 
            shotDelay = false;  //to not call function in time Between Shooting
            spawnObject();
            yield return new WaitForSeconds(timeBetweenShoot); 
            shotDelay = true;
    }
    
}
