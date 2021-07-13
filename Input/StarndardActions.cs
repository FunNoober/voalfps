// GENERATED AUTOMATICALLY FROM 'Assets/Input/StarndardActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @StarndardActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @StarndardActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""StarndardActions"",
    ""maps"": [
        {
            ""name"": ""StarndardInput"",
            ""id"": ""e80aa404-61b2-49b1-bd59-fa9d2419a8dd"",
            ""actions"": [
                {
                    ""name"": ""HorizontalInput"",
                    ""type"": ""Button"",
                    ""id"": ""e1610141-ab00-41bc-88fb-df9086b95338"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""VerticalInput"",
                    ""type"": ""Value"",
                    ""id"": ""1cb66dfa-0987-4045-9c12-05bbbf03fb87"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""fd141a10-1046-4173-8502-97cbfebe4df0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""4c14197f-7d74-4935-866f-4282c19595a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""634a8a62-dc4b-4511-afe4-23188da83788"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""cd23664e-0f8a-483d-bfad-7620c75078bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FlashLight"",
                    ""type"": ""Button"",
                    ""id"": ""e5fb0038-c457-44fd-b2eb-cd3afa844222"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""b04b3902-1125-40cf-bfc5-93d175dba198"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch"",
                    ""type"": ""Button"",
                    ""id"": ""a16be7ed-e105-4d3d-b00f-fc94afa5ce76"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""0603bf4e-acef-473c-b1b3-83361ab6359f"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalInput"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""eaf34a4e-b14c-4255-9d99-5f0bd76f945f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControl"",
                    ""action"": ""HorizontalInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f206fad7-f9d0-4200-926d-118bda62433f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControl"",
                    ""action"": ""HorizontalInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""960b32a2-79b5-4198-a488-eaf15957076c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControl"",
                    ""action"": ""HorizontalInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""403b467c-a179-4456-9d27-073569758b85"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControl"",
                    ""action"": ""HorizontalInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3997b909-ff32-4f80-bffb-89b80b0bf57a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalInput"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""dde31b58-1d29-4b82-9968-381866d78b33"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7806f83f-a30e-4dbe-aff8-bfa2ab1188f4"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b4df414d-b8f3-404d-9207-aae2dd167426"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""debfc7a6-e99f-43bc-9822-011da34c2610"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7a954078-605c-4054-a983-e4df508e9f2e"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControl"",
                    ""action"": ""VerticalInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5f8d7d4c-e5fa-497e-a2a3-ae54bd7940aa"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalInput"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9eed3f2b-c649-4e64-a1e1-7719ba1f5a8d"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8f2fd8f6-f610-4dad-8feb-d8a98b51669d"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""228f7dfa-64c1-4ffa-bdf0-80bd628be0ee"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""47bdb448-65e9-488a-bae1-10a426448a64"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""56fca6f5-869d-4cbc-917d-aac1445f1847"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1f5499a-c9c3-435f-91b0-21c4cfb7d6bc"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4468e92-b4a7-460c-a623-88c1d31dc57f"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4191cf9-c46b-483c-aeb0-d302cb89c7ab"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50c4af16-c290-47f1-9051-3dd181b71e28"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f846ff1-700a-4dc0-ac09-d98ee0158e3b"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbfe6d13-1db9-4745-abed-5dc704ea2dd9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdce4a65-bcef-4117-847a-d52465c024f3"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca892143-7430-43e0-b234-9d63060dda39"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlashLight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60220433-2a8a-492b-ad79-7a06206ce243"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlashLight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91682d08-e6f6-447c-96bc-242435056c1c"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6481647-77ba-40f5-8bc6-a43ca32b88e4"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1669593f-0f42-4176-b254-bb35682be8ac"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b88835dd-db1a-4c23-9a7b-27373e8ae33e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardControl"",
            ""bindingGroup"": ""KeyboardControl"",
            ""devices"": []
        }
    ]
}");
        // StarndardInput
        m_StarndardInput = asset.FindActionMap("StarndardInput", throwIfNotFound: true);
        m_StarndardInput_HorizontalInput = m_StarndardInput.FindAction("HorizontalInput", throwIfNotFound: true);
        m_StarndardInput_VerticalInput = m_StarndardInput.FindAction("VerticalInput", throwIfNotFound: true);
        m_StarndardInput_Shoot = m_StarndardInput.FindAction("Shoot", throwIfNotFound: true);
        m_StarndardInput_Run = m_StarndardInput.FindAction("Run", throwIfNotFound: true);
        m_StarndardInput_Crouch = m_StarndardInput.FindAction("Crouch", throwIfNotFound: true);
        m_StarndardInput_Jump = m_StarndardInput.FindAction("Jump", throwIfNotFound: true);
        m_StarndardInput_FlashLight = m_StarndardInput.FindAction("FlashLight", throwIfNotFound: true);
        m_StarndardInput_Reload = m_StarndardInput.FindAction("Reload", throwIfNotFound: true);
        m_StarndardInput_Switch = m_StarndardInput.FindAction("Switch", throwIfNotFound: true);
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

    // StarndardInput
    private readonly InputActionMap m_StarndardInput;
    private IStarndardInputActions m_StarndardInputActionsCallbackInterface;
    private readonly InputAction m_StarndardInput_HorizontalInput;
    private readonly InputAction m_StarndardInput_VerticalInput;
    private readonly InputAction m_StarndardInput_Shoot;
    private readonly InputAction m_StarndardInput_Run;
    private readonly InputAction m_StarndardInput_Crouch;
    private readonly InputAction m_StarndardInput_Jump;
    private readonly InputAction m_StarndardInput_FlashLight;
    private readonly InputAction m_StarndardInput_Reload;
    private readonly InputAction m_StarndardInput_Switch;
    public struct StarndardInputActions
    {
        private @StarndardActions m_Wrapper;
        public StarndardInputActions(@StarndardActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @HorizontalInput => m_Wrapper.m_StarndardInput_HorizontalInput;
        public InputAction @VerticalInput => m_Wrapper.m_StarndardInput_VerticalInput;
        public InputAction @Shoot => m_Wrapper.m_StarndardInput_Shoot;
        public InputAction @Run => m_Wrapper.m_StarndardInput_Run;
        public InputAction @Crouch => m_Wrapper.m_StarndardInput_Crouch;
        public InputAction @Jump => m_Wrapper.m_StarndardInput_Jump;
        public InputAction @FlashLight => m_Wrapper.m_StarndardInput_FlashLight;
        public InputAction @Reload => m_Wrapper.m_StarndardInput_Reload;
        public InputAction @Switch => m_Wrapper.m_StarndardInput_Switch;
        public InputActionMap Get() { return m_Wrapper.m_StarndardInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StarndardInputActions set) { return set.Get(); }
        public void SetCallbacks(IStarndardInputActions instance)
        {
            if (m_Wrapper.m_StarndardInputActionsCallbackInterface != null)
            {
                @HorizontalInput.started -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnHorizontalInput;
                @HorizontalInput.performed -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnHorizontalInput;
                @HorizontalInput.canceled -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnHorizontalInput;
                @VerticalInput.started -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnVerticalInput;
                @VerticalInput.performed -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnVerticalInput;
                @VerticalInput.canceled -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnVerticalInput;
                @Shoot.started -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnShoot;
                @Run.started -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnRun;
                @Crouch.started -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnCrouch;
                @Jump.started -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnJump;
                @FlashLight.started -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnFlashLight;
                @FlashLight.performed -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnFlashLight;
                @FlashLight.canceled -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnFlashLight;
                @Reload.started -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnReload;
                @Switch.started -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnSwitch;
                @Switch.performed -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnSwitch;
                @Switch.canceled -= m_Wrapper.m_StarndardInputActionsCallbackInterface.OnSwitch;
            }
            m_Wrapper.m_StarndardInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @HorizontalInput.started += instance.OnHorizontalInput;
                @HorizontalInput.performed += instance.OnHorizontalInput;
                @HorizontalInput.canceled += instance.OnHorizontalInput;
                @VerticalInput.started += instance.OnVerticalInput;
                @VerticalInput.performed += instance.OnVerticalInput;
                @VerticalInput.canceled += instance.OnVerticalInput;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @FlashLight.started += instance.OnFlashLight;
                @FlashLight.performed += instance.OnFlashLight;
                @FlashLight.canceled += instance.OnFlashLight;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Switch.started += instance.OnSwitch;
                @Switch.performed += instance.OnSwitch;
                @Switch.canceled += instance.OnSwitch;
            }
        }
    }
    public StarndardInputActions @StarndardInput => new StarndardInputActions(this);
    private int m_KeyboardControlSchemeIndex = -1;
    public InputControlScheme KeyboardControlScheme
    {
        get
        {
            if (m_KeyboardControlSchemeIndex == -1) m_KeyboardControlSchemeIndex = asset.FindControlSchemeIndex("KeyboardControl");
            return asset.controlSchemes[m_KeyboardControlSchemeIndex];
        }
    }
    public interface IStarndardInputActions
    {
        void OnHorizontalInput(InputAction.CallbackContext context);
        void OnVerticalInput(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnFlashLight(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnSwitch(InputAction.CallbackContext context);
    }
}
