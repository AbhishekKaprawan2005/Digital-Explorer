using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Seb.Meshing;

public class LodMeshLoader : MonoBehaviour
{
	public TextAsset meshFileHighRes;
	public TextAsset meshFileLowRes;

	public Material mat;
	public Material lowResMat;
	public bool useStaticBatching;
	public bool loadOnStart;
	public SimpleLodSystem lodSystem;
    public GameObject player;
    public static bool GlobeLoaded = false;

    IEnumerator Start()
        {
            player.SetActive(false);

            if (loadOnStart)
                Load();

            yield return new WaitForSeconds(2f);

            Physics.SyncTransforms();

            player.SetActive(true);
        }
    

	public void Load()
	{
		MeshRenderer[] highResRenderers = CreateRenderers(meshFileHighRes, mat);

		MeshRenderer[] lowResRenderers = CreateRenderers(meshFileLowRes, lowResMat);
        

        Physics.SyncTransforms();

        for (int i = 0; i < highResRenderers.Length; i++)
		{
			lodSystem.AddLOD(highResRenderers[i], lowResRenderers[i]);
		}
        //Debug.Log("Mesh Filters: " + GetComponentsInChildren<MeshFilter>().Length);
        //Debug.Log("Mesh Colliders: " + GetComponentsInChildren<MeshCollider>().Length);
        Physics.SyncTransforms();
        GlobeLoaded = true;

        Debug.Log("Globe Loaded");
        Debug.Log("Mesh Colliders = " + GetComponentsInChildren<MeshCollider>().Length);
    }
 
    MeshRenderer[] CreateRenderers(TextAsset loadFile, Material material)
	{
		SimpleMeshData[] meshData = MeshSerializer.BytesToMeshes(loadFile.bytes);
		MeshRenderer[] meshRenderers = new MeshRenderer[meshData.Length];
		GameObject[] allObjects = new GameObject[meshData.Length];


		for (int i = 0; i < meshRenderers.Length; i++)
		{
			var renderObject = MeshHelper.CreateRendererObject(meshData[i].name, meshData[i], material, parent: transform, gameObject.layer);

			meshRenderers[i] = renderObject.renderer;
			allObjects[i] = renderObject.gameObject;

			if (useStaticBatching)
			{
				meshRenderers[i].gameObject.isStatic = true;
			}
		}

		if (useStaticBatching)
		{
			StaticBatchingUtility.Combine(allObjects, gameObject);
		}

		return meshRenderers;
	}

}
