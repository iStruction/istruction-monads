using System;


namespace iStruction.Monads
{
    public static class Maybe
    {
        public static Maybe<TItem> None<TItem>() => new Maybe<TItem>();

        public static Maybe<TItem> Some<TItem>(this TItem item) => new Maybe<TItem>(item);
    }


    public readonly struct Maybe<TItem>
    {
        private readonly bool _hasItem;
        private readonly TItem _item;


        public static Maybe<TItem> None() => new Maybe<TItem>();


        internal Maybe(TItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _item = item;
            _hasItem = true;
        }


        public TResult Match<TResult>(TResult none, Func<TItem, TResult> some)
        {
            if (some == null)
            {
                throw new ArgumentNullException(nameof(some));
            }

            return _hasItem ? some(_item) : none;
        }


        public TResult Match<TResult>(Func<TResult> none, Func<TItem, TResult> some)
        {
            if (none == null)
            {
                throw new ArgumentNullException(nameof(none));
            }

            if (some == null)
            {
                throw new ArgumentNullException(nameof(some));
            }

            return _hasItem ? some(_item) : none();
        }
    }
}
