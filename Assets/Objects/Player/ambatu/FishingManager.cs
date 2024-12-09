using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingManager : MonoBehaviour
{
    public GameObject fishingParentObj;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public bool fishingAvailable;
    public bool isFishing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)){
            if (!isFishing) StartFishing();
            else if (isFishing) StopFishing();
        }
    }

    void StartFishing()
    {
        isFishing = true;
        fishingParentObj.SetActive(true);
        skinnedMeshRenderer.enabled = false;
    }

    void StopFishing()
    {
        isFishing = false;
        fishingParentObj.SetActive(false);
        skinnedMeshRenderer.enabled = true;
    }
}
