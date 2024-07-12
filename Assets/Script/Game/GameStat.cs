using Unity.Mathematics;

namespace Script.Game
{
    public struct GameStat
    {
        public static int Niveau;
        public static int NiveauHdv;

        public static int collecteur;
        public static int cabane;
        public static int maxCabane;
        public static int caserne;
        public static bool hasSpawnBat;
        public static int countSpawn;
        public static int countCabSpawn;
        public static int maxCollecteur;
        public static int maxCaserne;
        public static float3[] positionColl = new float3[10];
        public static float3[] positionCab = new float3[10];
        public static int level;
        public static bool startBattle;

        public static bool hasSpawn;
        public static bool levelHasSpawn;
    }
}
