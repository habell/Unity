using Learning.Scripts.Mechanics;
using Learning.Scripts.Other;
using LearnProject.Scripts.Interfaces;
using UnityEngine;

namespace Learning.Scripts.DamageSystem
{
    [RequireComponent(typeof(Rigidbody))]
    public class Health : DieSystem, IHealth
    {
        [SerializeField]
        private float _maxHealth;

        [SerializeField]
        private CharactersType _enemyType;

        [SerializeField]
        private bool _isPlayer;

        private float _amount;
        
        public bool IsPlayer { get; set; }

        public float MaxHealth => _maxHealth;
        
        public float Amount
        {
            get => _amount;
            set
            {
                _amount = Mathf.Clamp(value, 0, _maxHealth);
                if (_amount <= 0) Die(_enemyType);
            }
        }

        private void Awake()
        {
            if(TryGetComponent(out Player ply))
            {
                _amount = (int)ply.MaxHealth;
            }
            else
            {
                _amount = _maxHealth;
            }
            //_enemyDeathsText = (Text)GameObject.FindGameObjectWithTag("EnemyLeftTo").GetComponent(typeof(Text)); // sorry t_t
        }

        /// <summary>
        ///     Use Hurt(damage)
        /// </summary>
        /// <param name="damage"></param>
        public void Hurt(int damage)
        {
            print($"Oh no, i don't wanna die! I'm taking {damage} damage in my face((");
            Amount -= damage;
        }

        public void Heal(int healAmount)
        {
            print($"Ow yeah! My health is really well! Im taking: {healAmount} HP");
            Amount += healAmount;
        }

        /*
        private void Die()
        {
            if (gameObject.CompareTag("Enemy")) //This is a horrible crutch, I think there could be a way to call die()objects with some kind of custom method die I just don't know how to do it, it would be cool to do it with delegates, but I don't know how(
                if (_enemyDeathsText) 
                    _enemyDeathsText.EnemyLeftTo = (int.Parse(_enemyDeathsText.EnemyLeftTo) + 1).ToString(); 
            Die(_enemyType, gameObject);
        }
        */
    }
}