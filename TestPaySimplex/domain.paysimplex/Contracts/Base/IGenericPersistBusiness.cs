using System;
using System.Collections.Generic;
using System.Text;

namespace domain.paysimplex.Contracts.Base
{
	public interface IGenericPersistBusiness<TEntity> where TEntity : class
	{
		object Save(TEntity obj, long idUser);
		object Update(TEntity obj, long idUser);
		object Delete(TEntity obj);
	}
}
