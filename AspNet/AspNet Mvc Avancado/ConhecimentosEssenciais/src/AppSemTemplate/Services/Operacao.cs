namespace AppSemTemplate.Services
{
    public class OperacaoService
    {
        public IOperacaoTransient Transiet { get; set; }
        public IOperacaoScoped Scoped { get; set; }
        public IOperacaoSingleton Singleton { get; set; }
        public IOperacaoSingletonInstance SingletonInstance { get; set; }

        public OperacaoService(
            IOperacaoTransient transient,
            IOperacaoScoped scoped,
            IOperacaoSingleton singleton,
            IOperacaoSingletonInstance singletonInstance)
        {
            Transiet = transient;
            Scoped = scoped;
            Singleton = singleton;
            SingletonInstance = singletonInstance;
        }        
    }


    public class Operacao : IOperacaoTransient,
                            IOperacaoScoped,
                            IOperacaoSingleton,
                            IOperacaoSingletonInstance
    {
        public Guid OperacaoId { get; private set; }

        public Operacao(Guid id)
        {
            OperacaoId = id;
        }
        
        public Operacao() : this(Guid.NewGuid()) 
        {

        }
    }

    public interface IOperacao
    {
        Guid OperacaoId { get; }
    }

    public interface IOperacaoTransient : IOperacao { }

    public interface IOperacaoScoped : IOperacao { }

    public interface IOperacaoSingleton : IOperacao { }

    public interface IOperacaoSingletonInstance : IOperacao { }
}
