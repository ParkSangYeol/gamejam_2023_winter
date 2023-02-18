using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ExplosiveFactory : MonoBehaviour
{
    Vector3 deploymentPoint;
    float allottedTime;

    public ExplosiveFactory(Vector3 deploymentPoint)
    {
        this.deploymentPoint = deploymentPoint;
    }

    public float GetAllottedTime()
    {
        return allottedTime;
    }

    public abstract void DeployExplosive();
}
