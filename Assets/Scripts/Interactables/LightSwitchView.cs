using System.Collections.Generic;
using UnityEngine;

public class LightSwitchView : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Light> lightsources = new List<Light>();
    private SwitchState currentState;

    private void Start() => currentState = SwitchState.Off;

    public delegate void LightSwitchDelegate();
    public static LightSwitchDelegate lightToggled;

    private void OnEnable()
    {
        lightToggled += OnLightSwitchToggles;
        lightToggled += OnLightSwitchInstructions;
    }

    public void Interact()
    {
        //Todo - Implement Interaction
        lightToggled.Invoke();
    }
    private void toggleLights()
    {
        bool lights = false;

        switch (currentState)
        {
            case SwitchState.On:
                currentState = SwitchState.Off;
                lights = false;
                break;
            case SwitchState.Off:
                currentState = SwitchState.On;
                lights = true;
                break;
            case SwitchState.Unresponsive:
                break;
        }
        foreach (Light lightSource in lightsources)
        {
            lightSource.enabled = lights;
        }
    }

    private void OnLightSwitchToggles()
    {
        toggleLights();
        GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.SwitchSound);
    }
    private void OnLightSwitchInstructions()
    {
        Debug.Log("LightSwitchView -> OnLightSwitchInstructions");
        GameService.Instance.GetInstructionView().HideInstruction();
    }
}
