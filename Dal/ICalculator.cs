using Dal;

namespace Dal
{
    public interface ICalculator<T>
    {
        void Calculate(T t);
    }
}