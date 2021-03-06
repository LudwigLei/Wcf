﻿using System.ServiceModel;
using System.ServiceModel.Description;

namespace Seterlund.Wcf.Core
{
    /// <summary>
    /// Extension methods to ChannelFactory
    /// </summary>
    public static class ChannelFactoryExtensions
    {
        /// <summary>
        /// Is the channel a federated channel
        /// </summary>
        /// <param name="channelFactory">
        /// The channel factory.
        /// </param>
        /// <typeparam name="T">
        /// The service contract 
        /// </typeparam>
        /// <returns>
        /// True if the binding is WS2007FederationHttpBinding, else false
        /// </returns>
        public static bool IsFederated<T>(this ChannelFactory<T> channelFactory)
        {
            if (channelFactory.Endpoint.Binding is WS2007FederationHttpBinding)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets new client credentials on the channelfactory
        /// </summary>
        /// <param name="channelFactory">
        /// The channel factory.
        /// </param>
        /// <param name="clientCredentials">
        /// The new client credentials.
        /// </param>
        /// <typeparam name="T">
        /// The service contract
        /// </typeparam>
        public static void SetClientCredentials<T>(this ChannelFactory<T> channelFactory, ClientCredentials clientCredentials)
        {
            var defaultCredentials = channelFactory.Endpoint.Behaviors.Find<ClientCredentials>();
            channelFactory.Endpoint.Behaviors.Remove(defaultCredentials);
            channelFactory.Endpoint.Behaviors.Add(clientCredentials);
        }
    }
}
