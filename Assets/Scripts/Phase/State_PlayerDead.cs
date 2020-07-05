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
    public class State_PlayerDead : IPhaseState
    {
        Mover[] movers;
        Health[] healths;
        PlayerController playerController;
        BossMidAI bossMidAI;
        Timer timer;
        ProjectileSpawner projectileSpawner;
        ItemSpawner itemSpawner;
        GameObject gameOverPanel;
        LevelManager levelManager;
        string clearMessage = "Clear ! ";
        public State_PlayerDead(Mover[] _movers, Health[] _healths, PlayerController _playerController, BossMidAI _bossMidAI, Timer _timer, ProjectileSpawner _projectileSpawner, 
                                ItemSpawner _itemSpawner, GameObject _gameOverPanel, LevelManager _levelManager)
        {
            movers = _movers; playerController = _playerController; bossMidAI = _bossMidAI;
            timer = _timer; projectileSpawner = _projectileSpawner; gameOverPanel = _gameOverPanel;
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
        }

        public void Exit()
        {
            
        }

        public void Process()
        {
            
        }

    }
}