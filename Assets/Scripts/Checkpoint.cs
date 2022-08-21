using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private Scene sceneOne;
    private Scene sceneTwo;
    private Scene sceneThree;

    private Timer timer;
    private TimerLevel2 timerLevel2;

    private SavePoint sp;

    public bool dead;


    private void Start()
    {
        sceneOne = SceneManager.GetSceneByBuildIndex(2);
        sceneTwo = SceneManager.GetSceneByBuildIndex(4);
        sceneThree = SceneManager.GetSceneByBuildIndex(5);

        dead = false;
        sp = GameObject.FindGameObjectWithTag("SP").GetComponent<SavePoint>();
        if(sceneOne == SceneManager.GetActiveScene())
            timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        if (sceneTwo == SceneManager.GetActiveScene() || sceneThree == SceneManager.GetActiveScene())
            timerLevel2 = GameObject.FindGameObjectWithTag("TimerLevel2").GetComponent<TimerLevel2>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sp.lastCheckPointPos = transform.position;
            if (sceneOne == SceneManager.GetActiveScene())
                timer.lastTimerValue = timer.timeRemaining;
            if (sceneTwo == SceneManager.GetActiveScene() || sceneThree == SceneManager.GetActiveScene())
                timerLevel2.lastTimerValue = timerLevel2.timeRemaining;
            dead = false;
        }
    }
}
