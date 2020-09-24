using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public abstract class Repository<T>
    {
        // Boolean is to turn off available fruits
        protected Dictionary<T, bool> Data { set; get; }

        public Repository()
        {
            Data = new Dictionary<T, bool>();
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<KeyValuePair<T, bool>, bool>> predicate)
        {
            return await Task.Run(() =>
            {
                var query = Data.AsQueryable().Where(predicate);
                return query.Select(kvp => kvp.Key).ToList();
            });
        }

        public virtual async Task<IEnumerable<T>> Find(List<Expression<Func<KeyValuePair<T, bool>, bool>>> predicates)
        {
            return await Task.Run(() =>
            {
                var query = Data.AsQueryable();
                predicates.ForEach(a => query = query.Where(a));
                return query.Select(kvp => kvp.Key).ToList();
            });
        }
    }
}
