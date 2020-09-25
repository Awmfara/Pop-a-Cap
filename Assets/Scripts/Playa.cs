using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;



namespace Player
{
    [RequireComponent(typeof(AudioSource))]
    public class Playa : MonoBehaviour
    {

        [Header("Sam")]
        [SerializeField, Tooltip("Attach to Sam Button")]
        private Button sam = null;
      
        [SerializeField, Tooltip("Attach to First Coming Soon Object")]
        private GameObject firstComingSoon = null;


        [Header("Instructions")]


        [SerializeField, Tooltip("Instruction 1")]
        private GameObject earnMoreMullah = null;
        [SerializeField, Tooltip("Instruction 2")]
        private GameObject buyMoreMullah = null;
        [SerializeField, Tooltip("Instruction 3")]
        private GameObject makeMoreMullah = null;
        [SerializeField, Tooltip("Amount of Times Button is Counted TEST")]
        private int buttonPressCount = 0;



        [Header("Currency and Score")]
        [Tooltip("Moolah is Currenncy")] 
        public int moolah = 0;
        [SerializeField, Tooltip("Apply to Text in Counters/Moolah")]
        private Text moolahCounter=null;
        [Tooltip("Cumulative Score Value")]
        public int scoreValue = 0;
        [SerializeField, Tooltip("Apply to Text in Counters/Score")]
        private Text score=null;

        [Header("Sound FX")]

        [SerializeField, Tooltip("Attatch to Button Sound Source")]
        private AudioSource buttonSound=null;
        [SerializeField, Tooltip("Attatch to Sound when Face is Hit")]
        private AudioClip faceSound=null;
        [SerializeField, Tooltip("Volume of Button Sound")]
        private float volume = 0.5f;
        [SerializeField, Tooltip("Attatch to GameMusic Object")]
        private GameObject gameMusic = null;
        [SerializeField, Tooltip("Apply to Text in Counters/Score")]

        [Header("Kill Screen")]
        private GameObject killScreen = null;


        private void Start()
        {
            buttonPressCount = 0;
          
            sam.onClick.AddListener(butPress);

        }

        private void Update()
        {

            Instuctions();
            Counters();
            ExitIfEscape();
            ActivateKillScreen();

        }
        /// <summary>
        /// Displays Opening Instructions on Screen
        /// </summary>
        private void Instuctions()
        {
            if (scoreValue >= 15)
            {
                buyMoreMullah.SetActive(false);
                makeMoreMullah.SetActive(true);
            }
            if (scoreValue >= 20)
            {
                makeMoreMullah.SetActive(false);
            }
        }
        /// <summary>
        /// Quits Game if Escape is Pressed
        /// </summary>
        private static void ExitIfEscape()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
#if UNITY_EDITOR //allows function in Unity Editor Runtime to mimic application exit
                EditorApplication.ExitPlaymode();
#endif
                Application.Quit();
            }
        }

        /// <summary>
        /// Activates Kill Screen if Money Reaches One Million
        /// </summary>
        private void ActivateKillScreen()
        {
            if (moolah >= 1000000)
            {
                killScreen.SetActive(true);
            }
        }




        /// <summary>
        /// Displays Score and Mullah Amount 
        /// </summary>
        private void Counters()
        {
            score.text = "" + scoreValue;
            moolahCounter.text = "" + moolah;
        }
        /// <summary>
        /// Adds moolah score value and plays sound
        /// </summary>
        void butPress()
        {
            buttonPressCount++;
            moolah++;
            scoreValue++;
            buttonSound.PlayOneShot(faceSound, volume);

            //further instructions parameters based on button presses
            if (buttonPressCount == 1)
            {
                firstComingSoon.SetActive(true);
                gameMusic.SetActive(true);
                earnMoreMullah.SetActive(true);
            }
            if (buttonPressCount == 10)
            {
                earnMoreMullah.SetActive(false);
                buyMoreMullah.SetActive(true);
            }

        }

    }
}
