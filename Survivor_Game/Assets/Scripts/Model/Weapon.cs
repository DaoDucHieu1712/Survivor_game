using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace Assets.Scripts.Model {
    internal class Weapon {
        public GameObject bullet { get; set; }
        public float Dame { get; set; }
        public float SpawnDelay { get; set; }
        public float Speed { get; set; }

        public Weapon(GameObject gameObject, float dame, float spawnDelay, float speed)
        {
            bullet = gameObject;
            Dame = dame;
            SpawnDelay = spawnDelay;
            Speed = speed;
        }


    }
}
