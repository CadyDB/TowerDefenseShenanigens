using UnityEngine;

public class Tower : MonoBehaviour
{
    private float range = 3f;
    private float fireRate = 1f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public GameObject fireTarget;
    private float fireCooldown = 0f;

    private int towerPrice = 1;

    public int TowerPrice
    {
        get { return towerPrice; }
        set { towerPrice = value; }
    }

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        Enemy target = FindBestTarget();

        if (target != null && fireCooldown <= 0f)
        {
            fireTarget = target.gameObject;
            Shoot(target);
            fireCooldown = 1f / fireRate;
        }
    }

    Enemy FindBestTarget()
    {
        Enemy[] enemies = GameObject.FindObjectsByType<Enemy>(FindObjectsInactive.Include, FindObjectsSortMode.InstanceID);
        Enemy best = null;
        float bestProgress = -1f;

        foreach (Enemy e in enemies)
        {
            float dist = Vector2.Distance(transform.position, e.transform.position);
            if (dist <= range)
            {
                /*
                if(e.currentWayPoint > bestProgress)
                {
                }
                */
                bestProgress = e.CurrentWayPoint;
                best = e;
            }
        }
        return best;
    }

    void Shoot(Enemy target)
    {
        GameObject p = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Projectile pr = p.GetComponent<Projectile>();
        pr.target = target.transform;

    }
}
