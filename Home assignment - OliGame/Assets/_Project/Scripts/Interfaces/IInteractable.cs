namespace HomeAssignment
{
    public interface IInteractable
    {
        public bool IsInteracted { get; }
        public void Interact();
    }
}