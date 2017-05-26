/***
* 功 能： 事件枚举
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

public class EventEnums
{
    public const string FIGHTSTARTUP = "fightStartUp";  //战斗页面启动

    //选择模式
    public const string CREATE_ROOM = "createRoom";     //创建一个工作室
    public const string JOIN_ROOM = "joinRoom";         //加入一个工作室
    public const string BACKTOMAIN = "bactToMain";      //返回主页面

    //战前准备
    public const string CHANGE_SKILL = "changeSkill";   //更换技能
    public const string REMOVE_PLAYER = "removePlayer"; //移除玩家
    public const string START_FIGHT = "startFight";     //开始研发
    public const string CHANGE_ROLE = "changeRole";     //更换角色
    public const string GET_READY = "getReady";         //准备游戏

    //添加成员
    public const string INVITE_PLAYER = "invitePlayer"; //邀请玩家
}

