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
        //private readonly bool _hasItem;
        private readonly TItem _item;


        public static Maybe<TItem> None() => new Maybe<TItem>();


        internal Maybe(TItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _item    = item;
            //_hasItem = true;
        }
    }
}
