using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    //ToDo:Add BounceFromSunbed?
  //  GameObject player;

    public static int points;
    [SerializeField] AudioSource beepAudioSource;

    void Start()
    {
        ChildrenSetActive(false);
       // player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (GameOverHandler.isGameOver)
        { 
            beepAudioSource.Stop();
        }
    }

    void ChildrenSetActive(bool _isActive)
    {
        for (int a = 0; a < transform.childCount; a++)
        {
            transform.GetChild(a).gameObject.SetActive(_isActive);
        }
    }


    /*1.
     * How do you make a beeping noise when close to enemy? 
     * And how do you make it repeat faster the closer it is?
     * Check the distance between the two GameObjects
2. Add a sound source to the camera (you could make it looping on the component itself or via code)
3. Upon the distance going below a value trigger the sound source (your beeping) to play
4. Use the distance value to set the audio source pitch (w$$anonymous$$ch w$$anonymous$$ch change
    the pitch & playback speed of your sound effect, I'm not sure how to just change the tempo so the pitch 
    is the same)*/
  

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            points = Random.Range(50, 300);
            float delay = 0.5f;            
            StartCoroutine(StartLootPickingRoutine(delay));           
        }
    }

    IEnumerator StartLootPickingRoutine(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        ChildrenSetActive(true);
    }
}
