﻿// <copyright file="AspNetCoreBuilder.cs" company="OpenTelemetry Authors">
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

namespace OpenTelemetry.Contrib.Instrumentation.EventCounters.AspNetCore
{
    internal class AspNetCoreBuilder : IAspNetCoreBuilder
    {
        private readonly EventSourceOption option;

        public AspNetCoreBuilder(EventCountersOptions options)
        {
            this.option = options.AddEventSource(KnownEventSources.MicrosoftAspNetCoreHosting);
        }

        public IAspNetCoreBuilder WithCounters(params string[] counterNames)
        {
            this.option.WithCounters(counterNames);
            return this;
        }

        public IAspNetCoreBuilder WithAll()
        {
            return this.WithCurrentRequests()
                       .WithFailedRequests()
                       .WithRequestRate()
                       .WithTotalRequests();
        }

        public IAspNetCoreBuilder WithCurrentRequests(string? metricName = null)
        {
            this.option.With(
                "current-requests",
                "The total number of requests that have started, but not yet stopped",
                MetricType.LongSum,
                metricName);

            return this;
        }

        public IAspNetCoreBuilder WithFailedRequests(string? metricName = null)
        {
            this.option.With(
                "failed-requests",
                "The total number of failed requests that have occurred for the life of the app",
                MetricType.LongSum,
                metricName);

            return this;
        }

        public IAspNetCoreBuilder WithRequestRate(string? metricName = null)
        {
            this.option.With(
               "requests-per-second",
               "The number of requests that occur per update interval",
               MetricType.LongGauge,
               metricName);

            return this;
        }

        public IAspNetCoreBuilder WithTotalRequests(string? metricName = null)
        {
            this.option.With(
                "total-requests",
                "The total number of requests that have occurred for the life of the app",
                MetricType.LongSum,
                metricName);

            return this;
        }
    }
}
