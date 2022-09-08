﻿using System.Collections.Generic;
using Global;
using Global.Base;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities.Event;

namespace SceneModule.SelectPack
{
    public class SelectPackScene : MonoBehaviour
    {
        [SerializeField] private TMP_Text goldText;
        [SerializeField] private Button backButton;
        [SerializeField] private LevelSelection levelSelection;

        private void Start()
        {
            levelSelection.SetCallback(OnPackSelect);
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(OnCloseButton);
            ChangeCoinText();
        }

        private void OnPackSelect()
        {
            SceneManager.LoadScene(Consts.SceneNames.SelectLevel);
        }

        private void OnCloseButton()
        {
            SceneManager.LoadScene(Consts.SceneNames.Home);
        }

        private void OnEnable()
        {
            EventManager.StartListening(Consts.EventsName.OnBought, UpdateCoin);
        }

        private void OnDisable()
        {
            EventManager.StopListening(Consts.EventsName.OnBought, UpdateCoin);
        }

        private void UpdateCoin(Dictionary<string, object> obj)
        {
            ChangeCoinText();
        }

        private void ChangeCoinText()
        {
            goldText.text = SaveData.Instance.gold.ToString();
        }
    }
}