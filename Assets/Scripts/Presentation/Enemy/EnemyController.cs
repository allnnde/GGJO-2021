using Application;
using Infrastructure.Enemy;
using UnityEngine;

namespace Presentation.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private EnemyAIBussinessLogic enemyAIBussinessLogic;
        public float Velocity = 5f;
        public GameObject Player { get; private set; }

        private void Awake()
        {
            Player = GameObject.FindGameObjectWithTag("Player");

            var enemyAIService = GetComponent<EnemyAIService>();
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