
namespace AntiFishing.Infrastructure.InfrastructureBase
{
	public interface IGenericRepositoryAsync<T> where T : class
	{
		Task DeleteRangeAsync(ICollection<T> entities);//1
		Task<T> GetByIdAsync(int id);//2
		Task SaveChangesAsync();
		IDbContextTransaction BeginTransaction();
		void Commit();
		void RollBack();
		IQueryable<T> GetTableNoTracking();
		IQueryable<T> GetTableAsTracking();
		Task<T> AddAsync(T entity);//3
		Task AddRangeAsync(ICollection<T> entities);
		Task UpdateAsync(T entity);//4
		Task UpdateRangeAsync(ICollection<T> entities);
		Task DeleteAsync(T entity);//5
	}
}
