namespace Game
{
    public abstract class SlotPresenterBase : PresenterBase<SlotModelBase>
    {
        protected SlotPresenterBase(SlotModelBase model) : base(model)
        {
        }
        public abstract void Spin(int betNum);
    }
}