// <copyright file="IGrpcServerBuilder.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

namespace OpenTelemetry.Contrib.Instrumentation.EventCounters.GrpcServer
{
    /// <summary>
    /// Event source option builder for Grpc server event counters.
    /// </summary>
    public interface IGrpcServerBuilder
    {
        /// <summary>
        /// Add several event counters to the options.
        /// </summary>
        /// <param name="counterNames">Name of the counters to listen to.</param>
        /// <returns>The builder instance to define event counters.</returns>
        IGrpcServerBuilder WithCounters(params string[] counterNames);

        /// <summary>
        /// Add all known event counters to the options.
        /// </summary>
        /// <returns>The builder instance to define event counters.</returns>
        IGrpcServerBuilder WithAll();

        /// <summary>
        /// Adds the event counter for the number of total calls.
        /// </summary>
        /// <param name="metricName">Optional name of the published metric. Otherwise the counter name will be used.</param>
        /// <returns>The builder instance to define event counters.</returns>
        IGrpcServerBuilder WithTotalCalls(string? metricName = null);

        /// <summary>
        /// Adds the event counter for the number of current calls.
        /// </summary>
        /// <param name="metricName">Optional name of the published metric. Otherwise the counter name will be used.</param>
        /// <returns>The builder instance to define event counters.</returns>
        IGrpcServerBuilder WithCurrentCalls(string? metricName = null);

        /// <summary>
        /// Adds the event counter for the number of total calls failed.
        /// </summary>
        /// <param name="metricName">Optional name of the published metric. Otherwise the counter name will be used.</param>
        /// <returns>The builder instance to define event counters.</returns>
        IGrpcServerBuilder WithFailedCalls(string? metricName = null);

        /// <summary>
        /// Adds the event counter for the number of total calls deadline exceeded.
        /// </summary>
        /// <param name="metricName">Optional name of the published metric. Otherwise the counter name will be used.</param>
        /// <returns>The builder instance to define event counters.</returns>
        IGrpcServerBuilder WithCallsDeadlineExceeded(string? metricName = null);

        /// <summary>
        /// Adds the event counter for the number of total messages sent.
        /// </summary>
        /// <param name="metricName">Optional name of the published metric. Otherwise the counter name will be used.</param>
        /// <returns>The builder instance to define event counters.</returns>
        IGrpcServerBuilder WithMessagesSent(string? metricName = null);

        /// <summary>
        /// Adds the event counter for the number of total messages received.
        /// </summary>
        /// <param name="metricName">Optional name of the published metric. Otherwise the counter name will be used.</param>
        /// <returns>The builder instance to define event counters.</returns>
        IGrpcServerBuilder WithMessagesReceived(string? metricName = null);

        /// <summary>
        /// Adds the event counter for the number of total calls unimplemented.
        /// </summary>
        /// <param name="metricName">Optional name of the published metric. Otherwise the counter name will be used.</param>
        /// <returns>The builder instance to define event counters.</returns>
        IGrpcServerBuilder WithCallsUnimplemented(string? metricName = null);
    }
}
