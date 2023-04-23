using UnityEngine;
using VContainer;

namespace Scripts.Utils
{
    public static partial class NpcContainerBuilderExtensions
    {
        public static void RegisterNpcFactories(this IContainerBuilder builder)
        {
            // Регистрирует такой тип: Func<Zombie>
            RegisterFactory<Zombie>(builder, "Zombie");
            RegisterFactory<Kaban>(builder, "Kaban");
        }

        private static void RegisterFactory<TNpcComponent>(IContainerBuilder builder, string prefab)
            where TNpcComponent : MonoBehaviour
        {
            builder.RegisterFactory<float, TNpcComponent>(
                container => { return size => CreateNpc<TNpcComponent>(container, prefab, size); },
                Lifetime.Scoped);
        }

        private static TNpcComponent CreateNpc<TNpcComponent>(IObjectResolver container, 
            string resourcesPrefabName, 
            float size)
            where TNpcComponent : MonoBehaviour
        {
            var prefab = Resources.Load<TNpcComponent>(resourcesPrefabName);
            var npc = GameObject.Instantiate(prefab);
            // задать рандомную позицию
            npc.transform.position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            npc.transform.localScale *= size;
            container.Inject(npc);
            return npc;
        }
    }
}