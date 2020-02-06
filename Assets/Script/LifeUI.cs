using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    public PlayerController1 Player1;
    public PlayerController Player2;
    public LifePanel lifePanel1;
    public LifePanel lifePanel2;

    void Update()
    {
        lifePanel1.UpdateLife(Player1.Life());
        lifePanel2.UpdateLife(Player2.Life());
    }
}
