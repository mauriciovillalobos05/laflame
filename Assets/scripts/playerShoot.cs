using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            ShootAtNearestEnemy();
            nextFireTime = Time.time + fireRate;
        }
    }


    void ShootAtNearestEnemy()
    {
        GameObject target = FindClosestEnemy();
        if (target != null)
        {
            Vector2 direction = (target.transform.position - firePoint.position).normalized;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

            // Le pasamos la dirección a la bala
            bullet.GetComponent<Bullet>().SetDirection(direction);
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float shortestDistance = Mathf.Infinity;
        Vector3 currentPos = firePoint.position;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, currentPos);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closest = enemy;
            }
        }

        return closest;
    }
}
