﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ADAM.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] float speed = 150f;
        PlayerAnimController playerAnimController = null;
        BossAnimController bossAnimController = null;
        private Rigidbody2D myRB;
        private float oringinalSpeed;

        private void OnEnable() {
            speed = oringinalSpeed;
            myRB = GetComponent<Rigidbody2D>();
            playerAnimController = GetComponent<PlayerAnimController>();
            bossAnimController = GetComponent<BossAnimController>();
            oringinalSpeed = speed;
        }

        private void OnDisable() {
            speed = 0f;
            myRB.velocity = Vector2.zero;
        }

        private void Awake() {
            myRB = GetComponent<Rigidbody2D>();
            playerAnimController = GetComponent<PlayerAnimController>();
            bossAnimController = GetComponent<BossAnimController>();
            oringinalSpeed = speed;
            
        }
        public void MoveTo(Vector2 dir_normalized)
        {
            if(dir_normalized == null) return;
            if(myRB == null) return;

            myRB.velocity = dir_normalized * speed * Time.deltaTime;
            playerAnimController?.UpdateAnimState(dir_normalized);
            bossAnimController?.UpdateAnimState(dir_normalized);
        }

        public void SetMoveSpeed(float newSpeed)
        {
            speed = newSpeed;
        }

        public void Stop()
        {
            myRB.velocity =  Vector2.zero;
        }
    }
}
