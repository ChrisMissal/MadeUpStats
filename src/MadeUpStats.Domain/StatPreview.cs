namespace MadeUpStats.Domain
{
    public class StatPreview
    {
        protected readonly string text;

        public StatPreview(IStatValue statValue, string description)
        {
            text = statValue.Text + " " + description;
        }

        public virtual string Text
        {
            get { return text; }
        }
    }
}