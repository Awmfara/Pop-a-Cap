using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;

namespace Itemas
{
    public class ItemAvailability : MonoBehaviour
    {
        [Header("Playa Script")]
        [SerializeField, Tooltip("Attach to playaScript")]
        private Playa playa = null;

        [Header("Buttons")]
        [SerializeField, Tooltip("Attach to Button (On Click Functionality)")]
        private Button itemBut = null;
        [SerializeField, Tooltip("Attach to Button (Availability Functionality")]
        private GameObject nextItemBut = null;
        [Header("Price Variables")]
        [SerializeField, Tooltip("Attach to  itemBut/Price/costText Text")]
        private Text costText = null;
        [SerializeField, Tooltip("Attach to  itemSold/Price/Sold Text")]
        private Text soldText = null;
        [SerializeField, Tooltip("Attach to ItemSold Object")]
        private GameObject itemSold = null;
        [SerializeField, Tooltip("Cost of Meow Meow")]
        private int itemCost = 10;


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

            GenericItemScorerMeth();

        }
        /// <summary>
        /// Adds multiplier to score and Moolah
        /// Use for items without specific behaviors,
        /// For items with specific behaviors set multiplier to 0
        /// </summary>
        private void GenericItemScorerMeth()
        {
            if (currentTime <= 0)
            {
                playa.moolah += itemCount * multiplier;
                playa.scoreValue += itemCount * multiplier;
                currentTime = currentStartTime;
            }
            else
            {
                currentTime -= Time.deltaTime;
            }
        }

        /// <summary>
        /// Sets the Cost Number in Text to Item Cost,
        /// Changes Item Availability based on Moolah availability,
        /// After Item becomes first avaialble, sold out icon appears when out of Moolah
        /// </summary>
        private void ItemAvailMeth()
        {
            costText.text = "" + itemCost;
            soldText.text = "" + itemCost;

            if (playa.moolah >= itemCost)
            {
                nextItemBut.SetActive(true);
                itemSold.SetActive(true);
            }
            if (playa.moolah < itemCost)
            {
                nextItemBut.SetActive(false);
            }
        }
        /// <summary>
        /// Spends Moolah On Button press, Adds item count for Generic Items
        /// </summary>
        void ButPress()
        {
            playa.moolah -= itemCost;
            itemCount += 1;
        }
    }
}
