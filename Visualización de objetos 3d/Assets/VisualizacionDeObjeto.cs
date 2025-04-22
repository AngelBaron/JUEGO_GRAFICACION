using UnityEngine;

public class VisualizacionDeObjeto : MonoBehaviour
{
    public GameObject objeto3D;
    public Material materialNuevo;
    public Camera camara;

    void Start()
    {
        // 1. Modelado - Crear un cubo
        if (objeto3D == null)
        {
            objeto3D = GameObject.CreatePrimitive(PrimitiveType.Cube);
            objeto3D.name = "Objeto3D";
        }

        // 2. Transformaciones geométricas
        objeto3D.transform.position = new Vector3(0, 1, 0);
        objeto3D.transform.rotation = Quaternion.Euler(45, 45, 0);
        objeto3D.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        // 3. Proyección - Configurar cámara
        if (camara == null)
        {
            camara = Camera.main;
        }

        camara.transform.position = new Vector3(0, 2, -6);
        camara.transform.rotation = Quaternion.Euler(20, 0, 0);
        camara.orthographic = false; // Cambiar a true para proyección ortográfica

        // 4. Recorte - Modificar clipping planes
        camara.nearClipPlane = 0.3f;
        camara.farClipPlane = 100f;

        // 5. Material y renderizado
        if (materialNuevo == null)
        {
            materialNuevo = new Material(Shader.Find("Standard"));
            materialNuevo.color = Color.red;
        }

        objeto3D.GetComponent<Renderer>().material = materialNuevo;

        // 6. Luz direccional
        GameObject luz = new GameObject("LuzDireccional");
        Light lightComp = luz.AddComponent<Light>();
        lightComp.type = LightType.Directional;
        luz.transform.rotation = Quaternion.Euler(50, -30, 0);
    }
}
