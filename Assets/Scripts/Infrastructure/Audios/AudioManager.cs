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

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
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