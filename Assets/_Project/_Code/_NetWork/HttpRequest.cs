using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetWork
{
    public class HttpRequest : Singleton<HttpRequest>
    {
        public delegate void HttpCallBack(string info);

        #region Connect

        public void Connect(string url,Dictionary<string,string> infoDic,HttpCallBack successCallBack,HttpCallBack failCallBack)
        {
            Debug.Log(Time.realtimeSinceStartup + "  ||  url:" + url);

            StartCoroutine(HttpPost(url,infoDic,successCallBack,failCallBack));
        }

        private IEnumerator HttpGet(string url,HttpCallBack successCallBack,HttpCallBack failCallBack)
        {
            WWW www = new WWW(url);

            yield return www;
        }

        private IEnumerator HttpPost(string url,Dictionary<string,string> infoDic,HttpCallBack successCallBack,HttpCallBack failCallBack)
        {
            WWWForm wwwForm = new WWWForm();

            try
            {
                if(infoDic != null)
                {
                    foreach(KeyValuePair<string,string> pair in infoDic)
                    {
                        Debug.Log("Key:" + pair.Key + " || Value:" + pair.Value);

                        wwwForm.AddField(pair.Key, pair.Value);
                    }
                }
            }
            catch(System.Exception e)
            {
                Debug.Log("Post error:" + e);
            }

            WWW www = new WWW(url, wwwForm);

            yield return www;

            Debug.Log("HttpResponse:" + www.text);

            if(!string.IsNullOrEmpty(www.error))
            {
                Debug.Log("www.error:" + www.error + "  ||  url:" + url + "  ||  time:" + Time.realtimeSinceStartup);
                if(failCallBack != null)
                {
                    failCallBack(www.error);
                }
            }
            else
            {
                if(successCallBack != null)
                {
                    successCallBack(www.text);
                }
            }
        }

        #endregion
    }
}

