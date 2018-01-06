﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class LevelData : ScriptableObject {

    [System.Serializable]
    public class LevelSetting
    {
       

        public int exp;
        public int attack;
        public ParticleSystem hitEffect;

    }

    public LevelSetting[] levelSettings;


}