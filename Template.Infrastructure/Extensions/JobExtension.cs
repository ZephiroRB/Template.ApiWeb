using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;

namespace Template.Extensions; 

public static class JobsExtension {
    public static WebApplicationBuilder RegisterJobs(this WebApplicationBuilder builder) {
        builder.Services.AddHangfire(config =>
        {
            config
                .UseMemoryStorage();

            config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings();
        });
        builder.Services.AddHangfireServer();
        return builder;
    }
}