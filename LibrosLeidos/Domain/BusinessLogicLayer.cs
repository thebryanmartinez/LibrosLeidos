﻿using LibrosLeidos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrosLeidos.Domain
{
    class BusinessLogicLayer
    {
        private DataAccessLayer _dataAccessLayer;
        public static bool editar;

        public BusinessLogicLayer()
        {
            _dataAccessLayer = new DataAccessLayer();
        }

        public ClsIngresoDatos GuardarLibro(ClsIngresoDatos ingreso)
        {
            if (ingreso.id == 0)
                _dataAccessLayer.InsertarLibro(ingreso);
            else
                _dataAccessLayer.ModificarLibro(ingreso);

            return ingreso;
        }

        public List<ClsIngresoDatos> ObtenerLibros(string searchText = null)
        {
           return _dataAccessLayer.ObtenerLibros(searchText);
        }

        public void EliminarLibro(int id)
        {
            _dataAccessLayer.EliminarLibro(id);
        }

        public int ObtenerAnoLeido(int ano)
        {
            return _dataAccessLayer.ObtenerAnoLeido(ano);
        }

        
    }
}
