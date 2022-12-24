namespace ManagementSystem.Entities
{
    public class TodoItem
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? isFinished { get; set; }

        public override bool Equals(object? obj)
        {
            TodoItem? other = obj as TodoItem;

            if (other == null) return false;

            if(this.Title == null) return false;
            if(this.Description == null) return false;

            return this.Title.Equals(other.Title) && this.Description.Equals(other.Description);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
