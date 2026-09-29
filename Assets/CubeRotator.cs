using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    [SerializeField] private float radius = 10f;
    [SerializeField] private int count = 10;
    [SerializeField] private float speed = 10f;
    [SerializeField] private bool evenly;
    [SerializeField] private GameObject prefab;

    private Transform[] cubes;
    private float angle = 0f;

    private void Awake()
    {
        if (prefab == null) return;
        cubes = new Transform[count];
        var index = 0;
        while (index < count)
        {
            cubes[index] = Instantiate(prefab).transform;
            index++;
        }
    }

    private void Update()
    {
        if (cubes == null || cubes.Length == 0) return;
        angle += speed * Time.deltaTime;
        var step = evenly ? (360f / cubes.Length) : 30f;
        var current = angle;

        for (var i = 0; i < cubes.Length; i++)
        {
            if (cubes[i] == null) continue;
            var rad = current * Mathf.Deg2Rad;
            var offset = new Vector3(Mathf.Cos(rad) * radius, 0f, Mathf.Sin(rad) * radius);
            cubes[i].position = transform.position + offset;
            current += step;
        }
    }
}
