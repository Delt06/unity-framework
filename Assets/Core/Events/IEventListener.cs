namespace Core.Events
{
    public interface IEventListener
    {
        void Enable();
        void Disable();
    }
}