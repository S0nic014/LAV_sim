using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    public float health=100f;
    public GameObject turret;
    public GameObject destroyedModel;

    public void TakeDamage(float amount)
    {
        health-=amount;
        if (health<=0f)
        {
            Die();
        }
    }

    void Die()
    {
        
        if (destroyedModel!=null && turret!=null)
        {
            GameObject deadPrefab = Instantiate(destroyedModel, gameObject.transform.position, gameObject.transform.rotation);
            Vector3 turretPosition= new Vector3(deadPrefab.transform.position.x, deadPrefab.transform.position.y+1f, deadPrefab.transform.position.z);
            GameObject deadTurret = Instantiate(turret, turretPosition, deadPrefab.transform.rotation);
            Rigidbody turretRb=deadTurret.GetComponent<Rigidbody>();
            turretRb.AddForce(200, 2000, 200);
            //turretRb.AddExplosionForce
        }

        Destroy(gameObject);
    }
}
