using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ADAM.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] float speed = 150f;
        PlayerAnimController playerAnimController;
        private Rigidbody2D myRB;
        private void Start() {
            myRB = GetComponent<Rigidbody2D>();
            playerAnimController = GetComponent<PlayerAnimController>();
        }
        public void MoveTo(Vector2 dir_normalized)
        {
            myRB.velocity = dir_normalized * speed * Time.deltaTime;
            playerAnimController.UpdateAnimState(dir_normalized);
        }
    }
}
