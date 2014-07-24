namespace IoCBoxNoUi
{
    using Ninject;

    using NUnit.Framework;

    public class Samples
    {
        [Test]
        public void ResolveAuto()
        {
            var kernel = new StandardKernel();
            var simpleClass1 = kernel.Get<Simple>();
            var simpleClass2 = kernel.Get<Simple>();
            Assert.AreNotSame(simpleClass1, simpleClass2);
        }

        [Test]
        public void ResolveSingleton()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Simple>().To<Simple>().InSingletonScope();
            var simpleClass1 = kernel.Get<Simple>();
            var simpleClass2 = kernel.Get<Simple>();
            Assert.AreSame(simpleClass1, simpleClass2);
        }

        [Test]
        public void ResolveInterface()
        {
            var kernel = new StandardKernel();
            Assert.Throws<ActivationException>(()=>kernel.Get<ISimple>());
            kernel.Bind<ISimple>().To<Simple>();
            var simpleClass1 = kernel.Get<ISimple>();
            var simpleClass2 = kernel.Get<Simple>();
            Assert.AreNotSame(simpleClass1, simpleClass2);
        }

        [Test]
        public void ResoveComplex()
        {
            var kernel = new StandardKernel();
            kernel.Bind<ISimple>().To<Simple>().InSingletonScope();

            var complex1 = kernel.Get<ComplexBeast>();
            var complex2 = kernel.Get<ComplexBeast>();
            Assert.AreNotSame(complex1, complex2);
            Assert.AreSame(complex1.Simple, complex2.Simple);
        }
    }
}
