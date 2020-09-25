using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;
//Defines when an item becomes available and adds money and scores

namespace Itemas
{
    public class ItemAvailability : MonoBehaviour
    {
        [Header("Playa Script")]
        [SerializeField, Tooltip("Attach to playaScript")]
        private Playa playa = null;

        [Header("Buttons")]
        public bool itemActivated = false;
        [SerializeField,Tooltip("Attatch to Coming Soon Scribble")]
        private GameObject comingsoon = null;
        
        [SerializeField, Tooltip("Attach to Button (On Click Functionality)")]
        private Button itemBut = null;
        [SerializeField, Tooltip("Attach to Button (Availability Functionality")]
        private GameObject nextItemBut = null;
        [Header("Price Variables")]
        [SerializeField, Tooltip("Attach to  itemBut/Price/costText Text")]
        private Text costText = null;
        [SerializeField, Tooltip("Attach to  itemSold/Price/Sold Text")]
        private Text soldText = null;
        [SerializeField, Tooltip("Attach to  itemSold/Price/Sold Text")]
        private Text comingSoonText = null;
        [SerializeField, Tooltip("Attach to ItemSold Object")]
        private GameObject itemSold=null;
        
        [SerializeField, Tooltip("Cost of Meow Meow")]
        private int itemCost = 10;

        [Header("Sound Effects")]
        [SerializeField, Tooltip("Volume that Sounds when Button Hit")]
        private float buttonVolume = 0.5f;
        [SerializeField, Tooltip("Attach to ButtonSound Source")]
        private AudioSource buttonSound=null;
        [SerializeField, Tooltip("The Sound that is Triggered")]
        private AudioClip itemSound=null;
        [SerializeField, Tooltip("Volume that Sounds when Coin is Added")]
        private AudioSource coinSoundBut=null;
        [SerializeField, Tooltip("Attach to coinSound Source")]
        private AudioClip coinSound=null;
        [SerializeField, Tooltip("The Sound that is Triggered")]
        private float coinSoundVolume=2f;

     
  


        [Header("Settings for Generic Items")]

        [SerializeField,Tooltip("Amount of Item that exists")]
        private int itemCount = 0;
        [SerializeField, Tooltip("Score Multiplies By(Generic Option, Set to 0 if other behavior defined")]
        private int multiplier = 0;
        [SerializeField,Tooltip("Don't change watch countdown")]
        private float currentTime = 5;
        [SerializeField, Tooltip("Time between clicks that item repeats")]
        private float currentStartTime = 10;

        private void Start()
        {
            itemBut.onClick.AddListener(ButPress);
        
        }
        private void Update()
        {
            ItemAvailMeth();

            
           //after item is activated, destorys coming soon and launches Scorer
            if (itemActivated==true)
            {
                Destroy(comingsoon);
                comingsoon = null;
                GenericItemScorerMeth();
            }

        }
        /// <summary>
        /// Adds multiplier to score and Moolah
        /// Use for items without specific behaviors,
        /// For items with specific behaviors set multiplier to 0
        /// </summary>
        private void GenericItemScorerMeth()
        {
            if (itemCount>=1)
            {
                if (currentTime <= 0)
                {

                    playa.moolah += itemCount * multiplier;
                    playa.scoreValue += itemCount * multiplier;
                    currentTime = currentStartTime;
                    coinSoundBut.PlayOneShot(coinSound, coinSoundVolume);
                }
                else
                {
                    currentTime -= Time.deltaTime;
                }
            }
       
        }

        /// <summary>
        /// Sets the Cost Number in Text to Item Cost,
        /// Changes Item Availability based on Moolah availability,
        /// After Item becomes first avaialble, sold out icon appears when out of Moolah
        /// </summary>
        private void ItemAvailMeth()
        {
            comingSoonText.text = "" + itemCost;
            costText.text = "" + itemCost;
            soldText.text = "" + itemCost;


      
            if (playa.moolah < itemCost && itemActivated==true)
            {
                nextItemBut.SetActive(false);
                itemSold.SetActive(true);

            }
            if (playa.moolah >= itemCost)
            {

                nextItemBut.SetActive(true);
                itemSold.SetActive(false);
                itemActivated = true;

            }
        }
        /// <summary>
        /// Spends Moolah On Button press, Adds item count for Generic Items
        /// </summary>
        void ButPress()
        {
            buttonSound.PlayOneShot(itemSound, buttonVolume);
            playa.moolah -= itemCost;
            itemCount += 1;
        }
    }
}
