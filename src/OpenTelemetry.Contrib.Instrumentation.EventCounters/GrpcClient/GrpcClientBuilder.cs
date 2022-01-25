// <copyright file="GrpcClientBuilder.cs" company="OpenTelemetry Authors">
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

using OpenTelemetry.Metrics;

namespace OpenTelemetry.Contrib.Instrumentation.EventCounters.GrpcClient
{
    internal class GrpcClientBuilder : IGrpcClientBuilder
    {
        private readonly EventSourceOption option;

        public GrpcClientBuilder(EventCountersOptions options)
        {
            this.option = options.AddEventSource(KnownEventSources.GrpcNetClient);
        }

        public IGrpcClientBuilder WithCounters(params string[] counterNames)
        {
            this.option.WithCounters(counterNames);
            return this;
        }

        public IGrpcClientBuilder WithAll()
        {
            return this.WithCallsDeadlineExceeded()
                       .WithCurrentCalls()
                       .WithFailedCalls()
                       .WithMessagesReceived()
                       .WithMessagesSent()
                       .WithTotalCalls();
        }

        public IGrpcClientBuilder WithCallsDeadlineExceeded(string? metricName = null)
        {
            this.option.With(
                "calls-deadline-exceeded",
                "Total Calls Deadline Exceeded",
                MetricType.LongSum,
                metricName);

            return this;
        }

        public IGrpcClientBuilder WithCurrentCalls(string? metricName = null)
        {
            this.option.With(
                "current-calls",
                "Current Calls",
                MetricType.LongGauge,
                metricName);

            return this;
        }

        public IGrpcClientBuilder WithFailedCalls(string? metricName = null)
        {
            this.option.With(
                "calls-failed",
                "Total Calls Failed",
                MetricType.LongSum,
                metricName);

            return this;
        }

        public IGrpcClientBuilder WithMessagesReceived(string? metricName = null)
        {
            this.option.With(
                "messages-received",
                "Total Messages Received",
                MetricType.LongSum,
                metricName);

            return this;
        }

        public IGrpcClientBuilder WithMessagesSent(string? metricName = null)
        {
            this.option.With(
                "messages-sent",
                "Total Messages Sent",
                MetricType.LongSum,
                metricName);

            return this;
        }

        public IGrpcClientBuilder WithTotalCalls(string? metricName = null)
        {
            this.option.With(
                "total-calls",
                "Total Calls",
                MetricType.LongSum,
                metricName);

            return this;
        }
    }
}
