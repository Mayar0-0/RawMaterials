﻿using RawMaterials.Models.Entities;
using RawMaterials.Repository.PagingAndSorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Repository.IRepository
{
    public interface IImporterCategoryRepo: IPagingAndSorting<ImporterCategory>
    {
    }
}