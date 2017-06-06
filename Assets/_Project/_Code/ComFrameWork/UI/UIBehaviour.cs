/***
* 功 能： 向UIManager注册GameObject
* 描 述：  1.把控件Script注册到UIManager
*          2.可以直接查找物体，把物体本身注册到UIManager
*
* 日 期：6/6/2017
* ───────────────────────────────────
* 版 本：v1.0         作 者：LL
*
* Unity版本：5.5.0f3
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace UIFW
{
	public class UIBehaviour : MonoBehaviour {

        private void Awake()
        {
            UIManager.Instance.RegistGameObject(name, gameObject);
            //Debug.Log(this.name);
        }

        #region Button
        public void AddButtonListener(UnityAction action)
        {
            if(action != null)
            {
                Button btn = transform.GetComponent<Button>();
                btn.onClick.AddListener(action);
            }
        }

        public void RemoveButtonListener(UnityAction action)
        {
            if(action != null)
            {
                Button btn = transform.GetComponent<Button>();
                btn.onClick.RemoveListener(action);
            }
        }
        #endregion

        #region Toggle
        public void AddToggleListener(UnityAction<bool> action)
        {
            if (action != null)
            {
                Toggle toggle = transform.GetComponent<Toggle>();
                toggle.onValueChanged.AddListener(action);
            }
        }

        public void RemoveToggleListener(UnityAction<bool> action)
        {
            if (action != null)
            {
                Toggle toggle = transform.GetComponent<Toggle>();
                toggle.onValueChanged.RemoveListener(action);
            }
        }
        #endregion

        #region Slider
        public void AddSliderListener(UnityAction<float> action)
        {
            if(action != null)
            {
                Slider slider = transform.GetComponent<Slider>();
                slider.onValueChanged.AddListener(action);
            }
        }

        public void RemoveSliderListener(UnityAction<float> action)
        {
            if(action != null)
            {
                Slider slider = transform.GetComponent<Slider>();
                slider.onValueChanged.RemoveListener(action);
            }
        }
        #endregion

        #region Input
        public void AddInputListener(UnityAction<string> action)
        {
            if(action != null)
            {
                InputField input = transform.GetComponent<InputField>();
                input.onValueChanged.AddListener(action);
            }
        }
        #endregion
    }
}

