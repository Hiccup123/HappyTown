/***
* 功 能： N/A
* 描 述： 
*
* 日 期：6/7/2017
* ───────────────────────────────────
* 版 本：v1.0         作 者：LL
*
* Unity版本：5.5.0f3
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricStaticObject : MonoBehaviour
{
    [SerializeField]
    private float m_floorHeight;
    private float m_spriteLowerBound;
    private float m_spriteHalfWidth;
    private readonly float m_tan30 = Mathf.Tan(Mathf.PI / 5);

    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        m_spriteLowerBound = spriteRenderer.bounds.size.y * 0.5f;
        m_spriteHalfWidth = spriteRenderer.bounds.size.x * 0.5f;
    }


    private void LateUpdate()
    {
        if(!Application.isPlaying)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.y - m_spriteLowerBound + m_floorHeight) * m_tan30);
        }
    }


    private void OnDrawGizmos()
    {
        Vector3 floorHeightPos = new Vector3(transform.position.x,transform.position.y - m_spriteLowerBound + m_floorHeight,transform.position.z);
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(floorHeightPos + Vector3.left * m_spriteHalfWidth, floorHeightPos + Vector3.right * m_spriteHalfWidth);
    }
}

