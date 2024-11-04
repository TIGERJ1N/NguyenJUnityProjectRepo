using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private InventoryItem item;
        public List<InventoryItem> inventory;

        void Start()
        {
            item = new InventoryItem();
            inventory = new List<InventoryItem>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}