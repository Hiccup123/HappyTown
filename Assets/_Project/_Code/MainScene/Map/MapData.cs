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

namespace MainCity
{
    public class MapBox
    {
        public int Row;         //行
        public int Column;      //列
        public Vector3 Pos;     //瓦片的本地坐标
        public int WorkId = -1;      //对应工位号  -1 代表没有关联工位
    }

	public class MapData {

        private int _Width;       //虚拟瓦片宽 84
        private int _Height;      //虚拟瓦片高 41
        private Vector3 _StartPos;//开始铺设瓦片的坐标

        private MapBox[,] _BoxGroup;

        public MapData ()
        {
            _Width = 84;
            _Height = 41;
            _StartPos = new Vector3(-875,-140);
            _BoxGroup = new MapBox[30,22];
            CreateMap();
        }

        void CreateMap()
        {
            for(int i = 0;i < _BoxGroup.GetLength(0);i ++)
            {
                for(int j = 0;j < _BoxGroup.GetLength(1);j ++)
                {
                    if(HaveBox(i,j))
                    {
                        MapBox mapBox = new MapBox();
                        mapBox.Row = i;
                        mapBox.Column = j;
                        mapBox.Pos = new Vector3(_StartPos.x + j * _Width / 2 + i * _Width / 2, _StartPos.y + j * _Height / 2 - i * _Height / 2);
                        _BoxGroup[i, j] = mapBox;
                    }
                }
            }

            for (int i = 0; i < _BoxGroup.GetLength(0); i++)
            {
                for (int j = 0; j < _BoxGroup.GetLength(1); j++)
                {
                    Debug.Log("[" + i + "," + "]:" + _BoxGroup[i,j]);
                }
            }
        }

        public bool HaveBox(int i,int j)
        {
            if (i == 0 && j == 20)
            {
                return true;
            }
            if (i <= 2 && j == 21)
            {
                return true;
            }
            if (i == 3 && j >= 17)
            {
                return true;
            }
            if (i >= 4 && i <= 5)
            {
                if ((j >= 17 && j <= 18) || (j >= 1 && j <= 14))
                {
                    return true;
                }
            }
            if (i >= 6 && i <= 14)
            {
                if (j >= 15 & j <= 18)
                {
                    return true;
                }
            }
            if (i >= 8 && i <= 14)
            {
                if (j >= 19 && j <= 20)
                {
                    return true;
                }
            }
            if (i >= 11 & i <= 20)
            {
                if (j >= 1 && j <= 13)
                {
                    return true;
                }
            }
            if (i == 16)
            {
                if (j >= 15 && j <= 20)
                {
                    return true;
                }
            }
            if (i >= 19 && i <= 20)
            {
                if (j >= 15 && j <= 20)
                {
                    return true;
                }
            }
            if (i >= 21 && (j == 17 || j == 18))
            {
                return true;
            }
            if ((j == 1 || j == 7 || j == 8 || j == 14) && i < 21)
            {
                return true;
            }

            return false;
        }
	}
}

