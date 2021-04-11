using Assets.Scripts.Application;
using Assets.Scripts.Domain.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Presentation.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        public float Velocity = 5f;
        private EnemyAIBussinessLogic enemyAIBussinessLogic;
        public GameObject Player { get; private set; }

        private void Awake()
        {
            Player = GameObject.FindGameObjectWithTag("Player");

            var enemyAIService = GetComponent<IEnemyAIService>();
            enemyAIBussinessLogic = new EnemyAIBussinessLogic(enemyAIService);
        }

        private void OnDrawGizmos() //Dibuja el area de efecto en el editor
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, enemyAIBussinessLogic?.GetRadiusOfView() ?? 0);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                enemyAIBussinessLogic.InteractWithPlayer();
            }
        }
    }
}