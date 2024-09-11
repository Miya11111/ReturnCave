using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator player_animator = default;

        private void Awake()
        {
            player_animator = GetComponent<Animator>();
        }

        private void Update()
        {
            
        }
    }

}
