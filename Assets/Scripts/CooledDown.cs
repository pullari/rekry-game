using System;
using UnityEngine;

public class CooledDown : MonoBehaviour
{
    public float cooldown;
    public Action cooledDownAction;
    public bool shouldInvoke;

    private float cooldownStart;

    public CooledDown SetAction(Action func)
    {
        cooledDownAction = func;
        return this;
    }

    public CooledDown SetCooldown(float cd)
    {
        cooldown = cd;
        return this;
    }

    void Start()
    {
        cooldownStart = cooldown;
        cooldown = -1;
    }

    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        if (cooldown <= 0 && shouldInvoke)
        {
            cooledDownAction.Invoke();
            cooldown = cooldownStart;
        }
    }
}
