using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runer24
{
    public class InvisibleCar : MonoBehaviour
    {
        [SerializeField] private float m_speed = 3;
        private float speed;

        [SerializeField] private float speedToWrap;
        [SerializeField] private GameObject wrapEffect;

        private float speedBonus;
        private bool wrapIsOn = false;


        private void Start()
        {
            speed = 0;
        }

        private void FixedUpdate()
        {
            transform.Translate(transform.forward * speed * Time.fixedDeltaTime);

        }

        public void SetSpeed(int newSpeed)
        {
            
            speedBonus = (float)newSpeed*0.5f;
            speed = m_speed + speedBonus;

            if(wrapIsOn==false)
            {
                if (speed >= speedToWrap)
                {
                    wrapEffect.SetActive(true);
                    wrapIsOn = true;
                }

            }

            else
            {
                if (speed < speedToWrap)
                {
                    wrapEffect.SetActive(false);
                    wrapIsOn = false;
                }
            }

        }

        public void StartGame()
        {
            speed = m_speed;

        }


        public void FallDown()
        {
            speed = 0f;
        }

    }
}
