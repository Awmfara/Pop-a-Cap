using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Affects Visuals from Buttons, Toggles Animators and Instantiates Objects. Also Triggers Coming Soon Graphics
/// </summary>

namespace ButtonsFX
{
    public class ButtonVisualEffects : MonoBehaviour
    {

        #region Animators
        [Header("Animators")]
        [SerializeField, Tooltip("Attach to Sam Button")]
        public Animator samFace=null;
        [SerializeField, Tooltip("Attach to MainCanvas")]
        public Animator canvasShake=null;
        [SerializeField, Tooltip("Attach to Main Camera")]
        public Animator cameraChange=null;
        #endregion
        #region Prefabs
        [Header("Prefabs")]
       [SerializeField, Tooltip("Attach to catAttack prefab")]
        public GameObject catAttack=null;
        [SerializeField, Tooltip("Attach to bagAttack prefab")]
        public GameObject bagAttack=null;
        [SerializeField, Tooltip("Attach to smackAttack prefab")]
        public GameObject smackAttack=null;
        [SerializeField, Tooltip("Attach to cloudAttack prefab")]
        public GameObject cloudAttack=null;
        [SerializeField, Tooltip("Attach to dontFeelSoHot prefab")]
        public GameObject dontFeelSoHot=null;
        #endregion

        #region Buttons
        [Header("Buttons")]
        [SerializeField, Tooltip("Attach to Wine Button")]
        private Button wine = null;
        [SerializeField, Tooltip("Attach to Mushroom Button")]
        private Button mushroom = null;
        [SerializeField, Tooltip("Attach to Cat Button")]
        private Button cat = null;
        [SerializeField, Tooltip("Attach to Bag Button")]
        private Button bag = null;
        [SerializeField, Tooltip("Attach to Smack Button")]
        private Button smack = null;
        [SerializeField, Tooltip("Attach to Spoon Button")]
        private Button spoon = null;
        [SerializeField, Tooltip("Attach to Storm Button")]
        private Button storm = null;
        [SerializeField, Tooltip("Attach to Eyes Button")]
        private Button eyes = null;
        #endregion

        [Header("Coming Soon's")]
        [SerializeField, Tooltip("Attach to Coming Soon Objects In Order of Items, Set Index to Amount Of Items")]
        private GameObject[] ComingSoon=null;
        public int firsttime = 1;

        /// <summary>
        /// Adds Button Listeners to Item Buttons
        /// </summary>
        private void Start()
        {
            wine.onClick.AddListener(WinePress);
            mushroom.onClick.AddListener(MushroomPress);
            cat.onClick.AddListener(CatPress);
            bag.onClick.AddListener(BagPress);
            smack.onClick.AddListener(SmackPress);
            spoon.onClick.AddListener(SpoonPress);
            storm.onClick.AddListener(StormPress);
            eyes.onClick.AddListener(EyePress);
            firsttime = 1;

        }
        /// <summary>
        /// Sets Animators and next Coming Soon
        /// </summary>
        void WinePress()
        {
            samFace.SetBool("isSmack", false);
            samFace.SetBool("isDrunk", true);
            samFace.SetBool("isMush", false);
            samFace.SetBool("isWire", false);
            samFace.SetBool("isSpoon", false);
            samFace.SetBool("isStorm", false);
            samFace.SetBool("isCat", false);

            samFace.SetBool("isKill", false);
            cameraChange.SetBool("cameraKill", false);
            canvasShake.SetBool("canvasKill", false);

            if (firsttime <= 1)
            {
                ComingSoon[1].SetActive(true);
                firsttime = 2;
            }

        }
        /// <summary>
        /// Sets Animators and next Coming Soon
        /// </summary>
        void MushroomPress()
        {
            samFace.SetBool("isWire", false);
            samFace.SetBool("isDrunk", false);
            samFace.SetBool("isMush", true);
            samFace.SetBool("isSmack", false);
            samFace.SetBool("isSpoon", false);
            samFace.SetBool("isStorm", false);
            samFace.SetBool("isCat", false);


            samFace.SetBool("isKill", false);
            cameraChange.SetBool("cameraKill", false);
            canvasShake.SetBool("canvasKill", false);

            if (firsttime <= 2)
            {
                ComingSoon[1] = null;
                ComingSoon[2].SetActive(true);
                firsttime = 3;
            }

        }
        /// <summary>
        /// Sets Animators and next Coming Soon, Launches Cat Attack
        /// </summary>
        void CatPress()
        {
            Instantiate(catAttack, new Vector3(-8, -0.75f), Quaternion.identity);
            samFace.SetBool("isSpoon", false);
            samFace.SetBool("isSmack", false);
            samFace.SetBool("isWire", false);
            samFace.SetBool("isDrunk", false);
            samFace.SetBool("isMush", false);
            samFace.SetBool("isStorm", false);
            samFace.SetBool("isCat", true);

            samFace.SetBool("isKill", false);
            cameraChange.SetBool("cameraKill", false);
            canvasShake.SetBool("canvasKill", false);


            if (firsttime <= 3)
            {
                ComingSoon[2] = null;
                ComingSoon[3].SetActive(true);
                firsttime = 4;
            }
        }
        /// <summary>
        /// Sets Animators and next Coming Soon, Launches Bag Attack
        /// </summary>
        void BagPress()
        {
            Instantiate(bagAttack, new Vector3(0, 8), Quaternion.identity);
            samFace.SetBool("isWire", true);
            samFace.SetBool("isMush", false);
            samFace.SetBool("isDrunk", false);
            samFace.SetBool("isSpoon", false);
            samFace.SetBool("isSmack", false);
            samFace.SetBool("isStorm", false);
            samFace.SetBool("isCat", false);

            samFace.SetBool("isKill", false);
            cameraChange.SetBool("cameraKill", false);
            canvasShake.SetBool("canvasKill", false);

            if (firsttime <= 4)
            {
                ComingSoon[3] = null;
                ComingSoon[4].SetActive(true);
                firsttime = 5;
            }
        }
        /// <summary>
        /// Sets Animators and next Coming Soon, Launches Smack Attack
        /// </summary>
        void SmackPress()
        {
            samFace.SetBool("isSmack", true);
            samFace.SetBool("isWire", false);
            samFace.SetBool("isSpoon", false);
            samFace.SetBool("isDrunk", false);
            samFace.SetBool("isMush", false);
            samFace.SetBool("isStorm", false);
            samFace.SetBool("isCat", false);

            samFace.SetBool("isKill", false);
            cameraChange.SetBool("cameraKill", false);
            canvasShake.SetBool("canvasKill", false);

            Instantiate(smackAttack, new Vector3(0, 8), Quaternion.identity);

            if (firsttime <= 5)
            {
                ComingSoon[4] = null;
                ComingSoon[5].SetActive(true);
                firsttime = 6;
            }
        }
        /// <summary>
        /// Sets Animators and next Coming Soon
        /// </summary>
        void SpoonPress()
        {
            samFace.SetBool("isSpoon", true);
            samFace.SetBool("isSmack", false);
            samFace.SetBool("isWire", false);
            samFace.SetBool("isDrunk", false);
            samFace.SetBool("isMush", false);
            samFace.SetBool("isStorm", false);
            samFace.SetBool("isCat", false);

            samFace.SetBool("isKill", false);
            cameraChange.SetBool("cameraKill", false);
            canvasShake.SetBool("canvasKill", false);


            if (firsttime <= 6)
            {
                ComingSoon[5] = null;
                ComingSoon[6].SetActive(true);
                firsttime = 7;
            }
        }
        /// <summary>
        /// Sets Animators and next Coming Soon
        /// </summary>
        void StormPress()
        {
            cameraChange.SetTrigger("lightning");
            canvasShake.SetTrigger("shaker");
            samFace.SetTrigger("isStorm");
            samFace.SetBool("isSpoon", false);
            samFace.SetBool("isSmack", false);
            samFace.SetBool("isWire", false);
            samFace.SetBool("isDrunk", false);
            samFace.SetBool("isMush", false);
            samFace.SetBool("isCat", false);

            samFace.SetBool("isKill", false);
            cameraChange.SetBool("cameraKill", false);
            canvasShake.SetBool("canvasKill", false);

            Instantiate(cloudAttack, new Vector3(0, 26), Quaternion.identity);

            if (firsttime <= 7)
            {
                ComingSoon[6] = null;
                ComingSoon[7].SetActive(true);
                firsttime = 8;
            }
        }
        void EyePress()
        /// <summary>
        /// Sets Animators and next Coming Soon, Launches Dont Feel So Hot
        /// </summary>
        {


            samFace.SetBool("isSpoon", false);
            samFace.SetBool("isSmack", false);
            samFace.SetBool("isWire", false);
            samFace.SetBool("isDrunk", false);
            samFace.SetBool("isMush", false);
            samFace.SetBool("isCat", false);

            samFace.SetBool("isKill", true);
            cameraChange.SetBool("cameraKill", true);
            canvasShake.SetBool("canvasKill", true);
            Instantiate(dontFeelSoHot);

        }
    }
}
