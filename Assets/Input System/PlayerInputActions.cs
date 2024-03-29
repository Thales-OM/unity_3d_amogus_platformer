//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Input System/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace UnityEngine.InputSystem
{
    public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player-FPV"",
            ""id"": ""0abb0d11-eee9-4623-9140-e69b71d5d09a"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""aee6c3eb-3b35-458b-bf29-fa384d8bfe0a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Swing"",
                    ""type"": ""Button"",
                    ""id"": ""d4d2e21c-83e3-4d96-a1ac-4b5dd9520b66"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Parry"",
                    ""type"": ""Button"",
                    ""id"": ""8be0fdf9-39f0-4f94-98d2-5848eb3630db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Change_Camera"",
                    ""type"": ""Button"",
                    ""id"": ""c4791521-60c6-4b2c-8b01-c27f8b3d5dbb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""7f84d108-bd3f-4c26-ba02-4cbbdefbfbb6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""0453e0a9-81b0-4414-aa22-a4addf0aff26"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Camera_Y"",
                    ""type"": ""Value"",
                    ""id"": ""3d7cf515-e13e-425c-b484-88278257961e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Camera_X"",
                    ""type"": ""Value"",
                    ""id"": ""cb199f7e-ae07-446d-920d-2f60e85b6c69"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a2eea483-c279-44d1-8d7e-77a78bd8e5e9"",
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
                    ""id"": ""47435697-4a84-4c3f-a613-94808432cd63"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4edcdab3-0680-4546-a4b9-ccd9c9a0dcbb"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Parry"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab218012-5be3-4ea6-ad8f-d1818cd49d42"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Change_Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6109e10-6608-49c8-9f45-4dc3047f87d4"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3f5e4509-8bb9-496e-bd4a-eedbfbc5ab3e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""abaee9ac-5ed5-4de5-ae7a-d70d97a4cd88"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7c0ff464-ec20-479f-aa11-e3be4cb65a5e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cd647fa9-c16a-4737-9d0b-0e894f779cfb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cd31324e-26a1-4120-aa98-756a7adb9d08"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""71bd83fe-6c61-4dfc-a0c9-561a42683242"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera_Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4483f48f-d58e-4f19-a8cc-c0caf59726af"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": ""Invert"",
                    ""groups"": """",
                    ""action"": ""Camera_X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player-side"",
            ""id"": ""de23c477-f2fc-485a-95c4-38d31cd5fe87"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""350be93c-e965-48cf-affa-93ef190eada6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""27322804-3f7a-44e8-b4db-06982d73f1b4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Parry"",
                    ""type"": ""Button"",
                    ""id"": ""0803bf1b-aee5-422c-9e48-cd58ba47a073"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Change_Camera"",
                    ""type"": ""Button"",
                    ""id"": ""812de113-76e4-4c86-b4c2-6bef5884e746"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""54c3812c-c586-4744-b257-f580199dadd1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f0da9fa2-55ce-4d78-b406-95d4715a4df2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0801d3d0-631e-42fa-985e-1db2e91e71d9"",
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
                    ""id"": ""ae82ce63-84fb-4bb5-98ca-3d02312e3db6"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Parry"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1444608-2e7d-4dfc-8620-8facb63f10f7"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Change_Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7e4c181-eff0-4f2d-b44a-6a00ef8c2020"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""efdfaede-9f8b-44eb-a1aa-ebc2936d69d3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ec6183c7-8ed1-433f-bfb2-8692e84143b8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""714172c4-0e47-418e-a60f-4870a40b3cd3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""370d33ac-51df-45a1-b361-06c3de69ed85"",
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
            // Player-FPV
            m_PlayerFPV = asset.FindActionMap("Player-FPV", throwIfNotFound: true);
            m_PlayerFPV_Jump = m_PlayerFPV.FindAction("Jump", throwIfNotFound: true);
            m_PlayerFPV_Swing = m_PlayerFPV.FindAction("Swing", throwIfNotFound: true);
            m_PlayerFPV_Parry = m_PlayerFPV.FindAction("Parry", throwIfNotFound: true);
            m_PlayerFPV_Change_Camera = m_PlayerFPV.FindAction("Change_Camera", throwIfNotFound: true);
            m_PlayerFPV_Dash = m_PlayerFPV.FindAction("Dash", throwIfNotFound: true);
            m_PlayerFPV_Movement = m_PlayerFPV.FindAction("Movement", throwIfNotFound: true);
            m_PlayerFPV_Camera_Y = m_PlayerFPV.FindAction("Camera_Y", throwIfNotFound: true);
            m_PlayerFPV_Camera_X = m_PlayerFPV.FindAction("Camera_X", throwIfNotFound: true);
            // Player-side
            m_Playerside = asset.FindActionMap("Player-side", throwIfNotFound: true);
            m_Playerside_Shoot = m_Playerside.FindAction("Shoot", throwIfNotFound: true);
            m_Playerside_Movement = m_Playerside.FindAction("Movement", throwIfNotFound: true);
            m_Playerside_Parry = m_Playerside.FindAction("Parry", throwIfNotFound: true);
            m_Playerside_Change_Camera = m_Playerside.FindAction("Change_Camera", throwIfNotFound: true);
            m_Playerside_Dash = m_Playerside.FindAction("Dash", throwIfNotFound: true);
            m_Playerside_Jump = m_Playerside.FindAction("Jump", throwIfNotFound: true);
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
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Player-FPV
        private readonly InputActionMap m_PlayerFPV;
        private IPlayerFPVActions m_PlayerFPVActionsCallbackInterface;
        private readonly InputAction m_PlayerFPV_Jump;
        private readonly InputAction m_PlayerFPV_Swing;
        private readonly InputAction m_PlayerFPV_Parry;
        private readonly InputAction m_PlayerFPV_Change_Camera;
        private readonly InputAction m_PlayerFPV_Dash;
        private readonly InputAction m_PlayerFPV_Movement;
        private readonly InputAction m_PlayerFPV_Camera_Y;
        private readonly InputAction m_PlayerFPV_Camera_X;
        public struct PlayerFPVActions
        {
            private @PlayerInputActions m_Wrapper;
            public PlayerFPVActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Jump => m_Wrapper.m_PlayerFPV_Jump;
            public InputAction @Swing => m_Wrapper.m_PlayerFPV_Swing;
            public InputAction @Parry => m_Wrapper.m_PlayerFPV_Parry;
            public InputAction @Change_Camera => m_Wrapper.m_PlayerFPV_Change_Camera;
            public InputAction @Dash => m_Wrapper.m_PlayerFPV_Dash;
            public InputAction @Movement => m_Wrapper.m_PlayerFPV_Movement;
            public InputAction @Camera_Y => m_Wrapper.m_PlayerFPV_Camera_Y;
            public InputAction @Camera_X => m_Wrapper.m_PlayerFPV_Camera_X;
            public InputActionMap Get() { return m_Wrapper.m_PlayerFPV; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerFPVActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerFPVActions instance)
            {
                if (m_Wrapper.m_PlayerFPVActionsCallbackInterface != null)
                {
                    @Jump.started -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnJump;
                    @Swing.started -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnSwing;
                    @Swing.performed -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnSwing;
                    @Swing.canceled -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnSwing;
                    @Parry.started -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnParry;
                    @Parry.performed -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnParry;
                    @Parry.canceled -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnParry;
                    @Change_Camera.started -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnChange_Camera;
                    @Change_Camera.performed -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnChange_Camera;
                    @Change_Camera.canceled -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnChange_Camera;
                    @Dash.started -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnDash;
                    @Dash.performed -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnDash;
                    @Dash.canceled -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnDash;
                    @Movement.started -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnMovement;
                    @Camera_Y.started -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnCamera_Y;
                    @Camera_Y.performed -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnCamera_Y;
                    @Camera_Y.canceled -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnCamera_Y;
                    @Camera_X.started -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnCamera_X;
                    @Camera_X.performed -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnCamera_X;
                    @Camera_X.canceled -= m_Wrapper.m_PlayerFPVActionsCallbackInterface.OnCamera_X;
                }
                m_Wrapper.m_PlayerFPVActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Swing.started += instance.OnSwing;
                    @Swing.performed += instance.OnSwing;
                    @Swing.canceled += instance.OnSwing;
                    @Parry.started += instance.OnParry;
                    @Parry.performed += instance.OnParry;
                    @Parry.canceled += instance.OnParry;
                    @Change_Camera.started += instance.OnChange_Camera;
                    @Change_Camera.performed += instance.OnChange_Camera;
                    @Change_Camera.canceled += instance.OnChange_Camera;
                    @Dash.started += instance.OnDash;
                    @Dash.performed += instance.OnDash;
                    @Dash.canceled += instance.OnDash;
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Camera_Y.started += instance.OnCamera_Y;
                    @Camera_Y.performed += instance.OnCamera_Y;
                    @Camera_Y.canceled += instance.OnCamera_Y;
                    @Camera_X.started += instance.OnCamera_X;
                    @Camera_X.performed += instance.OnCamera_X;
                    @Camera_X.canceled += instance.OnCamera_X;
                }
            }
        }
        public PlayerFPVActions @PlayerFPV => new PlayerFPVActions(this);

        // Player-side
        private readonly InputActionMap m_Playerside;
        private IPlayersideActions m_PlayersideActionsCallbackInterface;
        private readonly InputAction m_Playerside_Shoot;
        private readonly InputAction m_Playerside_Movement;
        private readonly InputAction m_Playerside_Parry;
        private readonly InputAction m_Playerside_Change_Camera;
        private readonly InputAction m_Playerside_Dash;
        private readonly InputAction m_Playerside_Jump;
        public struct PlayersideActions
        {
            private @PlayerInputActions m_Wrapper;
            public PlayersideActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Shoot => m_Wrapper.m_Playerside_Shoot;
            public InputAction @Movement => m_Wrapper.m_Playerside_Movement;
            public InputAction @Parry => m_Wrapper.m_Playerside_Parry;
            public InputAction @Change_Camera => m_Wrapper.m_Playerside_Change_Camera;
            public InputAction @Dash => m_Wrapper.m_Playerside_Dash;
            public InputAction @Jump => m_Wrapper.m_Playerside_Jump;
            public InputActionMap Get() { return m_Wrapper.m_Playerside; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayersideActions set) { return set.Get(); }
            public void SetCallbacks(IPlayersideActions instance)
            {
                if (m_Wrapper.m_PlayersideActionsCallbackInterface != null)
                {
                    @Shoot.started -= m_Wrapper.m_PlayersideActionsCallbackInterface.OnShoot;
                    @Shoot.performed -= m_Wrapper.m_PlayersideActionsCallbackInterface.OnShoot;
                    @Shoot.canceled -= m_Wrapper.m_PlayersideActionsCallbackInterface.OnShoot;
                    @Movement.started -= m_Wrapper.m_PlayersideActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_PlayersideActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_PlayersideActionsCallbackInterface.OnMovement;
                    @Parry.started -= m_Wrapper.m_PlayersideActionsCallbackInterface.OnParry;
                    @Parry.performed -= m_Wrapper.m_PlayersideActionsCallbackInterface.OnParry;
                    @Parry.canceled -= m_Wrapper.m_PlayersideActionsCallbackInterface.OnParry;
                    @Change_Camera.started -= m_Wrapper.m_PlayersideActionsCallbackInterface.OnChange_Camera;
                    @Change_Camera.performed -= m_Wrapper.m_PlayersideActionsCallbackInterface.OnChange_Camera;
                    @Change_Camera.canceled -= m_Wrapper.m_PlayersideActionsCallbackInterface.OnChange_Camera;
                    @Dash.started -= m_Wrapper.m_PlayersideActionsCallbackInterface.OnDash;
                    @Dash.performed -= m_Wrapper.m_PlayersideActionsCallbackInterface.OnDash;
                    @Dash.canceled -= m_Wrapper.m_PlayersideActionsCallbackInterface.OnDash;
                    @Jump.started -= m_Wrapper.m_PlayersideActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PlayersideActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PlayersideActionsCallbackInterface.OnJump;
                }
                m_Wrapper.m_PlayersideActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Shoot.started += instance.OnShoot;
                    @Shoot.performed += instance.OnShoot;
                    @Shoot.canceled += instance.OnShoot;
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Parry.started += instance.OnParry;
                    @Parry.performed += instance.OnParry;
                    @Parry.canceled += instance.OnParry;
                    @Change_Camera.started += instance.OnChange_Camera;
                    @Change_Camera.performed += instance.OnChange_Camera;
                    @Change_Camera.canceled += instance.OnChange_Camera;
                    @Dash.started += instance.OnDash;
                    @Dash.performed += instance.OnDash;
                    @Dash.canceled += instance.OnDash;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                }
            }
        }
        public PlayersideActions @Playerside => new PlayersideActions(this);
        public interface IPlayerFPVActions
        {
            void OnJump(InputAction.CallbackContext context);
            void OnSwing(InputAction.CallbackContext context);
            void OnParry(InputAction.CallbackContext context);
            void OnChange_Camera(InputAction.CallbackContext context);
            void OnDash(InputAction.CallbackContext context);
            void OnMovement(InputAction.CallbackContext context);
            void OnCamera_Y(InputAction.CallbackContext context);
            void OnCamera_X(InputAction.CallbackContext context);
        }
        public interface IPlayersideActions
        {
            void OnShoot(InputAction.CallbackContext context);
            void OnMovement(InputAction.CallbackContext context);
            void OnParry(InputAction.CallbackContext context);
            void OnChange_Camera(InputAction.CallbackContext context);
            void OnDash(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
        }
    }
}
