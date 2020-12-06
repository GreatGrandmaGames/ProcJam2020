using System;
using UnityEngine;

namespace Grandma.PF
{
    /// <summary>
    /// Parameters to define the rate of fire for a PF
    /// </summary>
    //The fields here are private, to allow this class to do some
    //pre-processing before being sent off to the PF
    [Serializable]
    public class FiringData
    {
        [Serializable]
        public struct Shot
        {
            [Tooltip("The number of projectiles launched in this shot")]
            public int NumberOfProjectiles;
        }

        [Serializable]
        public struct Burst
        {
            //The number of shots in the burst
            public int Count => Shots.Length;

            [Tooltip("The shots in the current burst")]
            public Shot[] Shots;
            [Tooltip("The time between shots for the current burst. Measured in seconds")]
            public float Time;
        }

        [Tooltip("The default time between shots. Measured in seconds")]
        public float BaseRate;

        //Separated out for clarity, since players can trigger the reload manually
        //and when we call this data, we have to reset the ammo count
        [SerializeField]
        public Burst ReloadingData;

        //N < reloadingData.N, otherwise the burst data will never be triggered
        [SerializeField]
        public Burst BurstData;

        public int AmmoCapacity
        {
            get
            {
                return ReloadingData.Count;
            }
        }

        public float ReloadTime
        {
            get
            {
                return ReloadingData.Time;
            }
        }
    }
}