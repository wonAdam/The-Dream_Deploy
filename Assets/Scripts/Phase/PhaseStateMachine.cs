using System.Collections;
using System.Collections.Generic;
using ADAM.Combat;
using ADAM.Control;
using ADAM.Core;
using ADAM.Movement;
using ADAM.UI;
using UnityEngine;

namespace ADAM.Phase
{
    public class PhaseStateMachine : MonoBehaviour
    {
        public enum PHASE_STATE{
            START, BATTLE, CLEAR
        }
        PHASE_STATE curr_en_PhaseState = PHASE_STATE.START;
        Mover[] movers;
        Health[] healths;
        PlayerController playerController;
        BossMidAI bossMidAI;
        Timer timer;
        ProjectileSpawner projectileSpawner;
        ItemSpawner itemSpawner;
        LevelManager levelManager;
        CoverPanel coverPanel;
        IPhaseState currPhaseState;
        
        // Start is called before the first frame update
        void Start()
        {
            movers = FindObjectsOfType<Mover>();
            healths = FindObjectsOfType<Health>();
            playerController = FindObjectOfType<PlayerController>();
            itemSpawner = FindObjectOfType<ItemSpawner>();
            bossMidAI = FindObjectOfType<BossMidAI>();
            timer = FindObjectOfType<Timer>();
            projectileSpawner = FindObjectOfType<ProjectileSpawner>();
            levelManager = FindObjectOfType<LevelManager>();
            coverPanel = FindObjectOfType<CoverPanel>();

            currPhaseState = new State_Start(movers, playerController, bossMidAI, timer, projectileSpawner, itemSpawner,coverPanel, "Stage " + levelManager.StageIndex);
            currPhaseState.Enter();
        }

        public void ChangePhaseState(IPhaseState nextState)
        {
            currPhaseState.Exit();
            currPhaseState = nextState;
            currPhaseState.Enter();
        }

        public void StateToBattle()
        {
            ChangePhaseState(new State_Battle());
            curr_en_PhaseState = PHASE_STATE.BATTLE;
        }

        public void StateToClear()
        {
            if(curr_en_PhaseState != PHASE_STATE.BATTLE) return;
            
            ChangePhaseState(new State_Clear(movers, healths, playerController, bossMidAI, timer, projectileSpawner, itemSpawner,coverPanel, levelManager));
            curr_en_PhaseState = PHASE_STATE.CLEAR;

        }
    }

}
