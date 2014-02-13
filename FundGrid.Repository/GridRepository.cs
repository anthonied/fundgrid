using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FunGrid.Domain;
using ServiceStack.OrmLite;
using Fundgrid.Data;

namespace FundGrid.Repository
{
    public class GridRepository : RepositoryBase
    {
        private Grid GetFullDomainGrid(GridData gridDb)
        {
            if (gridDb == null) return null;
            var grid = gridDb.ToDomain();
            grid.ExistingGridItems = new GridItemRepository().GetGridItemsByGridId(grid.Id);
            return grid;
        }
        public Grid GetGridByProjectId(int projectId)
        {
            var gridDb = _db.Select<GridData>().Where(x => x.ProjectId == projectId).FirstOrDefault();
            return GetFullDomainGrid(gridDb);
        }
        public Grid GetGridByProjectIdAndStatus(int projectId, Status status)
        {
            var gridDb = _db.Select<GridData>().Where(x => x.ProjectId == projectId && x.GridStatus == status).FirstOrDefault();
            return GetFullDomainGrid(gridDb);
        }
        private List<Grid> GetFullDomainGrids(List<GridData> gridsDb)
        {
            var grids = new List<Grid>();
            foreach (var gridDb in gridsDb)
            {
                grids.Add(GetFullDomainGrid(gridDb));
            }
            return grids;
        }
        public List<Grid> GetArchivedGridsByProjectId(int projectId)
        {
            var gridsDb = _db.Select<GridData>().Where(x => x.GridStatus == Status.archived && x.ProjectId == projectId).ToList();
            return GetFullDomainGrids(gridsDb);
        }
        public bool CreateNewGrid(int projectId, int rows, int columns, decimal itemValue, decimal incrementValue, string gridName, string gridDescription)
        {
            _db.InsertOnly<GridData>(
                new GridData() 
                { 
                    ProjectId = projectId,
                    DimensionColumns = columns,
                    DimensionRows = rows,
                    InitialValue = itemValue,
                    IncrementValue = incrementValue,
                    Name = gridName,
                    Description = gridDescription 
                }, x => x.Insert(y => new { y.Description, y.DimensionColumns, y.DimensionRows, y.GridStatus, y.IncrementValue, y.InitialValue, y.Name, y.ProjectId }));
            if (_db.LastInsertId() > 0)
                return true;
            return false;
        }
        public void RemoveGrid(int gridId)
        {
            _db.DeleteById<GridData>(gridId);
        }
        public void ArchiveGrid(int gridId)
        {
            _db.UpdateOnly<GridData>(new GridData(){Id = gridId}, x => x.Update(y => new { Status.archived }));
        }
    }
}
