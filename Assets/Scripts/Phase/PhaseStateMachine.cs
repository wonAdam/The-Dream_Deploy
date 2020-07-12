﻿using System.Collections;
using System.Collections.Generic;
using ADAM.Combat;
using ADAM.Control;
using ADAM.Core;
using ADAM.Movement;
using ADAM.UI;
using DG.Tweening;
using UnityEngine;

namespace ADAM.Phase
{
    // 스테이지 내의 상태(Phase)에 대해 책임집니다.
    public class PhaseStateMachine : MonoBehaviour
    {
        public enum PHASE_STATE{
            START, BATTLE, CLEAR, ASKING, GAMEOVER, ToMain
        }
        public PHASE_STATE curr_en_PhaseState = PHASE_STATE.START;
        Mover[] movers;
        Health[] healths;
        PlayerController playerController;
        BossMidAI bossMidAI;
        Timer timer;
        ProjectileSpawner projectileSpawner;
        ItemSpawner itemSpawner;
        LevelManager levelManager;
        CoverPanel coverPanel;
        [SerializeField] private BossAskingPanel bossAskingPanel;
        [SerializeField] public GameOverPanel gameOverPanel;
        [SerializeField] public string sceneNameToLoadAfterClear;
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
            gameOverPanel = FindObjectOfType<GameOverPanel>();
            levelManager.gameOverPanel = gameOverPanel;
            gameOverPanel.gameObject.SetActive(false);

            SaveCurrStageProgress();

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
            if(curr_en_PhaseState != PHASE_STATE.BATTLE && curr_en_PhaseState != PHASE_STATE.ASKING) return;   
            AudioSource[] ASs = FindObjectsOfType<AudioSource>();
            foreach(AudioSource a in ASs){
                a.DOFade(0f, 1f);
            }

            ChangePhaseState(new State_Clear(movers, healths, playerController, bossMidAI, timer, projectileSpawner, itemSpawner,coverPanel, levelManager));
            curr_en_PhaseState = PHASE_STATE.CLEAR;
        }

        private void SaveCurrStageProgress()
        {
            SaveData saveData = SaveMgr.LoadData();
            saveData.stageProgress = levelManager.StageIndex;
            SaveMgr.SaveData(saveData);
        }

        public void StateToAsking(){
            if(curr_en_PhaseState == PHASE_STATE.ASKING) return;
            
            ChangePhaseState(new State_Asking(movers, healths, playerController, bossMidAI, timer, projectileSpawner, itemSpawner, bossAskingPanel, levelManager));
            curr_en_PhaseState = PHASE_STATE.ASKING;
        }

        public void StateToPlayerDead(){
            ChangePhaseState(new State_PlayerDead(movers, healths, playerController, bossMidAI, timer, projectileSpawner, itemSpawner, gameOverPanel, levelManager));
            curr_en_PhaseState = PHASE_STATE.GAMEOVER;
            AudioSource[] ASs = FindObjectsOfType<AudioSource>();
            foreach(AudioSource a in ASs){
                a.DOFade(0f, 1f);
            }            
        }

        public void StateToToMain(){
            ChangePhaseState(new State_ToMain(movers, healths, playerController, bossMidAI, timer, projectileSpawner, itemSpawner, coverPanel, levelManager));
            curr_en_PhaseState = PHASE_STATE.ToMain;
        }

    }

}
