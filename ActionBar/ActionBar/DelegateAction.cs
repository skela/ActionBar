using System;

namespace ActionBarDemo.Widget.ActionBar
{
    public class DelegateAction : BaseAction
    {
        private readonly Action _action;

		public DelegateAction(Action action, int drawable) : base(drawable)
        {
            _action = action;
        }

		public DelegateAction(Action action, int drawable, int drawableDisabled = -1) : base(drawable, drawableDisabled)
        {
            _action = action;
        }

        public override void PerformAction()
        {
            if (_action != null)
                _action();
        }
    }

	public class EventHandlerAction : BaseAction
	{
		private readonly EventHandler _action;

		public EventHandlerAction(EventHandler action, int drawable) : base(drawable)
		{
			_action = action;
		}

		public EventHandlerAction(EventHandler action, int drawable, int drawableDisabled = -1) : base(drawable, drawableDisabled)
		{
			_action = action;
		}

		public override void PerformAction()
		{
			if (_action != null)
				_action(null,null);
		}
	}
}
