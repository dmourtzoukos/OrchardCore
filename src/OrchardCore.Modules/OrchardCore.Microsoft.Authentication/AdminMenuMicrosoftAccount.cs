using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;

namespace OrchardCore.Microsoft.Authentication;

public sealed class AdminMenuMicrosoftAccount : INavigationProvider
{
    private static readonly RouteValueDictionary _routeValues = new()
    {
        { "area", "OrchardCore.Settings" },
        { "groupId", MicrosoftAuthenticationConstants.Features.MicrosoftAccount },
    };

    internal readonly IStringLocalizer S;

    public AdminMenuMicrosoftAccount(IStringLocalizer<AdminMenuMicrosoftAccount> localizer)
    {
        S = localizer;
    }

    public ValueTask BuildNavigationAsync(string name, NavigationBuilder builder)
    {
        if (!NavigationHelper.IsAdminMenu(name))
        {
            return ValueTask.CompletedTask;
        }

        builder
            .Add(S["Security"], security => security
                .Add(S["Authentication"], authentication => authentication
                    .Add(S["Microsoft"], S["Microsoft"].PrefixPosition(), microsoft => microsoft
                        .AddClass("microsoft")
                        .Id("microsoft")
                        .Action("Index", "Admin", _routeValues)
                        .Permission(Permissions.ManageMicrosoftAuthentication)
                        .LocalNav()
                    )
                )
           );

        return ValueTask.CompletedTask;
    }
}
