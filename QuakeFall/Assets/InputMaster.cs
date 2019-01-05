// GENERATED AUTOMATICALLY FROM 'Assets/InputMaster.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


[Serializable]
public class InputMaster : InputActionAssetReference
{
    public InputMaster()
    {
    }
    public InputMaster(InputActionAsset asset)
        : base(asset)
    {
    }
    private bool m_Initialized;
    private void Initialize()
    {
        // Player
        m_Player = asset.GetActionMap("Player");
        m_Player_Move = m_Player.GetAction("Move");
        m_Player_Shoot = m_Player.GetAction("Shoot");
        m_Player_Jump = m_Player.GetAction("Jump");
        m_Player_Menu = m_Player.GetAction("Menu");
        m_Player_AimIn = m_Player.GetAction("Aim In");
        // Menu
        m_Menu = asset.GetActionMap("Menu");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        m_Player = null;
        m_Player_Move = null;
        m_Player_Shoot = null;
        m_Player_Jump = null;
        m_Player_Menu = null;
        m_Player_AimIn = null;
        m_Menu = null;
        m_Initialized = false;
    }
    public void SetAsset(InputActionAsset newAsset)
    {
        if (newAsset == asset) return;
        if (m_Initialized) Uninitialize();
        asset = newAsset;
    }
    public override void MakePrivateCopyOfActions()
    {
        SetAsset(ScriptableObject.Instantiate(asset));
    }
    // Player
    private InputActionMap m_Player;
    private InputAction m_Player_Move;
    private InputAction m_Player_Shoot;
    private InputAction m_Player_Jump;
    private InputAction m_Player_Menu;
    private InputAction m_Player_AimIn;
    public struct PlayerActions
    {
        private InputMaster m_Wrapper;
        public PlayerActions(InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move { get { return m_Wrapper.m_Player_Move; } }
        public InputAction @Shoot { get { return m_Wrapper.m_Player_Shoot; } }
        public InputAction @Jump { get { return m_Wrapper.m_Player_Jump; } }
        public InputAction @Menu { get { return m_Wrapper.m_Player_Menu; } }
        public InputAction @AimIn { get { return m_Wrapper.m_Player_AimIn; } }
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
    }
    public PlayerActions @Player
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new PlayerActions(this);
        }
    }
    // Menu
    private InputActionMap m_Menu;
    public struct MenuActions
    {
        private InputMaster m_Wrapper;
        public MenuActions(InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
    }
    public MenuActions @Menu
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new MenuActions(this);
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get

        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.GetControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
}
