using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 2f;
    private int health = 1;
    public Transform[] waypoints;

    private int currentWayPoint = 0;

    public int CurrentWayPoint
    {
        get { return currentWayPoint; }
        set {  currentWayPoint = value; }
    }
    public int Health
    {
        get {  return health;   }
        set { health = value; }
    }
    void Update()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        Transform target = waypoints[currentWayPoint];
        Vector3 dir = (target.position - transform.position).normalized;

        transform.position += dir * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            currentWayPoint++;

            if (currentWayPoint >= waypoints.Length)
            {
                HealthManager.Instance.UpdateHealth(-1);
                Destroy(gameObject);
            }
        }
    }
}
