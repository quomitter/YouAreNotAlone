using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pie : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Score.Instance.AddPie();
        Destroy(this.gameObject, 0.2f);
    }
}
