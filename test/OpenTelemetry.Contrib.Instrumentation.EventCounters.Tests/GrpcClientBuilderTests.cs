// <copyright file="GrpcClientBuilderTests.cs" company="OpenTelemetry Authors">
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

using OpenTelemetry.Contrib.Instrumentation.EventCounters.GrpcClient;
using OpenTelemetry.Metrics;
using Xunit;

namespace OpenTelemetry.Contrib.Instrumentation.EventCounters.Tests
{
    public class GrpcClientBuilderTests
    {
        [Fact]
        public void WithAll_Adds_All_Known_Counter()
        {
            // retrieve all interface methods
            var methodCounts = typeof(IGrpcClientBuilder).GetMethods().Length;

            var options = new EventCountersOptions();
            var builder = new GrpcClientBuilder(options);
            builder.WithAll();

            Assert.NotEmpty(options.Sources);
            Assert.Equal(methodCounts - 2, options.Sources[0].EventCounters.Count);
        }

        [Fact]
        public void WithCounters_Adds_Unknown_Counters()
        {
            var options = new EventCountersOptions();
            var builder = new GrpcClientBuilder(options);
            builder.WithCounters("firstCounter", "secondCounter");

            Assert.NotEmpty(options.Sources);
            Assert.Equal(2, options.Sources[0].EventCounters.Count);

            Assert.Equal("firstCounter", options.Sources[0].EventCounters[0].Name);
            Assert.Null(options.Sources[0].EventCounters[0].Description);
            Assert.Equal(MetricType.LongSum, options.Sources[0].EventCounters[0].Type);
            Assert.Null(options.Sources[0].EventCounters[0].MetricName);
        }

        [Fact]
        public void Extension_Adds_EventSource()
        {
            var options = new EventCountersOptions();
            options.AddGrcpClient();

            Assert.NotEmpty(options.Sources);
            Assert.Equal(KnownEventSources.GrpcNetClient, options.Sources[0].EventSourceName);
        }
    }
}
