/***
* 功 能： N/A
* 描 述： 
*
* 日 期：6/8/2017
* ───────────────────────────────────
* 版 本：v1.0         作 者：LL
*
* Unity版本：5.5.0f3
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFW;
using UnityEngine.UI;

namespace MainCity
{
	public class WorkerManager : MonoBehaviour {

        public GameObject _MapBox;

        private GameObject[,] _BoxGroup;

        private List<GameObject> _CanWalkList;

        private void Awake()
        {
            _BoxGroup = new GameObject[25,22];
            _CanWalkList = new List<GameObject>();

            CreateMap();
        }

        void CreateMap()
        {
            float boxWidth = _MapBox.GetComponent<Image>().preferredWidth + 4;  //80
            float boxHeight = _MapBox.GetComponent<Image>().preferredHeight;    //41 
            Debug.Log("boxWidth:" + boxWidth);
            Debug.Log("boxHeight:" + boxHeight);

            for (int i = 0;i < _BoxGroup.GetLength(0);i ++)
            {
                for(int j = 0;j < _BoxGroup.GetLength(1);j ++)
                {
                    float x = _MapBox.transform.localPosition.x + j * boxWidth / 2 + i * boxWidth / 2;
                    float y = _MapBox.transform.localPosition.y + j * boxHeight / 2 - i * boxHeight / 2;

                    GameObject mapObx = Instantiate(_MapBox) as GameObject;
                    mapObx.SetActive(true);
                    mapObx.transform.parent = _MapBox.transform.parent;
                    mapObx.transform.localPosition = new Vector3(x,y,0);
                    mapObx.transform.localScale = Vector3.one;
                    mapObx.transform.localRotation = _MapBox.transform.localRotation;
                    _BoxGroup[i, j] = mapObx;
                    mapObx.name = "(" + i + "," + j + ")";
                    UnityHelper.GetChildNodeComponentScript<Text>(mapObx, "Text").text = "(" + i + "," + j + ")";

                    if (i == 0 && j == 20)
                    {
                        mapObx.GetComponent<Image>().color = Color.red;
                    }
                    if (i <= 2 && j == 21)
                    {
                        mapObx.GetComponent<Image>().color = Color.red;
                    }
                    if (i == 3 && j >= 17)
                    {
                        mapObx.GetComponent<Image>().color = Color.red;
                    }
                    if (i >= 4 && i <= 5)
                    {
                        if ((j >= 17 && j <= 18) || (j >= 1 && j <= 14))
                        {
                            mapObx.GetComponent<Image>().color = Color.red;
                        }
                    }
                    if(i >= 6 && i <= 14)
                    {
                        if(j >= 15 & j <= 18)
                        {
                            mapObx.GetComponent<Image>().color = Color.red;
                        }
                    }
                    if(i >= 8 && i <= 14)
                    {
                        if(j >= 19 && j <= 20)
                        {
                            mapObx.GetComponent<Image>().color = Color.red;
                        }
                    }
                    if(i >= 11 & i <= 20)
                    {
                        if(j >= 1 && j <= 13)
                        {
                            mapObx.GetComponent<Image>().color = Color.red;
                        }
                    }
                    if(i == 16)
                    {
                        if(j >= 15 && j <= 20)
                        {
                            mapObx.GetComponent<Image>().color = Color.red;
                        }
                    }
                    if(i >= 19 && i <= 20)
                    {
                        if(j >= 15 && j <= 20)
                        {
                            mapObx.GetComponent<Image>().color = Color.red;
                        }
                    }
                    if(i == 21 && (j == 17 || j == 18))
                    {
                        mapObx.GetComponent<Image>().color = Color.red;
                    }
                    if ((j == 1 || j == 7 || j == 8 || j == 14) && i != 21)
                    {
                        mapObx.GetComponent<Image>().color = Color.red;
                    }
                }
            }
        }
    }
}

