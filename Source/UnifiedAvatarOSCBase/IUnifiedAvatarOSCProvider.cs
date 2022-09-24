namespace UnifiedAvatarOSCBase
{
    public interface IUnifiedAvatarOSCProvider
    {
        /// <summary>
        /// The name of the provider module
        /// </summary>
        string ProviderName { get; }

        /// <summary>
        /// The rate at which this provider gets update called milliseconds (1000 = once per second)
        /// </summary>
        long UpdateRate { get; }

        /// <summary>
        /// Initialize runs when the provider is loaded (if avatar defenition contains it's parameter address)
        /// </summary>
        /// /// <param name="osc">osc interface used to send data</param>
        void Initialize(IUnifiedAvatarOSC osc);
        
        /// <summary>
        /// Runs when the provider unloaded (if avatar definition no longer requires the parameter)
        /// </summary>
        void Uninitialize();

        /// <summary>
        /// Called on a regular basis to update your parameters
        /// </summary>
        /// <param name="osc">the osc interface you send params to</param>
        /// <param name="deltaTime">time in seconds since last update</param>
        void Update(IUnifiedAvatarOSC osc, float deltaTime);
    }
}