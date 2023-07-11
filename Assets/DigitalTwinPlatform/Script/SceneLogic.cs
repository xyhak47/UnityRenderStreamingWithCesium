using UnityEngine;
using UnityEngine.Events;


public enum SceneType
{
    Earth,
    EarthCesium,
    Factory,
    City,
}



public class SceneLogic : MonoBehaviour, ISceneLogic
{
    [HideInInspector] public UnityEvent OnEnter = new UnityEvent();
    [HideInInspector] public UnityEvent OnExit = new UnityEvent();

    public SceneType type;

    private void Start()
    {
    }



    public virtual void Enter()
    {
        gameObject.SetActive(true);

        OnEnter.Invoke();
    }

    public virtual void Exit()
    {
        gameObject.SetActive(false);

        OnExit.Invoke();
    }
}
