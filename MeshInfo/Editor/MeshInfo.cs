using UnityEngine;
using UnityEditor;

public class MeshInfoWithIconsEditor : EditorWindow
{
    // Variables pour stocker les icônes
    private static GUIContent meshIcon;
    private static GUIContent vertexIcon;
    private static GUIContent submeshIcon;
    private static GUIContent triangleIcon;

    [MenuItem("Window/Mesh Info")]
    public static void ShowWindow()
    {
        GetWindow<MeshInfoWithIconsEditor>("Mesh Info");
        
        // On charge quelques icônes intégrées à Unity
        // Vous pouvez changer les noms pour d'autres icônes, consultez la doc ou un guide en ligne.
        meshIcon     = EditorGUIUtility.IconContent("d_Mesh Icon");
        vertexIcon   = EditorGUIUtility.IconContent("d_Profiler.NetworkOperations");
        submeshIcon  = EditorGUIUtility.IconContent("d_Mesh Icon");
        triangleIcon = EditorGUIUtility.IconContent("d_FilterByLabel");
    }

    private void OnGUI()
    {
        Mesh selectedMesh = null;

        // 1) Vérifier si c'est un GameObject dans la scène
        if (Selection.activeGameObject != null)
        {
            // Essayer de trouver un MeshFilter
            MeshFilter mf = Selection.activeGameObject.GetComponent<MeshFilter>();
            if (mf != null && mf.sharedMesh != null)
            {
                selectedMesh = mf.sharedMesh;
            }
            // Sinon, essayer de trouver un SkinnedMeshRenderer
            else
            {
                SkinnedMeshRenderer smr = Selection.activeGameObject.GetComponent<SkinnedMeshRenderer>();
                if (smr != null && smr.sharedMesh != null)
                {
                    selectedMesh = smr.sharedMesh;
                }
            }
        }
        // 2) Vérifier si l’objet sélectionné est directement un asset Mesh
        else if (Selection.activeObject is Mesh meshAsset)
        {
            selectedMesh = meshAsset;
        }

        // Si on a trouvé un Mesh
        if (selectedMesh != null)
        {
            // Nom du Mesh
            EditorGUILayout.LabelField(
                new GUIContent(
                    "Nom du Mesh : " + selectedMesh.name,
                    meshIcon.image
                )
            );

            // Nombre de vertices
            EditorGUILayout.LabelField(
                new GUIContent(
                    "Nombre de vertices : " + selectedMesh.vertexCount,
                    vertexIcon.image
                )
            );

            // Nombre de sub-meshes
            EditorGUILayout.LabelField(
                new GUIContent(
                    "Nombre de sub-meshes : " + selectedMesh.subMeshCount,
                    submeshIcon.image
                )
            );

            // Triangles (total)
            int totalTriangles = selectedMesh.triangles.Length / 3;
            EditorGUILayout.LabelField(
                new GUIContent(
                    "Triangles (total) : " + totalTriangles,
                    triangleIcon.image
                )
            );

            // Triangles par sub-mesh
            for (int i = 0; i < selectedMesh.subMeshCount; i++)
            {
                int[] tris = selectedMesh.GetTriangles(i);
                int subMeshTriangleCount = tris.Length / 3;
                EditorGUILayout.LabelField(
                    new GUIContent(
                        $"   - Submesh : {i}",
                        triangleIcon.image
                    )
                );
            }
        }
        else
        {
            // Message si aucun Mesh n'a été trouvé
            EditorGUILayout.HelpBox(
                "Sélectionnez un GameObject (MeshFilter ou SkinnedMeshRenderer) ou un asset Mesh pour afficher ses informations.",
                MessageType.Info
            );
        }
    }
}