﻿using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;

namespace OrchardCore.Media;

public sealed class MediaCacheAdminMenu : INavigationProvider
{
    internal readonly IStringLocalizer S;

    public MediaCacheAdminMenu(IStringLocalizer<AdminMenu> localizer)
    {
        S = localizer;
    }

    public ValueTask BuildNavigationAsync(string name, NavigationBuilder builder)
    {
        if (!NavigationHelper.IsAdminMenu(name))
        {
            return ValueTask.CompletedTask;
        }

        builder.Add(S["Configuration"], configuration => configuration
            .Add(S["Media"], S["Media"].PrefixPosition(), media => media
                .Add(S["Media Cache"], S["Media Cache"].PrefixPosition(), cache => cache
                    .Action("Index", "MediaCache", "OrchardCore.Media")
                    .Permission(MediaCachePermissions.ManageAssetCache)
                    .LocalNav()
                )
            )
        );

        return ValueTask.CompletedTask;
    }
}
