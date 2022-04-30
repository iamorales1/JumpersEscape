// GENERATED AUTOMATICALLY FROM 'Assets/Controller/New Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @NewControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @NewControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""New Controls"",
    ""maps"": [
        {
            ""name"": ""Jumper"",
            ""id"": ""5045a04e-c404-4279-a89e-083a4c6f9549"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""4ef4b28a-12b3-4d5e-b957-edc6ddb7767b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap(pressPoint=0.1)""
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""df91aa47-9512-44e5-9b56-bc0fe9b722d0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""6adaaf46-537a-412e-9f1a-0d301ffbece6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""29db2c05-89da-43d1-bdd4-a1c7a2228730"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Directions"",
                    ""id"": ""ad2a6c1d-cf64-4a6c-9e7c-dd63d5246358"",
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
                    ""id"": ""86a71d49-d010-46a2-a955-6e6fc46f72fe"",
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
                    ""id"": ""829b6cb1-da58-49d7-9d40-e5e04e71a225"",
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
                    ""id"": ""a03b103f-e176-4c2b-b133-7a5f11f273bd"",
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
                    ""id"": ""563424e4-1888-4009-a807-bb6a40767806"",
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
                    ""id"": ""6d842780-c296-4bb8-8232-897386dad50a"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Jumper
        m_Jumper = asset.FindActionMap("Jumper", throwIfNotFound: true);
        m_Jumper_Jump = m_Jumper.FindAction("Jump", throwIfNotFound: true);
        m_Jumper_Move = m_Jumper.FindAction("Move", throwIfNotFound: true);
        m_Jumper_Look = m_Jumper.FindAction("Look", throwIfNotFound: true);
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

    // Jumper
    private readonly InputActionMap m_Jumper;
    private IJumperActions m_JumperActionsCallbackInterface;
    private readonly InputAction m_Jumper_Jump;
    private readonly InputAction m_Jumper_Move;
    private readonly InputAction m_Jumper_Look;
    public struct JumperActions
    {
        private @NewControls m_Wrapper;
        public JumperActions(@NewControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Jumper_Jump;
        public InputAction @Move => m_Wrapper.m_Jumper_Move;
        public InputAction @Look => m_Wrapper.m_Jumper_Look;
        public InputActionMap Get() { return m_Wrapper.m_Jumper; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JumperActions set) { return set.Get(); }
        public void SetCallbacks(IJumperActions instance)
        {
            if (m_Wrapper.m_JumperActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_JumperActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_JumperActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_JumperActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_JumperActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_JumperActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_JumperActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_JumperActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_JumperActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_JumperActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_JumperActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }
        }
    }
    public JumperActions @Jumper => new JumperActions(this);
    public interface IJumperActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
}
