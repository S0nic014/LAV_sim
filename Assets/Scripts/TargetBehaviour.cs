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
        }

        Destroy(gameObject);
    }
}
