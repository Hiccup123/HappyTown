/***
* 功 能： 战斗模块门面
* 描 述： 
*
* 日 期：5/26/2017
* ───────────────────────────────────
* 版 本：v1.0         作 者：LL
*
* Unity版本：5.5.0f3
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using UIForm;

namespace Fight
{
	public class FightFacade : Facade {

		public new static IFacade Instance
        {
            get
            {
                if(m_instance == null)
                {
                    lock(m_staticSyncRoot)
                    {
                        if(m_instance == null)
                        {
                            Debug.Log("FightFacade");
                            m_instance = new FightFacade();
                        }
                    }
                }

                return m_instance;
            }
        }

        protected FightFacade()
        {

        }

        static FightFacade()
        {

        }

        //战斗页面启动
        public void FightStartUp(BaseUIForms uiForm)
        {
            SendNotification(EventEnums.FIGHTSTARTUP,uiForm);
        }

        protected override void InitializeController()
        {
            base.InitializeController();
            RegisterCommand(EventEnums.FIGHTSTARTUP, typeof(FightStartUpCommand));
        }
    }
}

