﻿using AspInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using tf2024_asp_razor.Models.Entities;

namespace AspcoreBll
{
    public class PlaneService : IPlaneService
    {
        private readonly IDataContext _context;

        //public PlaneService(IDataContext context)
        //{
        //    this._context = context;
        //}

        public bool Delete(int Id)
        {
             PlaneEntity? entity = _context.Planes.SingleOrDefault(p => p.Id == Id);
            if (entity == null) { return false; }
            try
            {
                _context.Planes.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<PlaneEntity> GetAll()
        {
            return _context.Planes.AsEnumerable();
        }

        public PlaneEntity? GetById(int Id)
        {
            return _context.Planes.SingleOrDefault(m=>m.Id==Id);
        }

        public bool Insert(PlaneEntity toInsert)
        {
            
            
            try
            {
                _context.Planes.Add(toInsert);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(PlaneEntity toUpdate)
        {
            try
            {
                //Attention à vérifier
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
