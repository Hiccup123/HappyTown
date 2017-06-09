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
	public interface IAction
    {
        void Excute();
	}

    public class Idle : IAction
    {
        public void Excute()
        {

        }
    }

    public class Walk : IAction
    {
        public void Excute()
        {

        }
    }

    public class Working : IAction
    {
        public void Excute()
        {

        }
    }
}

