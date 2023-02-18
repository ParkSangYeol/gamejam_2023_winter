using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButtonFactory : ExplosiveFactory
{
    public CharacterButtonFactory(Vector3 deploymentPlace) : base(deploymentPlace) {}

    public override void DeployExplosive()
    {
        return;
    }
}
