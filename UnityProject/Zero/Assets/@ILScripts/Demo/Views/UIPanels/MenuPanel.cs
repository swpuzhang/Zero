﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zero;
using IL.Zero;

namespace IL.Demo
{
    class MenuPanel : AView
    {
        GameObject btnTap;
        Button btnHelp;


        protected override void OnDisable()
        {
            UIEventListener.Get(btnTap).onClick -= OnClickGo;
            btnHelp.onClick.RemoveListener(OpenHelpWin);
        }

        protected override void OnEnable()
        {
            UIEventListener.Get(btnTap).onClick += OnClickGo;
            btnHelp.onClick.AddListener(OpenHelpWin);
        }

        protected override void OnInit()
        {
            btnTap = GetChild("BtnTap").gameObject;
            btnHelp = GetChildComponent<Button>("BtnHelp");
        }

        public void OnClickGo(PointerEventData data)
        {
            Go();
        }

        void Go()
        {            
            StageMgr.Ins.SwitchASync<GameStage>();            
        }

        void OpenHelpWin()
        {
            UIWinMgr.Ins.OpenAsync<HelpWin>();
        }
    }
}
