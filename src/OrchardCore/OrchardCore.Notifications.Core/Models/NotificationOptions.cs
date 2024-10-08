namespace OrchardCore.Notifications.Models;

public class NotificationOptions
{
    /// <summary>
    /// The number of unread notifications to show in the navbar.
    /// </summary>
    public int TotalUnreadNotifications { get; set; } = 10;

    /// <summary>
    /// Whether or not to disable HtmlBody Sanitizer.
    /// </summary>
    public bool DisableNotificationHtmlBodySanitizer { get; set; }

    /// <summary>
    /// Specifies the cache duration in seconds for the top-unread notification.
    /// A value of 0 disables the max-cache expiration.
    /// If both this property and <see cref="SlidingCacheExpirationSeconds"/> are set to 0, caching will be disabled.
    /// </summary>
    public int AbsoluteCacheExpirationSeconds { get; set; }

    /// <summary>
    /// Specifies the sliding cache duration in seconds for the top-unread notification.
    /// A value of 0 disables sliding-caching expiration.
    /// If both this property and <see cref="AbsoluteCacheExpirationSeconds"/> are set to 0, caching will be disabled.
    /// </summary>
    public int SlidingCacheExpirationSeconds { get; set; } = 1800;
}
