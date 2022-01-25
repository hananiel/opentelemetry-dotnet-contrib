namespace OpenTelemetry.Contrib.Instrumentation.EventCounters.GrpcClient
{
    /// <summary>
    /// Event source option builder for Grpc client event counters.
    /// </summary>
    public interface IGrpcClientBuilder
    {
        /// <summary>
        /// Add several event counters to the options.
        /// </summary>
        /// <param name="counterNames">Name of the counters to listen to.</param>
        /// <returns>The builder instance to define event counters.</returns>
        IGrpcClientBuilder WithCounters(params string[] counterNames);

        /// <summary>
        /// Add all known event counters to the options.
        /// </summary>
        /// <returns>The builder instance to define event counters.</returns>
        IGrpcClientBuilder WithAll();

        /// <summary>
        /// Adds the event counter for the number of total calls.
        /// </summary>
        /// <param name="metricName">Optional name of the published metric. Otherwise the counter name will be used.</param>
        /// <returns>The builder instance to define event counters.</returns>
        IGrpcClientBuilder WithTotalCalls(string? metricName = null);

        /// <summary>
        /// Adds the event counter for the number of current calls.
        /// </summary>
        /// <param name="metricName">Optional name of the published metric. Otherwise the counter name will be used.</param>
        /// <returns>The builder instance to define event counters.</returns>
        IGrpcClientBuilder WithCurrentCalls(string? metricName = null);

        /// <summary>
        /// Adds the event counter for the number of total calls failed.
        /// </summary>
        /// <param name="metricName">Optional name of the published metric. Otherwise the counter name will be used.</param>
        /// <returns>The builder instance to define event counters.</returns>
        IGrpcClientBuilder WithFailedCalls(string? metricName = null);

        /// <summary>
        /// Adds the event counter for the number of total calls deadline exceeded.
        /// </summary>
        /// <param name="metricName">Optional name of the published metric. Otherwise the counter name will be used.</param>
        /// <returns>The builder instance to define event counters.</returns>
        IGrpcClientBuilder WithCallsDeadlineExceeded(string? metricName = null);

        /// <summary>
        /// Adds the event counter for the number of total messages sent.
        /// </summary>
        /// <param name="metricName">Optional name of the published metric. Otherwise the counter name will be used.</param>
        /// <returns>The builder instance to define event counters.</returns>
        IGrpcClientBuilder WithMessagesSent(string? metricName = null);

        /// <summary>
        /// Adds the event counter for the number of total messages received.
        /// </summary>
        /// <param name="metricName">Optional name of the published metric. Otherwise the counter name will be used.</param>
        /// <returns>The builder instance to define event counters.</returns>
        IGrpcClientBuilder WithMessagesReceived(string? metricName = null);
    }
}
