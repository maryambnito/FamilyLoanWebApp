using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyLoan.Utilities.Paging
{
    public abstract class PagedDataBase
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public int FirstRowOnPage
        {
            get { return (CurrentPage - 1) * PageSize + 1; }
        }
        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, TotalCount); }
        }

    }
    public class PagedData<TEntity> : PagedDataBase
    {
        public List<TEntity> QueryResult;
        public PagedData()
        {
            QueryResult = new List<TEntity>();

        }
   
       
    }
    public static class GetPagedExtension
    {
        public static  PagedData<TEntity> GetPagedList<TEntity>(this IQueryable<TEntity> query, PageParameters pageParameters)
        {
            var pagedData = new PagedData<TEntity>();
            pagedData.QueryResult = query.Skip((pageParameters.PageNumber- 1) * pageParameters.PageSize)
                              .Take(pageParameters.PageSize).ToList();
            pagedData.TotalCount = query.Count();
            pagedData.PageSize = pageParameters.PageSize;
            pagedData.CurrentPage = pageParameters.PageNumber;
            return pagedData;
        }

    }
}