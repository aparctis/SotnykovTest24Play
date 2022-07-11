using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runer24
{
    public class PlayerBody : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Animator anim;
        [SerializeField] private InvisibleCar car;
        [SerializeField] GameObject textPlus;
        [SerializeField] GameObject gameOverUI;

        private bool isFollen = false;

        public void Jump()
        {
            anim.SetTrigger("Jump");
            CreateText();
        }

        public void Fall()
        {
            if (isFollen == false)
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.isKinematic = false;
                car.FallDown();
                gameOverUI.SetActive(true);
                isFollen = true;
            }

        }



        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.GetComponent<Brick>() != null)
            {
                Fall();
            }
        }

        private void CreateText()
        {
            GameObject newText = Instantiate(textPlus);
            newText.transform.position = transform.position;
        }


    }
}
