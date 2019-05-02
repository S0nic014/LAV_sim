using UnityEngine;
using UnityEngine.UI;

public class TargetBehaviour : MonoBehaviour
{
    public float health=100f;
    private float maxHealth;
    public GameObject turret;
    public GameObject destroyedModel;
    public GameObject explosionPrefab;
    public Image hpBar;

    private void Start() {
        maxHealth=health;
    }

    public void TakeDamage(float amount)
    {
        health-=amount;
        hpBar.fillAmount=health/maxHealth;

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
            turretRb.AddExplosionForce(2000f, deadPrefab.transform.position, 100f, 100f, ForceMode.Force);
            GameObject explosion = Instantiate( explosionPrefab ,deadPrefab.transform.position, deadPrefab.transform.rotation);
            Destroy(explosion, 10f);
        }

        Destroy(gameObject);
    }
}
