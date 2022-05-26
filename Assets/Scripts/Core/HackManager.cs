using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HackManager : Singleton<HackManager>
{
    public void PrepareHackAttack()
    {
        int porcentajeRandom = Random.Range(20, 41);
        
        EconomyManager.Instance.ModifyPlayerCash(-(EconomyManager.Instance.CurrentPlayerCash*porcentajeRandom)/100);
        
        NewsDisplay.Instance.SetText("¡Te han hackeado, y se han robado un " + porcentajeRandom + "% de tu dinero disponible, guarda algo en el banco para protegerlo!");
    }

}
