using System.Collections;
using System.Collections.Generic;
using ADAM.Movement;
using UnityEngine;

namespace ADAM.Control
{
    public class PlayerController : MonoBehaviour
    {

        Mover myMover;
        // Start is called before the first frame update
        void Start()
        {
            myMover = GetComponent<Mover>();
        }

        // Update is called once per frame
        public void OnClick_ShootBtn()
        {
            
        }
        public void ProcessMovement(Vector2 dir)
        {
            dir.Normalize();

            myMover.MoveTo(dir);

        }
    }
}
