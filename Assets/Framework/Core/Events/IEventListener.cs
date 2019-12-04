namespace Framework.Core.Events
{
    public interface IEventListener
    {
        void Enable();
        void Disable();
    }
}