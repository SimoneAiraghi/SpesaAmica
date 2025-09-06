using System;
using System.Collections.Generic;
using UnityEngine;

namespace Eventi.Script
{
    public class EventData : MonoBehaviour
    {
        public static EventData Instance;

        public List<string> badClimateEvents;

        public List<string> eventToReactivate;

        public int cost;

        public int positiveClimate;
        public int positiveHealth;
        public int climateCount;
        public int healthCount;
        
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            
            Instance= this;
            DontDestroyOnLoad(gameObject);
        }

        public void RemoveEvent(string eventToRemove)
        {
            badClimateEvents.Remove(eventToRemove);
        }

        public void AddRemovedItems(string pastEvent)
        {
            eventToReactivate.Add(pastEvent);
        }

        public void ResetEvents()
        {
            eventToReactivate = new List<string>();
            climateCount = 0;
            healthCount = 0;
            positiveClimate = 0;
            positiveHealth = 0;
        }
    }
}
