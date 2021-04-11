using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip TrackCuerdo;
    public AudioClip TrackLoco;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCuerdo()
    {
        audioSource.clip = TrackCuerdo;
        audioSource.Play();
    }

    public void PlayLoco()
    {

        audioSource.clip = TrackLoco;
        audioSource.Play();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
