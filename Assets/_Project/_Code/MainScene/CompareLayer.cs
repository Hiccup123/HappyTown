/***
* 功 能： N/A
* 描 述： 
*
* 日 期：6/5/2017
* ───────────────────────────────────
* 版 本：v1.0         作 者：LL
*
* Unity版本：5.5.0f3
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainCity
{
	public class CompareLayer : MonoBehaviour {

        public GameObject[] _SortList = new GameObject[] { };
        public GameObject _Target;
        public GameObject _change;

        private float _Time = 0;
        private float _RefreshTime = 0.1f;

        private void Start()
        {
            //for (int i = 0;i < _SortList.Length;i ++)
            //{
            //    CanvasRenderer render2 = _SortList[i].GetComponent<CanvasRenderer>();
            //    //Debug.Log("relativeDepth:" + render2.relativeDepth);
            //    //Debug.Log("absoluteDepth:" + render2.absoluteDepth);
            //    Debug.Log(_SortList[i].name + ":" + _SortList[i].transform.GetSiblingIndex());
            //}

            //_Target.transform.SetSiblingIndex(_change.transform.GetSiblingIndex());

            //for (int i = 0; i < _SortList.Length; i++)
            //{
            //    CanvasRenderer render2 = _SortList[i].GetComponent<CanvasRenderer>();
            //    //Debug.Log("relativeDepth:" + render2.relativeDepth);
            //    //Debug.Log("absoluteDepth:" + render2.absoluteDepth);
            //    Debug.Log(_SortList[i].name + ":" + _SortList[i].transform.GetSiblingIndex());
            //}
        }

        private void LateUpdate()
        {
            //Debug.Log("LateUpdate");
            RefreshLayer();
            //_Time += Time.deltaTime;
            //if (_Time > _RefreshTime)
            //{
            //    _Time = 0;
            //    //Refresh
            //    RefreshLayer();
            //}
        }

        void RefreshLayer()
        {
            for(int i = 0;i < _SortList.Length;i ++)
            {
                if(_Target.transform.position.y > _SortList[i].transform.position.y)
                {
                    if(_Target.transform.GetSiblingIndex() > _SortList[i].transform.GetSiblingIndex())
                    {
                        _Target.transform.SetSiblingIndex(_SortList[i].transform.GetSiblingIndex());
                    }
                    
                    i = 0;
                    break;
                }
                else
                {
                    _Target.transform.SetSiblingIndex(_SortList[i].transform.GetSiblingIndex() + 1);
                }
            }
        }
    }
}

