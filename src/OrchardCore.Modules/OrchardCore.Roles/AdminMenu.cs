using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;

namespace OrchardCore.Roles;

public sealed class AdminMenu : INavigationProvider
{
    internal readonly IStringLocalizer S;

    public AdminMenu(IStringLocalizer<AdminMenu> localizer)
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
                .Add(S["Roles"], S["Roles"].PrefixPosition(), roles => roles
                    .AddClass("roles").Id("roles")
                    .Action("Index", "Admin", "OrchardCore.Roles")
                    .Permission(CommonPermissions.ManageRoles)
                    .LocalNav()
                )
            );

        return ValueTask.CompletedTask;
    }
}
