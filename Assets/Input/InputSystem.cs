// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""Mazer"",
            ""id"": ""3bebb6c5-737b-4e29-8f9a-1d2cb4d31353"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""0cb462b8-c44d-45f0-8739-53edba2ad15b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""40a3e133-da41-4fdb-8b90-ec3ddc93e498"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""1ecfc8aa-66ac-4ba4-929a-5dd60b3a5296"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f513fc2a-585f-4996-883f-6910bf539ba6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b30cbb3c-033c-4390-8a33-919a35bfd1e4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f73eb94e-f993-4f36-944a-0e76f45ca52f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9a71fe2c-da2d-4502-a9cc-32f3990e2a95"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""22bc8d98-58e6-4a63-919a-8415b6ab3b18"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Mazer
        m_Mazer = asset.FindActionMap("Mazer", throwIfNotFound: true);
        m_Mazer_Move = m_Mazer.FindAction("Move", throwIfNotFound: true);
        m_Mazer_Jump = m_Mazer.FindAction("Jump", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Mazer
    private readonly InputActionMap m_Mazer;
    private IMazerActions m_MazerActionsCallbackInterface;
    private readonly InputAction m_Mazer_Move;
    private readonly InputAction m_Mazer_Jump;
    public struct MazerActions
    {
        private @InputSystem m_Wrapper;
        public MazerActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Mazer_Move;
        public InputAction @Jump => m_Wrapper.m_Mazer_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Mazer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MazerActions set) { return set.Get(); }
        public void SetCallbacks(IMazerActions instance)
        {
            if (m_Wrapper.m_MazerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MazerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MazerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MazerActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_MazerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MazerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MazerActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_MazerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public MazerActions @Mazer => new MazerActions(this);
    public interface IMazerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
