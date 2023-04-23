using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Scripts
{
    public class AsyncExamples : MonoBehaviour
    {
        private async void Awake()
        {
            new Thread(() =>
            {
                Thread.Sleep(1000); 
                Debug.Log("Thread 1");
            }).Start();
            
            // ThreadPool можно взять поток с пула, который уже создан
            
            // new Task(() =>
            // {
            //     Debug.Log("Task 1");
            // }).Start();
            
            
            await GetInt();
            //UniTask.Create(() => GetInt());
        }
        
        public async UniTask<int> GetInt()
        {
            transform.position = Vector3.back;

            UniTask.Delay(1000);
            
            return 87230404;
        }
    }
}