using System.Collections;
using System.Collections.Generic;
using ADAM.Control;
using ADAM.Core;
using ADAM.Movement;
using ADAM.UI;
using UnityEngine;

namespace ADAM.Phase
{
    public class State_Start : IPhaseState
    {
        Mover[] movers;
        PlayerController playerController;
        BossMidAI bossMidAI;
        Timer timer;
        ProjectileSpawner projectileSpawner;
        ItemSpawner itemSpawner;
        CoverPanel coverPanel;
        string stageNum;

        public State_Start(Mover[] _movers, PlayerController _playerController, BossMidAI _bossMidAI, Timer _timer, ProjectileSpawner _projectileSpawner, 
                                ItemSpawner _itemSpawner, CoverPanel _coverPanel, string _stageNum)
        {
            movers = _movers; playerController = _playerController; bossMidAI = _bossMidAI;
            timer = _timer; projectileSpawner = _projectileSpawner; coverPanel = _coverPanel; 
            stageNum = _stageNum; itemSpawner = _itemSpawner;
        }

        public void Enter()
        {
            foreach(Mover m in movers)
            {
                m.enabled = false;
            }
            if(playerController)
                playerController.enabled = false;
            if(bossMidAI)
                bossMidAI.enabled = false;
            if(timer)
                timer.enabled = false;
            if(projectileSpawner)
                projectileSpawner.enabled = false;
            if(itemSpawner)
                itemSpawner.enabled = false;


            coverPanel.gameObject.SetActive(true);
            coverPanel.SetText(stageNum);
        }

        public void Exit()
        {
            foreach(Mover m in movers)
            {
                m.enabled = true;
            }
            if(playerController)
                playerController.enabled = true;
            if(bossMidAI)
                bossMidAI.enabled = true;
            if(timer)
                timer.enabled = true;
            if(projectileSpawner)
                projectileSpawner.enabled = true;
            if(itemSpawner)
                itemSpawner.enabled = true;

            coverPanel.gameObject.SetActive(false);        
        }

        public void Process()
        {
            
        }

    }
}
