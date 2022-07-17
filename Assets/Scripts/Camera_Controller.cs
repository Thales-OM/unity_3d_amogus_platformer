using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Camera_Controller : MonoBehaviour
{
    public float min_x_rot, max_x_rot;
    public Camera cam_side, cam_fpv;
    public Player player;
    private Camera enabled_camera;
    private string current_camera_mode; 
    
    private void Start()
    {
        cam_side.enabled = true;
        cam_fpv.enabled = false; //возможно стоит делать не enabled, а active т.к. быстрее
        enabled_camera = cam_side;
        current_camera_mode = "Side";
        player.Set_Camera_Mode(current_camera_mode);
    }

    public string Get_Current_Mode()
    {
        return current_camera_mode;
    }

    public Camera Get_Enabled_Camera()
    {
        return enabled_camera;
    }
 
    public int Enable_Camera(Camera camera) //переключает на данную камеру, возвращает 0 в случае успеха, 1 иначе
    {
        if (camera == cam_side)
        {
            cam_side.enabled = true;
            cam_fpv.enabled = false;
            enabled_camera = cam_side;
            current_camera_mode = "Side";
            player.Set_Camera_Mode(current_camera_mode);
            return 0;
        }
        else if(camera == cam_fpv)
        {
            cam_fpv.enabled = true;
            cam_side.enabled = false;
            enabled_camera = cam_fpv;
            current_camera_mode = "FPV";
            player.Set_Camera_Mode(current_camera_mode);
            return 0;
        }
        return 1;
    }
    public float cast_rotation(float rotation)
    {   
        float result = rotation;
        if (rotation > 180)
        {
            while(result > 180)
                result-=360;
            return result;
        }
        else if(rotation <= -180)
        {
            while(result <= -180)
                result+=360;
            return result;
        }
        return result;
    }
    public void fpv_rotate_x(float degrees)
    {   
        float result = cast_rotation(enabled_camera.transform.localRotation.eulerAngles.x + degrees);
        if (result >= min_x_rot & result <= max_x_rot)
        {
            //Debug.Log(enabled_camera.transform.localRotation.eulerAngles.x);
            //Debug.Log(enabled_camera.transform.localRotation.eulerAngles.x + degrees >= min_x_rot & enabled_camera.transform.localRotation.eulerAngles.x + degrees <= max_x_rot);
            Debug.Log(enabled_camera.transform.localRotation.eulerAngles.x + degrees);
            enabled_camera.transform.Rotate(degrees, 0.0f, 0.0f);
        }
    }
    
    public Camera Switch() //для удобства возвращает новую камеру
    {
        cam_side.enabled = !cam_side.enabled;
        cam_fpv.enabled = !cam_fpv.enabled;
        
        if (enabled_camera == cam_side)
        {
            enabled_camera = cam_fpv;
            current_camera_mode = "FPV";
        }
        else 
        {
            enabled_camera = cam_side;
            current_camera_mode = "Side";            
        }
        player.Set_Camera_Mode(current_camera_mode);
        return enabled_camera;       
    }
}
