namespace EventsAndDelegates.ObserverV2;

internal class CustomChannelArgs : EventArgs
{
    public Action? Operation { get; set; }
}