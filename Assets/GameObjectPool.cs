using Scenes;
using UnityEngine;

public class GameObjectPool<T> : ObjectPool<T> where T : MonoBehaviour
{

    #region Consructors

    public GameObjectPool(
        T prefab,
        int preloadCount
    ) : base(() => Preload(prefab), GetAction, ReturnAction, preloadCount)
    {
    }

    #endregion

    #region Public Methods

    public static T Preload(T prefab) => Object.Instantiate(prefab);
    public static void GetAction(T @object) => @object.gameObject.SetActive(true);
    public static void ReturnAction(T @object) => @object.gameObject.SetActive(false);

    #endregion

}