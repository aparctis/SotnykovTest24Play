using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Runer24
{
    public class TouchMover : MonoBehaviour
    {
        private Vector3 position;
        private float width;
        private float height;

        [SerializeField] private float roadWidth;
        [SerializeField] private float leftX;
        [SerializeField] private float offsetX;


        void Awake()
        {
            width = (float)Screen.width;

            // Position used for the cube.
            position = new Vector3(0.0f, 0.0f, 0.0f);
        }

        private void Start()
        {
            leftX = 0 - (roadWidth / 2);
            offsetX = (roadWidth) / 100;
        }

        void OnGUI()
        {
            // Compute a fontSize based on the size of the screen width.
            GUI.skin.label.fontSize = (int)(Screen.width / 25.0f);

            GUI.Label(new Rect(20, 20, width, height * 0.25f),
                "x = " + position.x.ToString("f2") +
                ", y = " + position.y.ToString("f2"));
        }

        void FixedUpdate()
        {
            // Handle screen touches.
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                // Move the cube if the screen has the finger moving.
                if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 pos = touch.position;
                    float proc = pos.x / (width/100);

                    Vector3 transP = transform.position;
                    float newX = leftX + (proc * offsetX);
                    position = new Vector3(newX, transP.y, transP.z);

                    // Position the cube.
                    transform.position = position;
                }


                
            }
        }
    }


    
}
