using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UIForm
{
    public class JsonAnalysisExp : Exception
    {
        public JsonAnalysisExp() : base() { }
        public JsonAnalysisExp(string exceptionMsg) : base(exceptionMsg) { }
    }
}

