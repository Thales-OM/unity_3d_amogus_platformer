using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Switch : MonoBehaviour
{
    public Camera cam_side;
    public Camera cam_fpv;
    public GameObject Main_Body;
    public GameObject Hands;
    private SkinnedMeshRenderer[] Main_Body_Meshes;
    
    UnityEngine.Rendering.ShadowCastingMode switch_shadow_render(UnityEngine.Rendering.ShadowCastingMode last_state)
    {
        if (last_state == UnityEngine.Rendering.ShadowCastingMode.On)
        {
            return UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly; //думаю можно как-то локально хранить чтобы не вызывать каждый раз
        }
        else
        {
            return UnityEngine.Rendering.ShadowCastingMode.On;
        }
    }
    void Start()
    {
        cam_side.enabled = true;
        cam_fpv.enabled = false; //возможно стоит делать не enabled, а active т.к. быстрее
        Main_Body_Meshes = Main_Body.GetComponentsInChildren<SkinnedMeshRenderer>();

        foreach (SkinnedMeshRenderer mesh in Main_Body_Meshes)
        {
            mesh.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }

        Hands.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            cam_side.enabled = !cam_side.enabled;
            cam_fpv.enabled = !cam_fpv.enabled;

            Hands.SetActive(!Hands.activeSelf); //аттрибут показывает активность независимо от родительского объекта, может показать true при еактивном родителе
            
            foreach (SkinnedMeshRenderer mesh in Main_Body_Meshes)
            {
                mesh.shadowCastingMode = switch_shadow_render(mesh.shadowCastingMode); //звучит неэффективно при большем числе детей
            }
        }
    }
}
