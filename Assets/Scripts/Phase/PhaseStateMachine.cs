using System.Collections;
using System.Collections.Generic;
using ADAM.Control;
using ADAM.Core;
using ADAM.Movement;
using ADAM.UI;
using UnityEngine;

namespace ADAM.Phase
{
    public class PhaseStateMachine : MonoBehaviour
    {
        Mover[] movers;
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
        }

        public void StateToClear()
        {
            ChangePhaseState(new State_Clear(movers, playerController, bossMidAI, timer, projectileSpawner, itemSpawner,coverPanel, levelManager));
        }
    }

}
