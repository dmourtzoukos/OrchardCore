using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Localization;
using OrchardCore.AuditTrail.Settings;
using OrchardCore.Navigation;

namespace OrchardCore.AuditTrail.Navigation;

public sealed class AuditTrailSettingsAdminMenu : INavigationProvider
{
    private static readonly RouteValueDictionary _routeValues = new()
    {
        { "area", "OrchardCore.Settings" },
        { "groupId", AuditTrailSettingsGroup.Id },
    };

    internal readonly IStringLocalizer S;

    public AuditTrailSettingsAdminMenu(IStringLocalizer<AuditTrailSettingsAdminMenu> stringLocalizer)
    {
        S = stringLocalizer;
    }

    public ValueTask BuildNavigationAsync(string name, NavigationBuilder builder)
    {
        if (!NavigationHelper.IsAdminMenu(name))
        {
            return ValueTask.CompletedTask;
        }

        builder
             .Add(S["Configuration"], configuration => configuration
                 .Add(S["Settings"], settings => settings
                    .Add(S["Audit Trail"], S["Audit Trail"].PrefixPosition(), auditTrail => auditTrail
                        .AddClass("audittrail")
                        .Id("audittrailSettings")
                        .Action("Index", "Admin", _routeValues)
                        .Permission(AuditTrailPermissions.ManageAuditTrailSettings)
                        .LocalNav()
                    )
                )
            );

        return ValueTask.CompletedTask;
    }
}
