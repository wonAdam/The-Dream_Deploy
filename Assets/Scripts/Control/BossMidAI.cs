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
        public enum AI_STATE{
            CHASING, RUSHREADY, RUSHING, IDLE, SHOOTREADY, SHOOT
        }
        public AI_STATE currentAI_State = AI_STATE.CHASING;
        [SerializeField] int idleDamageCountCondition = 20;
        [SerializeField] float idleDuration = 2f;
        [SerializeField] float rushToRushDuration_Min = 5f;
        [SerializeField] float rushToRushDuration_Max = 10f;
        public float tikTokUntilRush = 0f;
        private float currWaitTillRush = -1f;
        Vector2 rushDestination;
        private Animator animator;
        private Mover mover;
        private PlayerController playerController;
        public float idleTikTok = 0f;

        // private void Start() {
        //     animator = GetComponent<Animator>();
        //     playerController = FindObjectOfType<PlayerController>();
        //     mover = GetComponent<Mover>();

        //     tikTokUntilRush = Random.Range(rushToRushDuration_Min, rushToRushDuration_Max);
        // }
        private void OnEnable() {
            animator = GetComponent<Animator>();
            playerController = FindObjectOfType<PlayerController>();
            mover = GetComponent<Mover>();

            tikTokUntilRush = Random.Range(rushToRushDuration_Min, rushToRushDuration_Max);
        }

        private void Update() {
            if(IsStateChasing())
            {
                TikTokToRush();
            }
        }
        private void TikTokToRush()
        {
            currWaitTillRush += Time.deltaTime;

            if(tikTokUntilRush <= currWaitTillRush)
            {
                currWaitTillRush = 0f;
                currentAI_State = AI_STATE.RUSHREADY;
            }
        }

        [Task]
        public void RushReadyAnimation()
        {
            rushDestination = playerController.transform.position;
            animator.SetTrigger("RushReady");
            animator.ResetTrigger("Rush");
            mover.Stop();
            Task.current.Succeed();
        }

        [Task]
        public void StateToRush()
        {
            currentAI_State = AI_STATE.RUSHING;
            Task.current.Succeed();
        }

        [Task]
        public void StateToChase()
        {
            tikTokUntilRush = Random.Range(rushToRushDuration_Min, rushToRushDuration_Max);
            currentAI_State = AI_STATE.CHASING;
            Task.current.Succeed();
        }

        [Task]
        public void RushToDestinationPosition()
        {
            Vector2 dir_power = rushDestination - (Vector2)transform.position;
            animator.SetTrigger("Rush");
            mover.MoveTo(dir_power * 10f);

            if(dir_power.magnitude <= 0.1f)
                currentAI_State = AI_STATE.IDLE;

            Task.current.Succeed();
        }


        [Task]
        public bool IsStateChasing()
        {
            if(currentAI_State == AI_STATE.CHASING) return true;
            else return false;
        }

        [Task]
        public bool IsStateRushReady()
        {
            if(currentAI_State == AI_STATE.RUSHREADY) return true;
            else return false;
        }

        [Task]
        public bool IsStateRushing()
        {
            if(currentAI_State == AI_STATE.RUSHING) return true;
            else return false;
        }

        [Task]
        public bool IsStateIdling()
        {
            if(currentAI_State == AI_STATE.IDLE) return true;
            else return false;
        }

        [Task]
        public void MoveTowardPlayer()
        {
            if(playerController == null) return;

            Vector2 dir = playerController.transform.position - transform.position;
            dir.Normalize();
            mover?.MoveTo(dir);
            Task.current.Succeed();
        }


        [Task]  
        public void Idle()
        {
            mover?.Stop();
            Task.current.Succeed();
        }

    }
}
