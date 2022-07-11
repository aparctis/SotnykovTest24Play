using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runer24
{
    public class MainMenu : MonoBehaviour
    {
        public void Exit()
        {
            Application.Quit();
        }

        public void Pausa()
        {

            Time.timeScale = 0;
            Debug.Log("Pausa ON");
        }

        public void PausaBreak()
        {
            Time.timeScale = 1;
            Debug.Log("Pausa OFF");
        }

        public void Resturt()
        {

            SceneManager.LoadScene("GameScene");

        }



        public void ClikTest()
        {
            Debug.Log("Click");
        }
    }

}