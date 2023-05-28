﻿using System;
using DefaultNamespace;
using JetBrains.Annotations;
using States.Game_States;
using UnityEngine;
using UnityEngine.Events;
using Utils;
using Zenject;

namespace Player
{
    public class PlayerEntity : Entity
    {
        public UnityEvent healthBarChanged;
        [Inject] private SceneStateManager manager;
        [Inject] private GameOverState _gameOverState;
        
        private void Start()
        {
            CurrentHealth = MaxHealth;
        }

        public override void Die()
        {
            Destroy(gameObject);
            manager.SwitchState(_gameOverState);
        }

        public override void TakeDamage(float damage)
        {
            healthBarChanged?.Invoke();
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
                Die();
        }

        public override void Heal(float points)
        {
            healthBarChanged?.Invoke();
            CurrentHealth += points;
        }
    }
}