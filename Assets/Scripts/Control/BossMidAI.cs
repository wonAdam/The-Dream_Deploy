using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;
using ADAM.Combat;
using ADAM.Movement;

namespace ADAM.Control
{
    public class BossMidAI : MonoBehaviour
    {
        [SerializeField] int idleDamageCountCondition = 20;
        [SerializeField] float idleDuration = 2f;
        private Animator animator;
        private Mover mover;
        private PlayerController playerController;
        public float idleTikTok = 0f;

        private void Start() {
            animator = GetComponent<Animator>();
            playerController = FindObjectOfType<PlayerController>();
            mover = GetComponent<Mover>();
        }

        [Task]
        public void MoveTowardPlayer()
        {
            Vector2 dir = playerController.transform.position - transform.position;
            dir.Normalize();
            mover.MoveTo(dir);
            Task.current.Succeed();
        }


        [Task]
        public void Idle()
        {

            if(GetComponent<Health>().damageCount > idleDamageCountCondition)
            {
                idleTikTok += Time.deltaTime;

                if(idleTikTok >= idleDuration)
                {
                    idleTikTok = 0f;
                    animator.SetInteger("XDir", 0);
                    GetComponent<Health>().damageCount = 0;
                    Task.current.Fail();
                    return;
                }

                Task.current.Succeed();

            } 
            Task.current.Fail();      
        }
    }
}
