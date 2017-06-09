/***
* 功 能： N/A
* 描 述： 
*
* 日 期：6/9/2017
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
	public interface IObstacle
    {
        
	}

    //boss组
    public class BossObstacle : IObstacle
    {

    }

    //工作组
    public class WorkObstacle : IObstacle
    {
        public int _GroupId { get; private set; }

        public WorkObstacle(int groupId)
        {
            _GroupId = groupId;
        }
    }

    //前台组
    public class DoorObstacle : IObstacle
    {

    }

    //休息组
    public class RestObstacle : IObstacle
    {

    }
}

