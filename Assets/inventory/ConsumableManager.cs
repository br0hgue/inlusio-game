using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableManager : MonoBehaviour
{

    #region singleton
        public static ConsumableManager instance;
        private void Awake()
        {
            instance = this;
        }
    #endregion 

    public PlayerStats playerstat;

        public void Consume(int healthmod){
            playerstat.TakeDamage(-healthmod);
        }
}
