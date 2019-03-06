using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyLoader : MonoBehaviour
{
    public string folder;
    public Shader shader;
    [Tooltip("Defaults to MeshRenderer")]
    public string rendererType;
    public bool loadOnStart;

    // Start is called before the first frame update
    void Start()
    {
        if(loadOnStart) StartLoading();
    }

    public void StartLoading()
    {
        StartCoroutine(LoadGraphics());
    }

    // As it currently is adding a SkinnedMeshRenderer is not connecting mesh to correct places so it won't work properly
    IEnumerator LoadGraphics()
    {
        ResourceRequest meshRequest = Resources.LoadAsync<Mesh>(folder + "/inUse/model");
        while (!meshRequest.isDone)
        {
            yield return 0;
        }
        MeshFilter mf = gameObject.GetComponent<MeshFilter>();
        if (!mf) mf = gameObject.AddComponent<MeshFilter>();
        mf.mesh = meshRequest.asset as Mesh;

        Material mat;
        ResourceRequest resourceRequest = Resources.LoadAsync<Material>(folder + "/inUse/material");
        while (!resourceRequest.isDone)
        {
            yield return 0;
        }
        mat = resourceRequest.asset as Material;

        if (!mat) mat = new Material(shader);
        else mat.shader = shader;
        Renderer rend = gameObject.GetComponent<Renderer>();


        if (!rend)
        {
            Type t = GetRendererType(rendererType);

            if (t != null)
            {
                rend = gameObject.AddComponent(t) as Renderer;
            }
            else
            {
                rend = gameObject.AddComponent<MeshRenderer>();
            }
        }
        rend.material = mat;
    }

    // Quite inneffective but dead simple and works for a few types
    Type GetRendererType(string testable)
    {
        Type type = System.Type.GetType("UnityEngine." + testable + ", UnityEngine");
        return type;
    }
}
