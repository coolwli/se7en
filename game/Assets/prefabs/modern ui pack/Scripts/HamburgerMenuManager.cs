using UnityEngine;
using TMPro;

namespace Michsky.UI.ModernUIPack
{
    public class HamburgerMenuManager : MonoBehaviour
    {
        private Animator menuAnimator;

        [Header("RESOURCES")]
        public Animator animatedButton;
        

        [Header("SETTINGS")]
        public bool openAtStart = false;
        public string titleAtStart;

        bool isOpen;

        void Start()
        {
            menuAnimator = gameObject.GetComponent<Animator>();
            

            if(openAtStart == true)
            {
                
                animatedButton.Play("HTE Expand");
                isOpen = true;
            }

            else
            {
                
                animatedButton.Play("HTE Hamburger");
                isOpen = false;
            }
        }

        public void Animate()
        {
            if (isOpen == true)
            {
                
                animatedButton.Play("HTE Hamburger");
                isOpen = false;
            }

            else
            {          
               
                animatedButton.Play("HTE Exit");
                isOpen = true;
            }
        }
    }
}