using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cassa.Script
{
    public class IndicatorsScript : MonoBehaviour
    {
        public GameObject finalButton;
        public GameObject nextDayButton;
        public int kcalGoal = 650;
        public bool lastDays = false;

        public void Start()
        {
            UpdateIndicators();
        }

        private void UpdateIndicators()
        {
            int totalKcal = 0;
            
            if (CassaManagerScript.instance == null) return;
            CassaManagerScript.instance.preClimateIndicator = CassaManagerScript.instance.climateIndicator;
            CassaManagerScript.instance.preHealthIndicator = CassaManagerScript.instance.healthIndicator;
            
            if (Inventory.instance == null) return;
            foreach (InventoryItem product in Inventory.instance.inventory)
            {
                CassaManagerScript.instance.climateIndicator += product.itemData.climate;
                CassaManagerScript.instance.walletIndicator -= product.itemData.cost;
                totalKcal += product.itemData.kcal;
            }
            CheckKcalAmount(totalKcal);

            if (CassaManagerScript.instance.days == 3)
            {
                finalButton.SetActive(true);
                nextDayButton.SetActive(false);
                lastDays = true;
            }
                
            else
            {
                lastDays = false;
                CassaManagerScript.instance.days += 1;
            }
        }

        private void CheckKcalAmount(int total)
        {
            if (total < kcalGoal)
            {
                int diff = kcalGoal - total;
                CassaManagerScript.instance.healthIndicator -= Convert.ToInt32(diff * 0.1);
            }
            else
            {
                int diff = total - kcalGoal;
                CassaManagerScript.instance.healthIndicator += Convert.ToInt32(diff * 0.1);
                if (CassaManagerScript.instance.healthIndicator > 100)
                    CassaManagerScript.instance.healthIndicator = 100;
            }
        }
        
        public void NextDay()
        {
            string check = CheckGameOver();
            if (check != null)
            {
                CassaManagerScript.instance.gameOverMessage = check;
                GoToGameOverScene();
            }
            else
            {
                SceneManager.LoadScene("Scaffali");
            }
        }

        public void GoToFinalScene()
        {
            string check = CheckGameOver();
            if (check != null)
            {
                CassaManagerScript.instance.gameOverMessage = check;
                GoToGameOverScene();
            }
            else
            {
                SceneManager.LoadScene("Menu finale copia");
            }
        }

        private void GoToGameOverScene()
        {
            SceneManager.LoadScene("GameOver");
        }
        
        public string CheckGameOver()
        {
            string text = null;
            if (CassaManagerScript.instance.climateIndicator >= 100)
            {
                text = "Your climate indicator reach the maximum, next time think better about your choices";
            } else if (CassaManagerScript.instance.healthIndicator <= 0)
            {
                text = "You have not eaten enough";
            } else if (CassaManagerScript.instance.walletIndicator <= 8)
            {
                if (lastDays) return null; 
                text = "You have finished your money";
            }

            return text;
        }
    }
}
