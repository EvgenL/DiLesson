using UnityEngine;
using VContainer;

namespace Scripts
{
    public class Zombie : MonoBehaviour
    {
        [Inject] private readonly Player _player;
        [Inject] private readonly DbConnection _dbConnection;
        
        private void Start()
        {
            Debug.Log(_player);
            Debug.Log(_dbConnection);
        }
    }
}