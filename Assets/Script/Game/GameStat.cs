using Unity.Mathematics;

namespace Script.Game
{
    public struct GameStat
    {
        public static int Niveau;
        public static int NiveauHdv;

        public static int collecteur;
        public static int caserne;
        public static bool hasSpawnBat;
        public static int countSpawn;
        public static int maxCollecteur;
        public static int maxCaserne;
        public static float3[] positionColl = new float3[10];
        public static float3[] positionCas = new float3[10];
    }
}
