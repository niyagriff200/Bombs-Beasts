using UnityEngine;

public class ZoomerHealth : Health
{
    protected override void Die()
    {

        // Remove from activeEnemies and destroy—UFOs use DeathTarget
        DeathTarget target = GetComponent<DeathTarget>();
        if (target != null)
        {
            target.Die(); // Handles removal and destruction
        }
    }

}
