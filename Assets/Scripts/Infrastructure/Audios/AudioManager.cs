using UnityEngine;

namespace Infrastructure.Audios
{
    public class AudioManager : MonoBehaviour
    {
        private AudioSource audioSource;
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
    }
}