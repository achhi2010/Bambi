using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Collision_Handler : MonoBehaviour
{
    [SerializeField] float LoadDelay;
    [SerializeField] ParticleSystem Explosion;
    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();

    }

    void StartCrashSequence()
    {
        Explosion.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Playercontrols>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadLevel", LoadDelay);
    }

    void ReloadLevel()
    {
        int Currentscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(Currentscene);
    } 
}

