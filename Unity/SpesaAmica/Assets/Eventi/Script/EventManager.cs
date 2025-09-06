using System;
using System.Collections.Generic;
using System.Linq;
using Cassa.Script;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

namespace Eventi.Script
{
    public class EventManager : MonoBehaviour
    {
        public GameObject eventWindow;
        
        public GameObject redMeat;

        public GameObject apple;

        public GameObject salmon;

        public GameObject shrimps;

        public GameObject oysters; 
        
        public TextMeshProUGUI wallet;

        public ItemData eggBioData, cheeseData, eggData, saladData, tomatoesData, chickenData, potatoesData, broccoliData, strawberriesData, appleData, orangeData;

        public EventData eventData;
        
        
        // Start is called before the first frame update
        void Start()
        {
            if(EventData.Instance.climateCount == 0)
            {
                ResetItemData();
            }
            
            if (CassaManagerScript.instance != null)
            {
                HandleEvent();
            }
            
            RemovedItems();
        }

        private void HandleEvent()
        {
            int index = PlayerPrefs.GetInt("SelectedCharacterIndex", 0);
            eventData = EventData.Instance;
            switch (index)
            {
                case 0:
                    HandleClimateEventSceptic();
                    HandleHealthEventSceptic();
                    break;
                case 1:
                    HandleClimateEventNormal();
                    HandleHealthEventNormal();
                    break;
                case 2:
                    HandleClimateEventAnxious();
                    HandleHealthEventAnxious();
                    break;
            }
        }
        
        private void HandleClimateEventSceptic()
        {
            if (eventData.climateCount == 0 && (CassaManagerScript.instance.climateIndicator >= 55 &&
                                                CassaManagerScript.instance.preClimateIndicator < 55))
                ActivateEvent("redMeatExclusion");
            
            if (eventData.climateCount == 1 && (CassaManagerScript.instance.climateIndicator >= 60 &&
                                                     CassaManagerScript.instance.preClimateIndicator < 60))
                ActivateEvent("appleExclusion");
            
            if (eventData.climateCount == 2 && (CassaManagerScript.instance.climateIndicator >= 70 &&
                                                     CassaManagerScript.instance.preClimateIndicator < 70))
                ActivateEvent("incrementSceptical");
            if (eventData.positiveClimate == 0 && (CassaManagerScript.instance.climateIndicator <= 45 &&
                                                CassaManagerScript.instance.preClimateIndicator > 45))
                ActivatePositiveEvent("saleSceptical1");
            if (eventData.positiveClimate == 1 && (CassaManagerScript.instance.climateIndicator <= 40 &&
                                                   CassaManagerScript.instance.preClimateIndicator > 40))
                ActivatePositiveEvent("saleSceptical2");
            if (eventData.positiveClimate == 2 && (CassaManagerScript.instance.climateIndicator <= 35 &&
                                                   CassaManagerScript.instance.preClimateIndicator > 35))
                ActivatePositiveEvent("increaseBudgetSceptical");
        }

        private void HandleClimateEventAnxious()
        {
            if (eventData.climateCount == 0 && (CassaManagerScript.instance.climateIndicator >= 55 &&
                                                CassaManagerScript.instance.preClimateIndicator < 55))
                ActivateEvent("alert");
            
            if (eventData.climateCount == 1 && (CassaManagerScript.instance.climateIndicator >= 60 &&
                                                CassaManagerScript.instance.preClimateIndicator < 60))
                ActivateEvent("alert2");
            
            if (eventData.climateCount == 2 && (CassaManagerScript.instance.climateIndicator >= 70 &&
                                                CassaManagerScript.instance.preClimateIndicator < 70))
                ActivateEvent("incrementAnxious");
            if (eventData.positiveClimate == 0 && (CassaManagerScript.instance.climateIndicator <= 45 &&
                                                   CassaManagerScript.instance.preClimateIndicator > 45))
                ActivatePositiveEvent("encouragementAnxious");
            if (eventData.positiveClimate == 1 && (CassaManagerScript.instance.climateIndicator <= 40 &&
                                                   CassaManagerScript.instance.preClimateIndicator > 40))
                ActivatePositiveEvent("saleAnxious");
            if (eventData.positiveClimate == 2 && (CassaManagerScript.instance.climateIndicator <= 35 &&
                                                   CassaManagerScript.instance.preClimateIndicator > 35))
                ActivatePositiveEvent("increaseBudgetAnxious");
        }

        private void HandleClimateEventNormal()
        {
            if (eventData.climateCount == 0 && (CassaManagerScript.instance.climateIndicator >= 55 &&
                                                CassaManagerScript.instance.preClimateIndicator < 55))
                ActivateEvent("alertClimateNormal");
            
            if (eventData.climateCount == 1 && (CassaManagerScript.instance.climateIndicator >= 60 &&
                                                CassaManagerScript.instance.preClimateIndicator < 60))
                ActivateEvent("incrementNormal");
            
            if (eventData.climateCount == 2 && (CassaManagerScript.instance.climateIndicator >= 70 &&
                                                CassaManagerScript.instance.preClimateIndicator < 70))
                ActivateEvent("productsExclusion");
            if (eventData.positiveClimate == 0 && (CassaManagerScript.instance.climateIndicator <= 45 &&
                                                   CassaManagerScript.instance.preClimateIndicator > 45))
                ActivatePositiveEvent("encouragementNormal");
            if (eventData.positiveClimate == 1 && (CassaManagerScript.instance.climateIndicator <= 40 &&
                                                   CassaManagerScript.instance.preClimateIndicator > 40))
                ActivatePositiveEvent("saleNormal");
            if (eventData.positiveClimate == 2 && (CassaManagerScript.instance.climateIndicator <= 35 &&
                                                   CassaManagerScript.instance.preClimateIndicator > 35))
                ActivatePositiveEvent("increaseBudgetNormal");
        }

        private void HandleHealthEventSceptic()
        {
            if (eventData.healthCount == 0 && (CassaManagerScript.instance.healthIndicator <= 40 &&
                                                CassaManagerScript.instance.preHealthIndicator > 40))
                ActivateEvent("alertSceptic");
            
            if (eventData.healthCount == 1 && (CassaManagerScript.instance.healthIndicator <= 20 &&
                                               CassaManagerScript.instance.healthIndicator > 20))
                ActivateEvent("decreaseBudgetSceptic");
            if (eventData.positiveHealth == 0 && (CassaManagerScript.instance.healthIndicator >= 80 &&
                                               CassaManagerScript.instance.healthIndicator < 80))
                ActivatePositiveEvent("healthReward");
        }

        private void HandleHealthEventNormal()
        {
            if (eventData.healthCount == 0 && (CassaManagerScript.instance.healthIndicator <= 40 &&
                                               CassaManagerScript.instance.preHealthIndicator > 40))
                ActivateEvent("alertNormal");
            
            if (eventData.healthCount == 1 && (CassaManagerScript.instance.healthIndicator <= 20 &&
                                               CassaManagerScript.instance.healthIndicator > 20))
                ActivateEvent("decreaseBudgetNormal");
            if (eventData.positiveHealth == 0 && (CassaManagerScript.instance.healthIndicator >= 80 &&
                                                  CassaManagerScript.instance.healthIndicator < 80))
                ActivatePositiveEvent("healthReward");
        }
        
        private void HandleHealthEventAnxious()
        {
            if (eventData.healthCount == 0 && (CassaManagerScript.instance.healthIndicator <= 40 &&
                                               CassaManagerScript.instance.preHealthIndicator > 40))
                ActivateEvent("alertAnxious");
            
            if (eventData.healthCount == 1 && (CassaManagerScript.instance.healthIndicator <= 20 &&
                                               CassaManagerScript.instance.healthIndicator > 20))
                ActivateEvent("decreaseBudgetAnxious");
            if (eventData.positiveHealth == 0 && (CassaManagerScript.instance.healthIndicator >= 80 &&
                                                  CassaManagerScript.instance.healthIndicator < 80))
                ActivatePositiveEvent("healthReward");
        }

        private string ExtractRandomEvent()
        { 
            eventData = EventData.Instance;
            if (eventData.badClimateEvents.Count == 0) return null;
            
            //Take a random event from the badClimateEvents list than remove this event from this list
            Random random = new Random();
            var index = random.Next(eventData.badClimateEvents.Count);
            var randomEvent = eventData.badClimateEvents[index];
            eventData.RemoveEvent(randomEvent);
            return randomEvent;
        }

        private void ActivatePositiveEvent(string eventId)
        {
            string text = null;
            switch (eventId)
            {
                case "saleSceptical1":
                    eventData.positiveClimate += 1;
                    appleData.SetCost(2);
                    eggBioData.SetCost(5);
                    strawberriesData.SetCost(3);
                    tomatoesData.SetCost(2);
                    text =
                        "Your choice of sustainable products not only benefits you but also our planet! Congratulations! Every product you choose, respecting the environment, represents a small step towards a better world. We want to express our sincere gratitude for your dietary choices, and as a token of appreciation, we want to offer you a special opportunity for your next shopping. In the upcoming days, you will have the chance to purchase one of our organic products at 50% off the original price. Take advantage of this offer and continue making a difference! Thank you for being part of the positive change!";
                    break;
                case "saleSceptical2":
                    eventData.positiveClimate += 1;
                    chickenData.SetCost(4);
                    potatoesData.SetCost(2);
                    text =
                        "Thanks to your eco-friendly choices during your shopping at our supermarket, we're thrilled to announce that soon you'll find discounted products such as chicken and potatoes! This is our way of congratulating you for contributing to the improvement of our planet's well-being. We are inspired by your targeted choices to reduce environmental impact, and we hope that over time, you can continue to do so! Keep up the fantastic work and take advantage of these special discounts as a thank you for your ecological commitment. Together, we are making a difference for a more sustainable future!";
                    break;
                case "increaseBudgetSceptical":
                    eventData.positiveClimate += 1;
                    CassaManagerScript.instance.walletIndicator += 10;
                    int cost = CassaManagerScript.instance.walletIndicator;
                    wallet.text = cost.ToString();
                    text =
                        "Congratulations! Despite your skepticism about climate change, it turns out that your choices regarding our products are sustainable! For this reason, you have accumulated a significant balance in shopping points, and we are pleased to inform you that these points have been converted into a voucher worth 10$! This reward is our way of thanking you for the contribution you make towards a more sustainable lifestyle, and, of course, you can use the voucher during your next purchases at our supermarket!";
                    break;
                case "encouragementAnxious":
                    eventData.positiveClimate += 1;
                    text =
                        "We want to extend our warmest congratulations to you for your commitment to choosing eco-friendly products! We are grateful to have you as a customer and to share this sustainability mission with you. Thank you for being a true ambassador of positive change! You make a difference!";
                    break;
                case "saleAnxious":
                    eventData.positiveClimate += 1;
                    chickenData.SetCost(4);
                    potatoesData.SetCost(3);
                    appleData.SetCost(3);
                    eggBioData.SetCost(6);
                    strawberriesData.SetCost(4);
                    text =
                        "Exciting discounts coming your way, climate change ambassador! Every choice you make counts and together we are contributing to a brighter future for all. Your commitment is truly inspiring, and for that, we are thrilled to inform you that soon, in our supermarket, you will find discounts on some of our products such as chicken, organic eggs, organic strawberries, potatoes and organic apples!";
                    break;
                case "increaseBudgetAnxious":
                    eventData.positiveClimate += 1;
                    Inventory.instance.Add(orangeData);
                    CassaManagerScript.instance.walletIndicator += 6 + orangeData.cost;;
                    wallet.text = CassaManagerScript.instance.walletIndicator.ToString();
                    text =
                        "Your dedication to selecting eco-friendly products is truly commendable and thanks to your consistent choice of sustainable food products, you have accumulated a significant balance in shopping points. We are pleased to inform you that these points have been converted into a voucher worth 6 euros, which you can use during your next purchases at our supermarket! Additionally, we have the pleasure of gifting you a box of our locally sourced, sustainable oranges. This is our way of sharing a piece of our commitment to local and sustainable products with you. We invite you to collect your box of oranges during your next shopping with us! ";
                    break;
                case "encouragementNormal":
                    eventData.positiveClimate += 1;
                    text =
                        "With every sustainable choice, you significantly contribute to preserving our environment and promoting food practices that have a positive impact on the planet. We want to thank you for being a conscious consumer! Keep it up!";
                    break;
                case "saleNormal":
                    eventData.positiveClimate += 1;
                    chickenData.SetCost(4);
                    potatoesData.SetCost(3);
                    appleData.SetCost(3);
                    orangeData.SetCost(2);
                    text =
                        "Great job! Thanks to your eco-friendly and sustainable choices during your shopping at our supermarket, we're excited to let you know that soon you'll find discounted products such as chicken, potatoes, organic apples and local oranges. A sincere thank you for your contribution, keep it up!";
                    break;
                case "increaseBudgetNormal":
                    eventData.positiveClimate += 1;
                    CassaManagerScript.instance.walletIndicator += 8;
                    wallet.text = CassaManagerScript.instance.walletIndicator.ToString();
                    text =
                        "Thanks to your consistent selection of sustainable food products, you have accrued a balance in shopping points. We are delighted to inform you that these points have been converted into a voucher worth 8$, which you can, of course, utilize during your next purchases at our supermarket! Thank you for contributing to our collective effort towards a better planet!";
                    break;
                case "healthReward":
                    eventData.positiveHealth += 1;
                    Inventory.instance.Add(strawberriesData);
                    CassaManagerScript.instance.walletIndicator += strawberriesData.cost;;
                    wallet.text = CassaManagerScript.instance.walletIndicator.ToString();
                    text =
                        "Your commitment to seeking products with caloric content in line with a balanced diet and a well-rounded lifestyle has earned you a complimentary item! The next time you shop at our supermarket, we invite you to show this message at the checkout, and you will be given a free box of our delicious organic strawberries! However, we advise you to maintain awareness in your selections, avoiding excessive restriction.";
                    break;
            }
            if (text != null) CreateEventWindow(text);
        }
        
        private void ActivateEvent(string eventId)
        {
            string text = null;
            switch (eventId)
            {
                case "redMeatExclusion":
                    if (!eventData.eventToReactivate.Contains(eventId))
                    {
                        eventData.climateCount += 1;
                        eventData.AddRemovedItems(eventId);
                        text =
                            "Breaking news: Devastation of cattle farms due to a catastrophic flood\n\nDue to a catastrophic flood, the cattle farms that SpesaAmica supermarket relies on have been destroyed. We regret to inform our customers that our supermarket will no longer be able to offer this product, red meat in particular, for an indefinite period. We encourage you to think about the environmental impact of our dietary choices! Every small gesture, in any aspect of our lives, can make a difference. Let's dedicate ourselves to make conscious choices, or we risk to face a planet in ruins and this would mean no future for humanity!\n\nTip: Did you know that, on average, 100 grams of cheese protein emit about 10.8 kg of equivalent CO2? Reflect on your choices!";
                    }
                    redMeat.SetActive(false);
                    break;
                case "garbageTax":
                    CassaManagerScript.instance.walletIndicator -= 10;
                    int cost = CassaManagerScript.instance.walletIndicator;
                    eventData.climateCount += 1;
                    wallet.text = cost.ToString();
                    text = 
                        "The municipality has decided that consumers who make non eco-friendly purchases will face an increase in the waste disposal tax. You have been subject to a surcharge of $10 on the waste disposal fee.";
                    break;
                case "alert2":
                        eventData.climateCount += 1;
                        text =
                            "It's normal to be concerned about the current environmental situation but remember that making a difference requires rationality and self-control! Excessive worry doesn't benefit either the planet or yourself. Take a deep breath and roll up your sleeves to improve your dietary choices. We can truly make a difference! Let's start with our food choices! For instance, avocados have a high environmental impact, so consider exploring other available options. Making thoughtful choices will provide tangible help to the planet!";
                    break;
                case "appleExclusion":
                    if (!eventData.eventToReactivate.Contains(eventId))
                    {
                        eventData.climateCount += 1;
                        eventData.AddRemovedItems(eventId);
                        text =
                            "Breaking News: Devastation of apple orchards due to a Severe Hailstorm\n\nFollowing a powerful hailstorm, apple orchards have been completely destroyed, marking an unprecedented tragedy for local producers. The intensity of the severe weather has inflicted severe damage on the plantations, causing irreparable harm and compromising the entire harvest. With deep regret, our supermarket is compelled to inform customers that due to this natural disaster, it will no longer be possible to find apples on our shelves for an indefinite period. This tragic event underscores the importance of addressing climate change to protect our planet's natural resources.\n\nTip: Do you know that bivalves like mussels and oysters emit minimal greenhouse gases as they require no feed, consume little energy during harvest, and promote algae growth that captures CO2.";
                    }
                    apple.SetActive(false);
                    break;
                case "incrementSceptical":
                    eventData.climateCount += 1;
                    eggBioData.IncrementCost(3);
                    cheeseData.IncrementCost(3);
                    eggData.IncrementCost(3);
                    text =
                        "Breaking News: Critical Situation at the Supermarket Due to Record-High Temperatures\n\nFollowing the record-breaking temperatures in these summer days, the farms supplying eggs and cheese to our supermarket have experienced an unprecedented tragedy. The excessive heat has led to the death of many animals on the farms, severely compromising the production of these products. This has resulted in a critical shortage of these products on our shelves and to a 25% price increase on those still available. This dramatic event urges us to reflect on the urgent need to address climate change.\n\nTip: You should know that a small two-pack of avocados produces 846.36 grams of CO2, the equivalent of two kilograms of bananas, and it is estimated that one kilogram of Mexican avocados travels about 10,200 km to reach Europe, for a total of 18.5 kg of carbon dioxide emitted into the atmosphere.";
                    break;
                case "alert":
                    eventData.climateCount += 1;
                    text =
                        "Have you thought about the environmental impact of beef? Beef production contributes to greenhouse gas emissions. But don't worry, we can explore more sustainable alternatives together without added stress. For example, there are delicious options with a lower environmental footprint to consider for your next meal. How about discovering them together? With small daily choices, like those regarding our diet, we can truly make a difference, we still have time, no worry!";
                    break;
                case "incrementAnxious":
                    eventData.climateCount += 1;
                    saladData.IncrementCost(3);
                    tomatoesData.IncrementCost(3);
                    chickenData.IncrementCost(3);
                    text =
                        "Hey, climate change explorer! It seems like some of your choices have contributed to a higher climate change indicator. Don't worry too much; we're here to help you to take steps towards a lighter environmental impact! Perhaps we can explore some sustainable alternatives for your upcoming purchases. For instance, consider buying local fruits: not only delicious but also a way to reduce environmental impact. Remember, every small gesture counts, and you're already making a difference by trying to improve! With small positive changes, we can make a significant impact. Thank you for being part of our team for a greener planet!";
                    break;
                case "alertClimateNormal":
                        eventData.climateCount += 1;
                        text =
                            "Alert Message!\n\nAttention, you can do better! It is with concern that we inform you about the worsening climate conditions. Our planet is undergoing significant changes, and each of us can contribute to mitigating this situation. We encourage you to reflect on your daily habits and make more thoughtful choices to reduce environmental impact. In this context, consider the option of choosing organic products. Organic foods are cultivated without the use of synthetic pesticides and chemical fertilizers, helping to preserve soil health and reduce pollution. Every choice you make matters, and opting for organic products is a positive way to support sustainable farming practices. Thank you for being part of the change and for doing your part for a greener future.";
                    break;
                case "incrementNormal":
                    eventData.climateCount += 1;
                    chickenData.IncrementCost(3);
                    potatoesData.IncrementCost(3);
                    broccoliData.IncrementCost(3);
                    text =
                        "Message!\n\nYou can do better than this! Some products, specifically chicken, potatoes and broccoli, experienced a prize increase. Our planet is undergoing significant distress due to everyday choices influencing our environment. We implore you to scrutinize your purchasing decisions more carefully to contribute to a more sustainable future. Specifically, we wish to enlighten you about the environmental impact of farmed salmon. The practice of salmon farming can detrimentally affect water quality and the surrounding ecosystem. This is a critical matter, as the equilibrium of marine ecosystems is vital for life on Earth. We urge you to explore more sustainable alternatives in the seafood section. Consider choices like sustainably caught fish, which can have a lesser impact on the environment. Your commitment to such decisions is crucial in mitigating the environmental crisis we face. Let's join hands for a planet-friendly tomorrow.";
                    break;
                case "productsExclusion":
                    if (!eventData.eventToReactivate.Contains(eventId))
                    {
                        eventData.climateCount += 1;
                        eventData.AddRemovedItems(eventId);
                        text =
                            "Breaking News: Impact of Microplastics\n\nOur supermarket wishes to inform our valued customers of a critical situation affecting the seafood section. Due to the excessive presence of microplastics in the oceans, marine life has suffered significant harm, impacting the availability of certain seafood products. In response to this environmental emergency, some items from the seafood section will no longer be available for an indefinite period. This decision has been made to ensure food quality and safety in light of the current situation. \\n\\nOur supermarket encourages everyone to reflect on the impact of microplastics and consider more sustainable choices to preserve our oceans and their rich biodiversity.\n\nTip: Do you know that bivalves like mussels and oysters emit minimal greenhouse gases as they require no feed, consume little energy during harvest, and promote algae growth that captures CO2.";
                    }
                    salmon.SetActive(false);
                    shrimps.SetActive(false);
                    oysters.SetActive(false); 
                    break;
                case "alertSceptic":
                    eventData.healthCount += 1;
                    text =
                        "Pay attention to your product choices! Finding the right balance between environmental care and your daily caloric needs is crucial. You can't just opt for environmentally friendly products without also considering your sense of satiety. We encourage you to reassess the evaluations of your food choices, ensuring they meet both your nutritional needs and sustainability standards. With a balanced approach, you can contribute to personal and environmental well-being. Thank you for your attention and commitment to a healthy and sustainable lifestyle!";
                    break;
                case "decreaseBudgetSceptic":
                    eventData.healthCount += 1;
                    CassaManagerScript.instance.walletIndicator -= 25;
                    wallet.text = CassaManagerScript.instance.walletIndicator.ToString();
                    text =
                        "Unfortunately, lately, you haven't been following a balanced diet, and your caloric intake is insufficient. Your attending physician has prescribed supplements to ensure your nutritional well-being. However, this expense has cost you $25. Remember that your health is a priority, and following the doctor's advice will contribute to your overall well-being. Let's work together to find sustainable solutions to ensure proper nutrition without compromising your budget.";
                    break;
                case "alertNormal":
                    eventData.healthCount += 1;
                    text =
                        "It's essential that you take into account your dietary choices. Finding a balance between environmental sustainability and your daily caloric needs is crucial. In addition to considering eco-friendly products, make sure to satisfy your sense of fullness. We encourage you to reflect on your dietary choices, striving to balance nutritional needs with sustainability standards. A more mindful approach can contribute to personal and environmental well-being. We appreciate your commitment to a healthy lifestyle.";
                    break;
                case "decreaseBudgetNormal":
                    eventData.healthCount += 1;
                    CassaManagerScript.instance.walletIndicator -= 25;
                    wallet.text = CassaManagerScript.instance.walletIndicator.ToString();
                    text =
                        "Are you aware of the importance of meeting the correct caloric needs through a balanced diet? It's not possible to completely replace what your body requires with just supplements. Unfortunately, repeating this behavior has led you to undergo blood tests under your doctor's supervision, incurring a cost of $25. The results indicate that your iron levels are a bit low. Have you considered the option of including meat in your diet, being mindful of choosing protein sources? Your health is of primary importance, and we are here to offer support on this journey. If you have questions or need further advice, feel free to ask.";
                    break;
                case "alertAnxious":
                    eventData.healthCount += 1;
                    text =
                        "Attention! It's important that you pay attention to your dietary choices! Striking a balance between environmental care and your daily caloric needs is crucial. Don't focus solely on eco-friendly products; make sure to satisfy your sense of fullness as well. We urge you to review the assessments of your dietary choices, aiming to balance your nutritional needs with sustainability standards. With a more mindful approach, you can contribute to personal and environmental well-being. We appreciate your dedication to a healthy and sustainable lifestyle!";
                    break;
                case "decreaseBudgetAnxious":
                    eventData.healthCount += 1;
                    CassaManagerScript.instance.walletIndicator -= 25;
                    wallet.text = CassaManagerScript.instance.walletIndicator.ToString();
                    text =
                        "Hey! We appreciate your commitment to climate change, but don't forget about your health! Your sustainable choices are already a significant contribution to the planet, and there's no need to push yourself to the point of neglecting your caloric needs. We noticed that today you stopped by the pharmacy to get vitamin D supplements, probably due to feeling a bit down. We'd like to point out that this $25 expense was avoidable. We are here to support you, both in your ecological mission and in taking care of yourself. If you need advice or assistance, we're here for you. Your health is just as important as your dedication to a more sustainable world.";
                    break;
            }

            if (text != null) CreateEventWindow(text);
        }

        private void CreateEventWindow(string text)
        {
            GameObject window = Instantiate(eventWindow, transform, false);

            EventWindow newWindowComponent = window.GetComponent<EventWindow>();
            newWindowComponent.DrawEvent(text);
        }

        private void RemovedItems()
        {
            foreach (string activeEvent in eventData.eventToReactivate)
            {
                ActivateEvent(activeEvent);
            }
        }

        private void ResetItemData()
        {
            cheeseData.SetCost(10);
            eggBioData.SetCost(9);
            saladData.SetCost(1);
            broccoliData.SetCost(1);
            potatoesData.SetCost(3);
            chickenData.SetCost(5);
            eggData.SetCost(2);
            tomatoesData.SetCost(3);
            appleData.SetCost(4);
            strawberriesData.SetCost(5);
            orangeData.SetCost(3);
        }
        
    }
}
