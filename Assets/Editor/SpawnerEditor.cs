using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PeopleSpawner))]
public class SpawnerEditor : Editor
{
    [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NotInSelectionHierarchy)]
    public static void RenderCustomGizmo(PeopleSpawner spawner, GizmoType gizmo)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(spawner.transform.position, 0.5f);
    }
}
