using UnityEngine;

namespace Cassa.Script
{
    public class CassaManagerScript : MonoBehaviour
    {
        public static CassaManagerScript instance;

        public int preClimateIndicator;
        public int climateIndicator;
        public int walletIndicator;
        public int preHealthIndicator;
        public int healthIndicator;
        public int days;

        public string gameOverMessage;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
        
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void ResetIndicators()
        {
            preClimateIndicator = 0;
            climateIndicator = 50;
            walletIndicator = 70;
            preHealthIndicator = 0;
            healthIndicator = 0;
            days = 1;
            gameOverMessage = null;
        }
    
    }
}
