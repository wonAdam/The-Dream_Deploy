using System.Collections;
using System.Collections.Generic;
using ADAM.Combat;
using ADAM.Control;
using ADAM.Core;
using ADAM.Movement;
using ADAM.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ADAM.Phase
{
    public class State_Asking : IPhaseState
    {
        Mover[] movers;
        Health[] healths;
        PlayerController playerController;
        BossMidAI bossMidAI;
        Timer timer;
        ProjectileSpawner projectileSpawner;
        ItemSpawner itemSpawner;
        BossAskingPanel bossAskingPanel;
        LevelManager levelManager;
        string clearMessage = "Clear ! ";
        public State_Asking(Mover[] _movers, Health[] _healths, PlayerController _playerController, BossMidAI _bossMidAI, Timer _timer, ProjectileSpawner _projectileSpawner, 
                                ItemSpawner _itemSpawner, BossAskingPanel _bossAskingPanel, LevelManager _levelManager)
        {
            movers = _movers; playerController = _playerController; bossMidAI = _bossMidAI;
            timer = _timer; projectileSpawner = _projectileSpawner; bossAskingPanel = _bossAskingPanel;
            itemSpawner = _itemSpawner; levelManager = _levelManager; healths = _healths;
        }

        public void Enter()
        {
            foreach(Mover m in movers)
            {
                m.enabled = false;
            }
            foreach(Health h in healths)
            {
                h.enabled = false;
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

            bossAskingPanel.gameObject.SetActive(true);

        }

        public void Exit()
        {
            foreach(Mover m in movers)
            {
                m.enabled = true;
            }
            foreach(Health h in healths)
            {
                h.enabled = true;
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

            bossAskingPanel.gameObject.SetActive(false);
        }

        public void Process()
        {
            
        }

    }
}