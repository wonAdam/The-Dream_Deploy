using System.Collections;
using System.Collections.Generic;
using ADAM.Control;
using ADAM.Core;
using ADAM.Movement;
using ADAM.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ADAM.Phase
{
    public class State_Clear : IPhaseState
    {
        Mover[] movers;
        PlayerController playerController;
        BossMidAI bossMidAI;
        Timer timer;
        ProjectileSpawner projectileSpawner;
        ItemSpawner itemSpawner;
        CoverPanel coverPanel;
        LevelManager levelManager;
        string clearMessage = "Clear ! ";
        public State_Clear(Mover[] _movers, PlayerController _playerController, BossMidAI _bossMidAI, Timer _timer, ProjectileSpawner _projectileSpawner, 
                                ItemSpawner _itemSpawner, CoverPanel _coverPanel, LevelManager _levelManager)
        {
            movers = _movers; playerController = _playerController; bossMidAI = _bossMidAI;
            timer = _timer; projectileSpawner = _projectileSpawner; coverPanel = _coverPanel;
            itemSpawner = _itemSpawner; levelManager = _levelManager;
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
            coverPanel.GetComponent<Animator>().SetTrigger("Start");
            coverPanel.SetText(clearMessage);
        }

        public void Exit()
        {
            levelManager.LoadSceneByIndex(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void Process()
        {
            
        }

    }
}