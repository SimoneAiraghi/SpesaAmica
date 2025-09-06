using System;
using System.Collections;
using System.Collections.Generic;
using Cassa.Script;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public GameObject notifyWindow;
    public Money wallet;
    public Kcal kcal;
    public static event Action<List<InventoryItem>> OnInventoryChange;

    public AudioClip removeSound;
	private AudioSource audioSource;
    
    public List<InventoryItem> inventory = new List<InventoryItem>();
    public Dictionary<ItemData, InventoryItem> itemDictionary = new Dictionary<ItemData, InventoryItem>();

    //gestione del pulsante 
    public int selectedItemsCount = 0;

    private void Awake()
    { 
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void OnEnable()
    {
        Item.onItemCollected += Add;
        InventorySlot.onItemRemoved += Remove;
    }

    public void OnDisable()
    {
        Item.onItemCollected -= Add;
        InventorySlot.onItemRemoved -= Remove;
    }

    public void Add(ItemData itemData)
    { 
        InventoryItem newItem = new InventoryItem(itemData);
        itemDictionary.TryGetValue(itemData, out InventoryItem item);
        
        //Check if the item is already in the inventory otherwise show the NotifyWindow
        if (item == null)
        {

            //Check if the inventory is already full otherwise show the NotifyWindow
            if (inventory.Count < 5 && wallet != null)
            {
                if (wallet.GetMoney() < itemData.cost && notifyWindow != null)
                {
                    GameObject textobj = notifyWindow.transform.GetChild (0).gameObject;
                    TextMeshProUGUI mytext = textobj.GetComponent<TextMeshProUGUI>();
                    mytext.text = "You don't have enough money";
                    notifyWindow.SetActive(true);
                }
                else
                {
                    itemDictionary.Add(itemData, newItem);
                    wallet.DecreaseMoney(itemData.cost);
                    kcal.IncreaseKcal(itemData.kcal);
                    inventory.Add(newItem);
                    selectedItemsCount++; 
                    OnInventoryChange?.Invoke(inventory);
                }
            }  
            else
            {
                if (notifyWindow != null)
                {
                    GameObject textobj = notifyWindow.transform.GetChild (0).gameObject;
                    TextMeshProUGUI mytext = textobj.GetComponent<TextMeshProUGUI>();
                    mytext.text = "Shopping Cart is already full";
                    notifyWindow.SetActive(true);
                }
            }
        }
        else
        {
            if (notifyWindow != null)
            {
                GameObject textobj = notifyWindow.transform.GetChild (0).gameObject;
                TextMeshProUGUI mytext = textobj.GetComponent<TextMeshProUGUI>();
                mytext.text = "You have already add this item";
                notifyWindow.SetActive(true);
            }
        }

    }

    public void Remove(ItemData itemData)
    {
        itemDictionary.TryGetValue(itemData, out InventoryItem item);
        if (item != null)
        {
            inventory.Remove(item);
            itemDictionary.Remove(itemData);
            if (wallet != null)
            {
                wallet.IncreaseMoney(itemData.cost);
            }

            if (kcal != null)
            {
                kcal.DecreaseKcal(itemData.kcal);
            }

            selectedItemsCount--;
            
            audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.clip = removeSound;
                audioSource.Play();
            }
            OnInventoryChange?.Invoke(inventory);
        }
    }
}
