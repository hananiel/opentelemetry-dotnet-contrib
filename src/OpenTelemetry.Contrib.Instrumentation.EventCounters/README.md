# Event counter instrumentation for OpenTelemetry

This is an
[Instrumentation Library](https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/glossary.md#instrumentation-library),
which republishes EventCounters using Metrics Api. 

## Steps to enable OpenTelemetry.Contrib.Instrumentation.EventCounters

### Step 1: Install Package

Add a reference to the
[`OpenTelemetry.Contrib.Instrumentation.EventCounters`](https://www.nuget.org/packages/OpenTelemetry.Contrib.Instrumentation.EventCounters)
package. Also, add any other instrumentations & exporters you will need.

```shell
dotnet add package OpenTelemetry.Contrib.Instrumentation.EventCounters
```

### Step 2: Enable EventCounters Instrumentation at application startup

EventCounters instrumentation must be enabled at application startup.

The following example demonstrates adding EventCounter events to a
console application. This example also sets up the OpenTelemetry Console
exporter, which requires adding the package
[`OpenTelemetry.Exporter.Console`](https://www.nuget.org/packages/OpenTelemetry.Exporter.Console)
to the application.

```csharp
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Contrib.Instrumentation.EventCounters;

namespace DotnetMetrics
{
    public class Program
    {

        public static void Main(string[] args)
        {
            using var meterprovider = Sdk.CreateMeterProviderBuilder()
                    .AddEventCounters(options =>
                    {
                        options.Sources = null;
                    })
                    .AddConsoleExporter()
                    .Build();

            System.Threading.Thread.Sleep(15000); // Give it some time to record metrics

        }
    }
}
```

## References

* [OpenTelemetry Project](https://opentelemetry.io/)
