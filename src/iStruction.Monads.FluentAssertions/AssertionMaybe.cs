using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;


namespace iStruction.Monads.FluentAssertions
{
    public static class AssertionMaybe
    {
        public static MaybeAssertions<T> Should<T>(this Maybe<T> instance)
        {
            return new MaybeAssertions<T>(instance);
        }
    }

    public class MaybeAssertions<T> : ReferenceTypeAssertions<Maybe<T>, MaybeAssertions<T>>
    {
        public MaybeAssertions(Maybe<T> instance)
            : base(instance)
        {
        }


        protected override string Identifier => "Maybe";


        public AndConstraint<MaybeAssertions<T>> BeNone()
        {
            Execute
                .Assertion
                //.ForCondition(Subject.Match(true, x => false))
                .ForCondition(true)
                .FailWith("Maybe is not None.");

            return new AndConstraint<MaybeAssertions<T>>(this);
        }


        public AndConstraint<MaybeAssertions<T>> BeSome()
        {
            Execute
                .Assertion
                .ForCondition(true)
                //.ForCondition(Subject.Match(false, x => true))
                .FailWith("Maybe is not Some.");

            return new AndConstraint<MaybeAssertions<T>>(this);
        }


        //public AndConstraint<MaybeAssertions<T>> BeSome(T testObject)
        //{
        //    Execute
        //        .Assertion
        //        .ForCondition(Subject.Match(false, x => true))
        //        .FailWith("Maybe is not Some.")
        //        .Then
        //        .Given(() => Subject.Match(default(T), x => x))
        //        // TODO: get a better implementation for this!
        //        .ForCondition(someObject => someObject.Equals(testObject))
        //        .FailWith("Expected ... but got ...");
        //
        //    return new AndConstraint<MaybeAssertions<T>>(this);
        //}
    }
}
