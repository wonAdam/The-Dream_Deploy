using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ADAM.Control
{
    public class Joystick : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IEnableByPhase
    {
        [SerializeField] float DistanceFromCenter = 150f;
        [SerializeField] GameObject handle = null;
        [SerializeField] GameObject JoystickGO = null;

        // todo Observer Pattern
        public bool isEnabled = true; // After Tutorial, should be true. After Battle, should be false
        private Camera mainCam;
        private Vector2 initTouchPos;
        private PlayerController playerController;
        private Vector2 mouseWorldPos;

        
        void Start()
        {
            // only if there is only one camera
            mainCam = FindObjectOfType<Camera>();
            playerController = FindObjectOfType<PlayerController>();
        }        
        
        private void Update() 
        {
            if(isEnabled)
                playerController.ProcessMovement(mouseWorldPos - initTouchPos);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            JoystickGO.SetActive(true);
            Vector3 mouseWorldPos = mainCam.ScreenToWorldPoint(eventData.position);
            initTouchPos = mouseWorldPos;
            JoystickGO.transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0) ;
        }

        public void OnDrag(PointerEventData eventData)
        {
            mouseWorldPos = mainCam.ScreenToWorldPoint(eventData.position);
            float NewXPos = Mathf.Clamp(mouseWorldPos.x , initTouchPos.x - DistanceFromCenter, initTouchPos.x + DistanceFromCenter);
            float NewYPos = Mathf.Clamp(mouseWorldPos.y , initTouchPos.y - DistanceFromCenter, initTouchPos.y + DistanceFromCenter);
            handle.transform.position = new Vector3(NewXPos, NewYPos, 0);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            handle.transform.position = JoystickGO.transform.position;
            mouseWorldPos = initTouchPos;
            JoystickGO.SetActive(false);
        }

        public void StartActing()
        {
                    // todo Observer Pattern

        }

        public void StopActing()
        {
                    // todo Observer Pattern

        }
    }
}
