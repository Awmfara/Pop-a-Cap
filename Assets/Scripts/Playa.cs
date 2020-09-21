using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Itemas;

namespace Player
{
    [RequireComponent(typeof(AudioSource))]
    public class Playa : MonoBehaviour
    {

        [Header("Sam")]
        public Button sam;

        [SerializeField, Tooltip("Currency")]
        public int moolah = 0;
        public Text moolahCounter;
        public int scoreValue = 0;
        public Text score;

        [Header("Sound FX")]
        public AudioSource buttonSound;
        public AudioClip faceSound;
        public float volume = 0.5f;




        private void Start()
        {
            sam.onClick.AddListener(butPress);

        }

        private void Update()
        {

            Counters();

        }


        /// <summary>
        /// Displays Score and Mullah Amount 
        /// </summary>
        private void Counters()
        {
            score.text = "" + scoreValue;
            moolahCounter.text = "" + moolah;
        }
        void butPress()
        {
            moolah++;
            scoreValue++;
            buttonSound.PlayOneShot(faceSound, volume);

        }

    }
}
