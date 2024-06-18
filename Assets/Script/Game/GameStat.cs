using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public struct GameStat
{
    public static int Niveau;
    public static int NiveauHdv;

    public static int collecteur;
    public static float3[] positionColl = new float3[10];
}
